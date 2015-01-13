using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using XMPP.compression;
using XMPP.registries;
using XMPP.states;
using XMPP.tags;
using XMPP.tags.bosh;
using XMPP.tags.streams;

namespace XMPP.common
{
    public class BoSH : IConnection
    {
        public BoSH(Manager manager)
        {
            _manager = manager;

            TimerCallback cb = obj => InactivityCallback();
            _inactivityTimer = new Timer(cb, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        public bool IsConnected
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the hostname.
        /// </summary>
        public string Hostname
        {
            get { return _manager.Settings.Hostname; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is ssl enabled.
        /// </summary>
        public bool IsSSLEnabled
        {
            get;
            set;
        }

        public void Connect()
        {
            if (IsConnected)
            {
#if DEBUG
                _manager.Events.LogMessage(this, LogType.Warn, "Already connected");
#endif
                return;
            }

            _client = new HttpClient
            {
                BaseAddress = new Uri(_manager.Settings.Hostname)
            };

            _rid = new Random().Next(1000000, 9999999);

            SendSessionCreationRequest();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            SendRestartRequest();
        }

        public void Send(tags.Tag tag)
        {
            if (tag is tags.xmpp_sasl.auth)
            {
                SendAuthRequest(tag as tags.xmpp_sasl.auth);
                return;
            }

            // Remove comments
            var manipulationCopy = new XElement(tag);
            var descendants = manipulationCopy.DescendantNodesAndSelf();
            var comments = descendants.Where(node => node.NodeType == System.Xml.XmlNodeType.Comment);
            while (comments.Any())
            {
                comments.First().Remove();
            }

            _tags.Enqueue(manipulationCopy);

            Flush();
        }

        public void Send(string message)
        {
        }

        public void EnableSSL()
        {
            throw new NotImplementedException();
        }

        public void EnableCompression(string algorithm)
        {
        }

        public void Dispose()
        {
            if (null != _client)
            {
                _client.Dispose();
                _client = null;
            }
        }

        private void ConnectionError(ErrorType type, ErrorPolicyType policy, string cause = "")
        {
            CleanupState();
            _manager.Events.Error(this, type, policy, cause);
        }

        private void CleanupState()
        {
            IsConnected = false;

            _manager.ProcessComplete.Set();
            _manager.Parser.Clear();
        }

        private void SendAuthRequest(tags.xmpp_sasl.auth tag)
        {
            var body = new body { sid = _sid, rid = ++_rid, from = _manager.Settings.Id.Bare, to = _manager.Settings.Id.Server };
            body.Add(tag);

            var req = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                Content = new StringContent(body)
            };

            try
            {
                var resp = _client.SendAsync(req).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var data = resp.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(data))
                    {
                        ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                    }

                    var content = Tag.Get(data) as body;

                    if (null != content)
                    {
                        var payload = content.Elements().FirstOrDefault();

                        _manager.Parser.Parse(payload.ToString());
                    }
                }
                else
                {
                    ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
                }
            }
            catch (AggregateException e)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
            }
        }

        private void SendRestartRequest()
        {
            var body = new body { sid = _sid, rid = ++_rid, restart = true, to = _manager.Settings.Id.Server };

            var req = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                Content = new StringContent(body)
            };

            try
            {
                var resp = _client.SendAsync(req).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var data = resp.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(data))
                    {
                        ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                    }

                    var content = Tag.Get(data) as body;

                    if (null != content)
                    {
                        var payload = content.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

                        _manager.State = new ServerFeaturesState(_manager);
                        _manager.State.Execute(payload);
                    }
                }
                else
                {
                    ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
                }
            }
            catch (AggregateException e)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
            }
        }

        private void SendSessionCreationRequest()
        {
            var body = new body { rid = _rid, wait = 60, hold = 1, from = _manager.Settings.Id.Bare, to = _manager.Settings.Id.Server };

            var req = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                Content = new StringContent(body)
            };

            try
            {
                var resp = _client.SendAsync(req).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var data = resp.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(data))
                    {
                        ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                    }

                    var content = Tag.Get(data) as body;

                    _sid = content.sid;
                    _polling = content.polling;
                    _inactivity = content.inactivity;

                    if (null != content)
                    {
                        var payload = content.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

                        _manager.State = new ServerFeaturesState(_manager);
                        _manager.State.Execute(payload);
                    }
                }
                else
                {
                    ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
                }
            }
            catch (AggregateException e)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
            }
        }

        private void Flush()
        {
            Task.Run(() => FlushInternal());
        }

        private void FlushInternal()
        {
            //if (0 == _connectionsCounter.CurrentCount && _tags.IsEmpty)
            //{
            //    StopInactivityTimer();

            //    OnInactivityTimeout();
           //     return;
          //  }

            if (_connectionsCounter.Wait(TimeSpan.FromMilliseconds(1d)))
            {
                try
                {
                    if (!_tags.IsEmpty)
                    {
                        var body = new body { sid = _sid, rid = Interlocked.Increment(ref _rid), from = _manager.Settings.Id, to = _manager.Settings.Id.Server };

                        while (!_tags.IsEmpty)
                        {
                            XElement tag;
                            if (_tags.TryDequeue(out tag))
                            {
                                body.Add(tag);
                            }
                        }

                        var req = new HttpRequestMessage
                        {
                            Method = new HttpMethod("POST"),
                            Content = new StringContent(body)
                        };

                        try
                        {
                            var resp = _client.SendAsync(req).Result;

                            if (resp.IsSuccessStatusCode)
                            {
                                var data = resp.Content.ReadAsStringAsync().Result;

                                if (string.IsNullOrWhiteSpace(data))
                                {
                                    ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                                }

                                var content = Tag.Get(data) as body;

                                if (null != content)
                                {
                                    foreach (var element in content.Elements())
                                    {
                                        _manager.Parser.Parse(element.ToString());
                                    }
                                }
                            }
                            else
                            {
                                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
                            }
                        }
                        catch (AggregateException e)
                        {
                            ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
                        }
                    }
                }
                finally
                {
                    _connectionsCounter.Release();
                }
            }
            else
            {
                StartInactivityTimer();
            }
        }

        private void InactivityCallback()
        {
        }

        private void StartInactivityTimer()
        {
        }

        private void StopInactivityTimer()
        {
        }

        private void OnInactivityTimeout()
        {
        }

        private bool _isCompressionEnabled;
        private readonly Manager _manager;
        private HostName _hostname;
        private readonly UTF8Encoding _encoding = new UTF8Encoding();
        private ICompression _compression = null;

        private HttpClient _client;

        private int _rid;
        private string _sid;

        private int? _inactivity;
        private int? _polling;
        private readonly Timer _inactivityTimer;

        private readonly ConcurrentQueue<XElement> _tags = new ConcurrentQueue<XElement>();

        //private int _connectionsCounter;

        private readonly SemaphoreSlim _connectionsCounter = new SemaphoreSlim(2, 2);
    }
}
