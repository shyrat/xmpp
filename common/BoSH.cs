using System;
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

            InitPolling();
        }

        public void Send(tags.Tag tag)
        {
            if (tag is tags.xmpp_sasl.auth)
            {
                SendAuthRequest(tag as tags.xmpp_sasl.auth);
                return;
            }

            _tags.Enqueue(RemoveComments(tag));

            Flush();
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
        }

        private void InitPolling()
        {
            TimerCallback cb = obj => InactivityCallback();
            _inactivityTimer = new Timer(cb, null, Timeout.Infinite, Timeout.Infinite);

            _connectionsCounter = new SemaphoreSlim(_requests.Value, _requests.Value);
        }

        private XElement RemoveComments(Tag tag)
        {
            var copy = new XElement(tag);
            var descendants = copy.DescendantNodesAndSelf();
            var comments = descendants.Where(node => node.NodeType == System.Xml.XmlNodeType.Comment);
            while (comments.Any())
            {
                comments.First().Remove();
            }

            return copy;
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

            var resp = SendRequest(body);

            if (null == resp)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
            }

            var payload = resp.Elements().FirstOrDefault();

            _manager.Parser.Parse(payload.ToString());
        }

        private void SendRestartRequest()
        {
            var body = new body
            {
                sid = _sid,
                rid = ++_rid,
                restart = true,
                to = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);

            if (null == resp)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
            }

            var payload = resp.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

            _manager.State = new ServerFeaturesState(_manager);
            _manager.State.Execute(payload);
        }

        private body SendRequest(body body)
        {
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

                    return Tag.Get(data) as body;
                }

                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, string.Format("{0} {1}", resp.StatusCode, resp.ReasonPhrase));
            }
            catch (AggregateException e)
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
                wait = 60,
                hold = 1,
                from = _manager.Settings.Id.Bare,
                to = _manager.Settings.Id.Server
            };

            var resp = SendRequest(body);

            if (null == resp)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
            }

            _sid = resp.sid;
            _polling = resp.polling;
            _inactivity = resp.inactivity;
            _requests = resp.requests;

            var payload = resp.Element<XMPP.tags.streams.features>(XMPP.tags.streams.Namespace.features);

            _manager.State = new ServerFeaturesState(_manager);
            _manager.State.Execute(payload);
        }

        private void Flush()
        {
            Task.Run(() => FlushInternal());
        }

        private void FlushInternal()
        {
            if (_connectionsCounter.Wait(TimeSpan.FromMilliseconds(1d)))
            {
                StopInactivityTimer();

                try
                {
                    if (_tags.IsEmpty)
                    {
                        return;
                    }

                    var body = new body { sid = _sid, rid = Interlocked.Increment(ref _rid), from = _manager.Settings.Id, to = _manager.Settings.Id.Server };

                    while (!_tags.IsEmpty)
                    {
                        XElement tag;
                        if (_tags.TryDequeue(out tag))
                        {
                            body.Add(tag);
                        }
                    }

                    var resp = SendRequest(body);

                    if (null == resp)
                    {
                        ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                    }

                    foreach (var element in resp.Elements())
                    {
                        _manager.Parser.Parse(element.ToString());
                    }
                }
                finally
                {
                    _connectionsCounter.Release();

                    if (!_tags.IsEmpty)
                    {
                        Flush();
                    }
                    else if (2 == _connectionsCounter.CurrentCount)
                    {
                        StartInactivityTimer();
                    }
                }
            }
        }

        private void InactivityCallback()
        {
            if (_connectionsCounter.Wait(TimeSpan.FromMilliseconds(1d)))
            {
                StopInactivityTimer();

                try
                {
                    var body = new body { sid = _sid, rid = Interlocked.Increment(ref _rid), from = _manager.Settings.Id, to = _manager.Settings.Id.Server };

                    var resp = SendRequest(body);

                    if (null == resp)
                    {
                        ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, "Empty data.");
                    }

                    foreach (var element in resp.Elements())
                    {
                        _manager.Parser.Parse(element.ToString());
                    }
                }
                finally
                {
                    _connectionsCounter.Release();

                    if (2 == _connectionsCounter.CurrentCount)
                    {
                        StartInactivityTimer();
                    }
                }
            }
        }

        private void StartInactivityTimer()
        {
            _inactivityTimer.Change(_inactivity.Value * 1000, _inactivity.Value * 1000);
        }

        private void StopInactivityTimer()
        {
            _inactivityTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private readonly Manager _manager;

        private HttpClient _client;

        private string _sid;
        private int _rid;
        private int? _requests;
        private int? _inactivity;
        private int? _polling;

        private Timer _inactivityTimer;
        private SemaphoreSlim _connectionsCounter;

        private readonly ConcurrentQueue<XElement> _tags = new ConcurrentQueue<XElement>();
    }
}
