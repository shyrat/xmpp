// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bosh.cs" company="">
//   
// </copyright>
// <summary>
//   The bo sh.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using XMPP.States;
using XMPP.Tags;
using XMPP.Tags.Bosh;
using XMPP.Tags.Streams;
using Namespace = XMPP.Tags.Streams.Namespace;

namespace XMPP.Сommon
{
    /// <summary>
    /// The bo sh.
    /// </summary>
    public class BoSH : IConnection
    {
        /// <summary>
        /// The start rid.
        /// </summary>
        private const int StartRid = 1000000;

        /// <summary>
        /// The end rid.
        /// </summary>
        private const int EndRid = 99999999;

        /// <summary>
        /// The hold.
        /// </summary>
        private const int Hold = 1;

        /// <summary>
        /// The wait.
        /// </summary>
        private const int Wait = 60;

        /// <summary>
        /// The _manager.
        /// </summary>
        private readonly Manager _manager;

        /// <summary>
        /// The _can fetch.
        /// </summary>
        private AutoResetEvent _canFetch;

        /// <summary>
        /// The _client.
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// The _connection error.
        /// </summary>
        private ManualResetEventSlim _connectionError;

        /// <summary>
        /// The _connections counter.
        /// </summary>
        private SemaphoreSlim _connectionsCounter;

        /// <summary>
        /// The _disconnecting.
        /// </summary>
        private ManualResetEventSlim _disconnecting;

        /// <summary>
        /// The _polling task.
        /// </summary>
        private Task _pollingTask;

        /// <summary>
        /// The _requests.
        /// </summary>
        private int? _requests;

        /// <summary>
        /// The _rid.
        /// </summary>
        private long _rid;

        /// <summary>
        /// The _sid.
        /// </summary>
        private string _sid;

        /// <summary>
        /// The _tags.
        /// </summary>
        private ConcurrentQueue<XElement> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoSH"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public BoSH(Manager manager)
        {
            _manager = manager;
        }

        /// <summary>
        ///     Gets a value indicating whether is connected.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        ///     Gets the hostname.
        /// </summary>
        public string Hostname
        {
            get { return _manager.Settings.Hostname; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is ssl enabled.
        /// </summary>
        public bool IsSSLEnabled { get; set; }

        /// <summary>
        /// The connect.
        /// </summary>
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

        /// <summary>
        /// The disconnect.
        /// </summary>
        public void Disconnect()
        {
            if (!IsConnected)
            {
                return;
            }

            _disconnecting.Set();

            if (null != _pollingTask)
            {
                _pollingTask.Wait();
                _pollingTask = null;
            }

            if (!_connectionError.IsSet)
            {
                SendSessionTerminationRequest();
            }

            CleanupState();

            _manager.Events.Disconnected(this);
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public void Send(Tag tag)
        {
            Task.Run(() => Flush(tag));
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Send(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The enable ssl.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EnableSSL()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The enable compression.
        /// </summary>
        /// <param name="algorithm">
        /// The algorithm.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EnableCompression(string algorithm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            CleanupState();
        }

        /// <summary>
        /// The restart.
        /// </summary>
        public void Restart()
        {
            SendRestartRequest();
        }

        /// <summary>
        /// The start polling.
        /// </summary>
        public void StartPolling()
        {
            _pollingTask = StartPollingInternal();
        }

        /// <summary>
        /// The init.
        /// </summary>
        private void Init()
        {
            _client = new HttpClient();

            _disconnecting = new ManualResetEventSlim(false);
            _connectionError = new ManualResetEventSlim(false);
            _canFetch = new AutoResetEvent(true);
            _tags = new ConcurrentQueue<XElement>();
            _rid = new Random().Next(StartRid, EndRid);
        }

        /// <summary>
        /// The remove comments.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <returns>
        /// The <see cref="XElement"/>.
        /// </returns>
        private XElement RemoveComments(Tag tag)
        {
            var copy = new XElement(tag);
            IEnumerable<XNode> comments = copy.DescendantNodesAndSelf()
                .Where(node => node.NodeType == XmlNodeType.Comment);

            while (comments.Any())
            {
                comments.First().Remove();
            }

            return copy;
        }

        /// <summary>
        /// The connection error.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="policy">
        /// The policy.
        /// </param>
        /// <param name="cause">
        /// The cause.
        /// </param>
        private void ConnectionError(ErrorType type, ErrorPolicyType policy, string cause = "")
        {
            if (_disconnecting.IsSet)
            {
                return;
            }

            if (!_connectionError.IsSet)
            {
                _connectionError.Set();

                _manager.Events.Error(this, type, policy, cause);
            }
        }

        /// <summary>
        /// The cleanup state.
        /// </summary>
        private void CleanupState()
        {
            IsConnected = false;

            if (null != _client)
            {
                _client.Dispose();
                _client = null;
            }
        }

        /// <summary>
        /// The send restart request.
        /// </summary>
        private void SendRestartRequest()
        {
            var body = new Body
            {
                Sid = _sid, 
                Rid = Interlocked.Increment(ref _rid), 
                Restart = true, 
                To = _manager.Settings.Id.Server
            };

            Body resp = SendRequest(body);
            if (null != resp)
            {
                var payload = resp.Element<Features>(Namespace.Features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        /// <summary>
        /// The send request.
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <returns>
        /// The <see cref="Body"/>.
        /// </returns>
        private Body SendRequest(Body body)
        {
            _manager.Events.Chunk(this, new ChunkLogEventArgs(body, ChunkDirection.Outgoing));

            var req = new HttpRequestMessage
            {
                RequestUri = new Uri(_manager.Settings.Hostname), 
                Method = new HttpMethod("POST"), 
                Content = new HttpStringContent(body, UnicodeEncoding.Utf8), 
            };

            req.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("text/xml")
            {
                CharSet = "utf-8", 
            };

            try
            {
                HttpResponseMessage resp = _client.SendRequestAsync(req).AsTask().Result;

                if (resp.IsSuccessStatusCode)
                {
                    string data = resp.Content.ReadAsStringAsync().AsTask().Result;

                    _manager.Events.Chunk(this, new ChunkLogEventArgs(data, ChunkDirection.Incomming));

                    return Tag.Get(data) as Body;
                }

                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, 
                    string.Format("Connection error:\r\nStatus: {0}\r\nReason Phrase: {1}", resp.StatusCode, 
                        resp.ReasonPhrase));
            }
            catch (AggregateException e)
            {
                if (!(e.InnerException is TaskCanceledException))
                {
                    ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// The send session creation request.
        /// </summary>
        private void SendSessionCreationRequest()
        {
            var body = new Body
            {
                Rid = _rid, 
                Wait = Wait, 
                Hold = Hold, 
                From = _manager.Settings.Id.Bare, 
                To = _manager.Settings.Id.Server
            };

            Body resp = SendRequest(body);

            if (null != resp)
            {
                IsConnected = true;

                _manager.Events.Connected(this);

                _sid = resp.Sid;
                _requests = resp.Requests;

                _connectionsCounter = new SemaphoreSlim(_requests.Value, _requests.Value);

                var payload = resp.Element<Features>(Namespace.Features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        /// <summary>
        /// The send session termination request.
        /// </summary>
        private void SendSessionTerminationRequest()
        {
            var body = new Body
            {
                Sid = _sid, 
                Rid = Interlocked.Increment(ref _rid), 
                Type = "terminate"
            };

            CombineBody(body);

            SendRequest(body);
        }

        /// <summary>
        /// The flush.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        private void Flush(Tag tag = null)
        {
            if (null != tag)
            {
                _tags.Enqueue(RemoveComments(tag));
            }

            FlushInternal();
        }

        /// <summary>
        /// The flush internal.
        /// </summary>
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

                    Body resp = SendRequest(body);

                    ExtractBody(resp);
                }
                finally
                {
                    _connectionsCounter.Release();

                    if (!_tags.IsEmpty)
                    {
                        Task.Run(() => Flush());
                    }
                }
            }
        }

        /// <summary>
        /// The combine body.
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        private void CombineBody(Body body)
        {
            int counter = _manager.Settings.QueryCount;

            while (!_tags.IsEmpty)
            {
                XElement tag;
                if (_tags.TryDequeue(out tag))
                {
                    body.Add(tag);
                    if (--counter == 0)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// The combine body.
        /// </summary>
        /// <returns>
        /// The <see cref="Body"/>.
        /// </returns>
        private Body CombineBody()
        {
            var body = new Body
            {
                Sid = _sid, 
                Rid = Interlocked.Increment(ref _rid), 
                From = _manager.Settings.Id, 
                To = _manager.Settings.Id.Server
            };

            CombineBody(body);

            return body;
        }

        /// <summary>
        /// The extract body.
        /// </summary>
        /// <param name="resp">
        /// The resp.
        /// </param>
        private void ExtractBody(Body resp)
        {
            if (null != resp)
            {
                foreach (XElement element in resp.Elements<XElement>())
                {
                    _manager.Events.NewTag(this, Tag.Get(element));
                }
            }
        }

        /// <summary>
        /// The start polling internal.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
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

                    if (_connectionsCounter.CurrentCount == _requests)
                    {
// no active requests
                        Task.Run(() => FlushInternal());
                    }

                    Task.Delay(TimeSpan.FromMilliseconds(10)).Wait();
                }

                ;
            });
        }
    }
}