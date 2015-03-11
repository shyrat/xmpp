// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Manager.cs">
//   
// </copyright>
// <summary>
//   The manager.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using XMPP.Common;
using XMPP.SASL;
using XMPP.States;

// ReSharper disable once CheckNamespace
namespace XMPP.Ñommon
{
    /// <summary>
    /// The manager.
    /// </summary>
    public class Manager : IDisposable
    {
        #region Properties

        /// <summary>
        /// The connection.
        /// </summary>
        public readonly IConnection Connection;

        /// <summary>
        /// The events.
        /// </summary>
        public readonly Events Events = new Events();

        /// <summary>
        /// The parser.
        /// </summary>
        public readonly Parser Parser;

        /// <summary>
        /// The process complete.
        /// </summary>
        public readonly ManualResetEvent ProcessComplete = new ManualResetEvent(true);

        /// <summary>
        /// The settings.
        /// </summary>
        public readonly Settings Settings = new Settings();

        /// <summary>
        /// The _state.
        /// </summary>
        private IState _state;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public IState State
        {
            get { return _state; }
            set
            {
                if (_state != null)
                    _state.Dispose();

                _state = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        public bool IsConnected
        {
            get { return State.GetType() != typeof(ClosedState); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is authenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is compressed.
        /// </summary>
        public bool IsCompressed { get; set; }

        /// <summary>
        /// Gets or sets the compression algorithm.
        /// </summary>
        public string CompressionAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the sasl processor.
        /// </summary>
        public SaslProcessor SaslProcessor { get; set; }

        /// <summary>
        /// Gets the transport.
        /// </summary>
        public Transport Transport { get; private set; }

        #endregion

        public Manager(Transport transport)
        {
            Transport = transport;

            Connection = transport == Transport.Socket ? new Connection(this) as IConnection : new Bosh(this) as IConnection;
            Parser = new Parser(this);
            State = new ClosedState(this);

            Events.OnNewTag += OnNewTag;
            Events.OnError += OnError;
            Events.OnConnect += OnConnect;
            Events.OnDisconnect += OnDisconnect;
        }

        #region eventhandler

        public void OnConnect(object sender, EventArgs e)
        {
            // We need an XID and Password to connect to the server.
            if (string.IsNullOrEmpty(Settings.Password))
                Events.Error(this, ErrorType.MissingPassword, ErrorPolicyType.Deactivate);
            else if (string.IsNullOrEmpty(Settings.Id))
                Events.Error(this, ErrorType.MissingJID, ErrorPolicyType.Deactivate);
            else if (string.IsNullOrEmpty(Settings.Hostname))
                Events.Error(this, ErrorType.MissingHost, ErrorPolicyType.Deactivate);
            else
            {
#if DEBUG
                Events.LogMessage(this, LogType.Info, "Connecting to {0}", Connection.Hostname);
#endif

                // Set the current state to connecting and start the process.
                State = new ConnectingState(this);
                State.Execute();
            }
        }

        public void OnDisconnect(object sender, EventArgs e)
        {
            if (State.GetType() != typeof(DisconnectState))
            {
                State = new DisconnectState(this);
                State.Execute();
            }
        }

        private void OnNewTag(object sender, TagEventArgs e)
        {
            State.Execute(e.tag);
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
#if DEBUG
            Events.LogMessage(this, LogType.Error, "Error from {0}: {1}", sender.GetType().ToString(), e.type.ToString());
#endif

            if (e.policy != ErrorPolicyType.Informative)
                Events.Disconnect(this);
        }

        #endregion

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="managed">
        /// The managed.
        /// </param>
        protected virtual void Dispose(bool managed)
        {
            Connection.Dispose();

            Events.OnNewTag -= OnNewTag;
            Events.OnError -= OnError;
            Events.OnConnect -= OnConnect;
            Events.OnDisconnect -= OnDisconnect;
        }
    }
}