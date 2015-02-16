using System;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMPP.states;
using XMPP.tags;
using XMPP.tags.bosh;

namespace XMPP.common
{
    public class BoSH : IConnection
    {
        public BoSH(Manager manager)
        {
            _manager = manager;
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
            _disconnecting.Set();

            if (!_connectionError.IsSet)
            {
                SendSessionTerminationRequest();
            }

            CleanupState();

            _manager.Events.Disconnected(this);
        }

        public void Restart()
        {
            SendRestartRequest();
        }

        public void Send(tags.Tag tag)
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
            CleanupState();
        }

        private void Init()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(_manager.Settings.Hostname)
            };

            TimerCallback cb = obj => FlushInternal();
            _inactivityTimer = new Timer(cb, null, Timeout.Infinite, Timeout.Infinite);

            _disconnecting = new ManualResetEventSlim(false);
            _connectionError = new ManualResetEventSlim(false);
            _canFetch = new AutoResetEvent(true);
            _tags = new ConcurrentQueue<XElement>();
            _rid = new Random().Next(StartRid, EndRid);
        }

        private XElement RemoveComments(Tag tag)
        {
            var copy = new XElement(tag);
            var comments = copy.DescendantNodesAndSelf()
                               .Where(node => node.NodeType == System.Xml.XmlNodeType.Comment);
            while (comments.Any())
            {
                comments.First().Remove();
            }

            return copy;
        }

        private void ConnectionError(ErrorType type, ErrorPolicyType policy, string cause = "")
        {
            _connectionError.Set();

            _manager.Events.Error(this, type, policy, cause);
        }

        private void CleanupState()
        {
            IsConnected = false;

            if (null != _client)
            {
                _client.Dispose();
                _client = null;
            }

            if (null != _inactivityTimer)
            {
                _inactivityTimer.Dispose();
                _inactivityTimer = null;
            }

            _manager.ProcessComplete.Set();
            _manager.Parser.Clear();
        }

        private void SendRestartRequest()
        {
            var body = new body
            {
                sid = _sid,
                rid = Interlocked.Increment(ref _rid),
                restart = true,
                to = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);
            if (null != resp)
            {
                var payload = resp.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        private body SendRequest(body body)
        {
#if DEBUG
            Debug.WriteLine("Outgoing data:\r\n{0}", body);
#endif

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

#if DEBUG
                    Debug.WriteLine("Incomming data:\r\n{0}", data);
#endif

                    return Tag.Get(data) as body;
                }

                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
            }
            catch (Exception e)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, e.Message);
            }

            return null;
        }

        private void SendSessionCreationRequest()
        {
            var body = new body
            {
                rid = _rid,
                wait = Wait,
                hold = Hold,
                from = _manager.Settings.Id.Bare,
                to = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);

            if (null != resp)
            {
                IsConnected = true;

                _manager.Events.Connected(this);

                _sid = resp.sid;
                _polling = _manager.Settings.PollingInterval ?? resp.polling;
                _requests = resp.requests;

                _connectionsCounter = new SemaphoreSlim(_requests.Value, _requests.Value);

                var payload = resp.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

                _manager.State = new ServerFeaturesState(_manager);
                _manager.State.Execute(payload);
            }
        }

        private void SendSessionTerminationRequest()
        {
            var body = new body
            {
                sid = _sid,
                rid = Interlocked.Increment(ref _rid),
                type = "terminate"
            };

            CombineBody(body);

            SendRequest(body);
        }

        private void Flush(tags.Tag tag = null)
        {
            if (null != tag)
            {
                _tags.Enqueue(RemoveComments(tag));
            }

            FlushInternal();
        }

        private void FlushInternal()
        {
            if (_disconnecting.IsSet)
            {
                return;
            }

            if (_connectionError.IsSet)
            {
                return;
            }

            if (_connectionsCounter.Wait(TimeSpan.FromMilliseconds(1d)))
            {
                try
                {
                    _canFetch.WaitOne();

                    body body = CombineBody();

                    _canFetch.Set();

                    StartInactivityTimer();

                    var resp = SendRequest(body);

                    ExtractBody(resp);
                }
                finally
                {
                    _connectionsCounter.Release();

                    if (!_tags.IsEmpty)
                    {
                        Flush();
                    }
                }
            }
        }

        private void CombineBody(body body)
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

        private body CombineBody()
        {
            var body = new body
            {
                sid = _sid,
                rid = Interlocked.Increment(ref _rid),
                from = _manager.Settings.Id,
                to = _manager.Settings.Id.Server
            };

            CombineBody(body);

            return body;
        }

        private void ExtractBody(body resp)
        {
            if (null != resp)
            {
                foreach (var element in resp.Elements())
                {
                    _manager.Events.NewTag(this, Tag.Get(element.ToString()));
                }
            }
        }

        private void StartInactivityTimer()
        {
            _inactivityTimer.Change(_polling.Value * 1000, Timeout.Infinite);
        }

        private readonly Manager _manager;

        private string _sid;
        private long _rid;
        private int? _requests;
        private int? _polling;

        private HttpClient _client;
        private Timer _inactivityTimer;
        private SemaphoreSlim _connectionsCounter;
        private ManualResetEventSlim _connectionError;
        private ManualResetEventSlim _disconnecting;
        private AutoResetEvent _canFetch;
        private ConcurrentQueue<XElement> _tags;

        private const int StartRid = 1000000;
        private const int EndRid = 99999999;
        private const int Hold = 1;
        private const int Wait = 60;
    }
}
