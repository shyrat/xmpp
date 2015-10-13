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
// Copyright © 2006 - 2012 Dieter Lunn
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

using System.Threading;
using XMPP.SASL;
using XMPP.States;
using XMPP.Tags;

namespace XMPP.Common
{
    public class Manager : IDisposable
    {
        #region Properties

        public readonly IConnection Connection;

        public readonly Events Events = new Events();

        public readonly Parser Parser;

        public readonly ManualResetEvent ProcessComplete = new ManualResetEvent(true);

        public readonly Settings Settings = new Settings();

        private IState _state;

        private readonly object _stateSyncObj = new object();

        public bool IsConnected
        {
            get { return State.GetType() != typeof(ClosedState);}
        }

        public bool IsAuthenticated { get; set; }

        public bool IsCompressed { get; set; }

        public string CompressionAlgorithm { get; set; }

        public SaslProcessor SaslProcessor { get; set; }

        public Transport Transport { get; private set; }

        #endregion

        public Manager(Transport transport)
        {
            Transport = transport;

            Connection = transport == Transport.Socket ? new Connection(this) as IConnection : new Bosh(this) as IConnection;
            Parser = new Parser(this);
            SetAndExecState(new ClosedState(this));

            Events.OnNewTag += OnNewTag;
            Events.OnError += OnError;
            Events.OnConnect += OnConnect;
            Events.OnDisconnect += OnDisconnect;
        }

        #region eventhandler

        public IState State
        {
            get { return _state; }
        }

        public void SetAndExecState(IState state, bool execute = true, Tag data = null)
        {
            lock (_stateSyncObj)
            {
                if (null != _state)
                {
                    _state.Dispose();
                }

                _state = state;

                if (execute)
                {
                    _state.Execute(data);
                }
            }
        }

        public void ExecCurrentState(Tag data = null)
        {
            lock (_stateSyncObj)
            {
                _state.Execute(data);
            }
        }

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
                SetAndExecState(new ConnectingState(this));
            }
        }

        public void OnDisconnect(object sender, EventArgs e)
        {
            var type = State.GetType();

            if (type == typeof(ClosedState))
            {
                return;
            }

            if (type != typeof(DisconnectState))
            {
                SetAndExecState(new DisconnectState(this));
            }
        }

        private void OnNewTag(object sender, TagEventArgs e)
        {
            ExecCurrentState(e.tag);
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
#if DEBUG
            Events.LogMessage(this, LogType.Error, "Error from {0}: {1}", sender.GetType().ToString(), e.type.ToString());
#endif

            if (e.policy != ErrorPolicyType.Informative)
            {
                Events.Disconnect(this);
            }
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

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