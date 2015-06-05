﻿// Copyright © 2006 - 2012 Dieter Lunn
// Modified 2012 Paul Freund ( freund.paul@lvl3.org )
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
// You should have received a copy of the GNU Lesser General Public License along
// with this library; if not, write to the Free Software Foundation, Inc., 59
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using XMPP.Extensions;
using XMPP.States;
using XMPP.Tags;
using XMPP.Tags.Bosh;

namespace XMPP.Сommon
{
    public class Bosh : IConnection
    {
        public Bosh(Manager manager)
        {
            _manager = manager;
        }

        public bool IsConnected
        {
            get
            {
                return _isConnected.IsSet;
            }

            private set
            {
                if (value)
                {
                    _isConnected.Set();
                }
                else
                {
                    _isConnected.Reset();
                }
            }
        }

        public string Hostname
        {
            get { return _manager.Settings.Hostname; }
        }

        public bool IsSSLEnabled { get; set; }

        public void Connect()
        {
            if (IsConnected)
            {
#if DEBUG
                _manager.Events.LogMessage(this, LogType.Warn, "Already connected");
#endif
                return;
            }

            Init();

            SendSessionCreationRequest();
        }

        public void Disconnect()
        {
            if (_disconnecting.IsSet)
            {
                return;
            }

            _disconnecting.Set();

            if (null != _pollingTask)
            {
                _pollingTask.Wait();
            }

            if (!_connectionError.IsSet)
            {
                SendSessionTerminationRequest();
            }
            else
            {
                _client.Dispose();
                _client = null;
            }

            _manager.Events.Disconnected(this);

            IsConnected = false;
        }

        public void Restart()
        {
            SendRestartRequest();
        }

        public void StartPolling()
        {
            _pollingTask = StartPollingInternal();
        }

        public void Send(Tag tag)
        {
            Task.Run(() => Flush(tag));
        }

        public void Send(string message)
        {
            throw new NotImplementedException();
        }

        public void EnableSSL()
        {
            throw new NotImplementedException();
        }

        public void EnableCompression(string algorithm)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Init()
        {
            Cleanup();

            _client = new HttpClient();

            _disconnecting = new ManualResetEventSlim(false);
            _connectionError = new ManualResetEventSlim(false);
            _canFetch = new AutoResetEvent(true);
            _tagQueue = new ConcurrentQueue<XElement>();
            _rid = new Random().Next(StartRid, EndRid);
        }

        private void ConnectionError(ErrorType type, ErrorPolicyType policy, string cause, Body body)
        {
            if (_disconnecting.IsSet)
            {
                return;
            }

            if (string.IsNullOrEmpty(body.SidAttr) || Interlocked.Increment(ref _retryCounter) >= MaxRetry)
            {
                if (!_connectionError.IsSet)
                {
                    _connectionError.Set();

                    Task.Run(() => _manager.Events.Error(this, type, policy, cause));
                }
            }
            else
            {
                foreach (var item in body.Elements())
                {
                    _tagQueue.Enqueue(item);
                }

                Task.Run(() => FlushInternal());
            }
        }

        private void Cleanup()
        {
            if (null != _client)
            {
                _client.Dispose();
                _client = null;
            }

            if (null != _connectionsCounter)
            {
                _connectionsCounter.Dispose();
                _connectionsCounter = null;
            }

            if (null != _connectionError)
            {
                _connectionError.Dispose();
                _connectionError = null;
            }

            if (null != _disconnecting)
            {
                _disconnecting.Dispose();
                _disconnecting = null;
            }

            if (null != _canFetch)
            {
                _canFetch.Dispose();
                _canFetch = null;
            }

            _tagQueue = null;
            _pollingTask = null;
        }

        private void SendRestartRequest()
        {
            var body = new Body
            {
                SidAttr = _sid,
                RidAttr = Interlocked.Increment(ref _rid),
                RestartAttr = true,
                ToAttr = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);
            if (null != resp)
            {
                var payload = resp.Element<Tags.Streams.Features>(Tags.Streams.Namespace.Features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        private Body SendRequest(Body body)
        {
            using (var req = new HttpRequestMessage
            {
                RequestUri = new Uri(_manager.Settings.Hostname),
                Method = new HttpMethod("POST"),
                Content = new HttpStringContent(body, UnicodeEncoding.Utf8),
            })
            {
                req.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("text/xml")
                {
                    CharSet = "utf-8",
                };

                try
                {
                    using (var resp = _client.SendRequestAsync(req).AsTask().Result)
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            var data = resp.Content.ReadAsStringAsync().AsTask().Result;

                            Interlocked.Exchange(ref _retryCounter, 0);

                            return Tag.Get(data) as Body;
                        }

                        ConnectionError(
                            ErrorType.ConnectToServerFailed,
                            ErrorPolicyType.Reconnect,
                            string.Format(
                                "Connection error: Status: {0} Reason Phrase: {1}",
                                resp.StatusCode,
                                resp.ReasonPhrase),
                            body);
                    }
                }
                catch (AggregateException e)
                {
                    if (!(e.InnerException is TaskCanceledException))
                    {
                        ConnectionError(
                            ErrorType.ConnectToServerFailed,
                            ErrorPolicyType.Reconnect,
                            e.Message,
                            body);
                    }
                }

                return null;
            }
        }

        private void SendSessionCreationRequest()
        {
            var body = new Body
            {
                RidAttr = _rid,
                WaitAttr = Wait,
                HoldAttr = Hold,
                FromAttr = _manager.Settings.Id.Bare,
                ToAttr = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);

            if (null != resp)
            {
                IsConnected = true;

                _manager.Events.Connected(this);

                _sid = resp.SidAttr;
                _requests = resp.RequestsAttr;

                _connectionsCounter = new SemaphoreSlim(_requests.Value, _requests.Value);

                var payload = resp.Element<Tags.Streams.Features>(Tags.Streams.Namespace.Features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        private void SendSessionTerminationRequest()
        {
            var body = new Body
            {
                SidAttr = _sid,
                RidAttr = Interlocked.Increment(ref _rid),
                TypeAttr = "terminate"
            };

            CombineBody(body);

            SendRequest(body);
        }

        private void Flush(Tag tag = null)
        {
            if (null != tag)
            {
                _tagQueue.Enqueue((XElement)tag);
            }

            FlushInternal();
        }

        private void FlushInternal()
        {
            if (_disconnecting.IsSet || _connectionError.IsSet)
            {
                return;
            }

            if (_connectionsCounter.Wait(TimeSpan.FromMilliseconds(1d)))
            {
                try
                {
                    _canFetch.WaitOne();

                    Body body = CombineBody();

                    _canFetch.Set();

                    var resp = SendRequest(body);

                    ExtractBody(resp);
                }
                finally
                {
                    _connectionsCounter.Release();
                }
            }
        }

        private void CombineBody(Body body)
        {
            int counter = _manager.Settings.QueryCount;

            while (!_tagQueue.IsEmpty)
            {
                XElement tag;
                if (_tagQueue.TryDequeue(out tag))
                {
                    body.Add(tag);
                    if (--counter == 0)
                    {
                        break;
                    }
                }
            }
        }

        private Body CombineBody()
        {
            var body = new Body
            {
                SidAttr = _sid,
                RidAttr = Interlocked.Increment(ref _rid),
                FromAttr = _manager.Settings.Id,
                ToAttr = _manager.Settings.Id.Server
            };

            CombineBody(body);

            return body;
        }

        private void ExtractBody(Body resp)
        {
            if (null != resp)
            {
                foreach (var element in resp.Elements())
                {
                    _manager.Events.NewTag(this, Tag.Get(element));
                }
            }
        }

        private Task StartPollingInternal()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    if (_disconnecting.IsSet || _connectionError.IsSet)
                    {
                        return;
                    }

                    if (_connectionsCounter.CurrentCount == _requests) //no active requests
                    {
                        Task.Run(() => FlushInternal());
                    }

                    Task.Delay(TimeSpan.FromMilliseconds(10)).Wait();
                };
            });
        }

        private readonly Manager _manager;

        private string _sid;
        private long _rid;
        private int? _requests;

        private long _retryCounter;

        private HttpClient _client;
        private SemaphoreSlim _connectionsCounter;
        private ManualResetEventSlim _connectionError;
        private ManualResetEventSlim _disconnecting;
        private AutoResetEvent _canFetch;
        private ConcurrentQueue<XElement> _tagQueue;
        private Task _pollingTask;

        private readonly ManualResetEventSlim _isConnected = new ManualResetEventSlim(false);

        private const int StartRid = 1000000;
        private const int EndRid = 99999999;
        private const int Hold = 1;
        private const int Wait = 60;

        private const long MaxRetry = 3;
    }
}
