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

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using XMPP.Tags;
using XMPP.Common;

namespace XMPP
{
    public enum Transport
    {
        Socket,
        Bosh
    }

    public class Client : IDisposable
    {
        private readonly Manager _manager;

        public Client() : this(Transport.Socket)
        {
        }

        public Client(Transport transport)
        {
            Transport = transport;

            _manager = new Manager(transport);
        }

        public Transport Transport { get; private set; }

        #region Properties

        public readonly string Version = typeof(Client).GetTypeInfo().Assembly.GetName().Version.ToString();

        public Settings Settings
        {
            get { return _manager.Settings; }
        }

        public bool Connected
        {
            get { return _manager.IsConnected; }
        }

        public ManualResetEvent ProcessComplete
        {
            get { return _manager.ProcessComplete; }
        }

        #endregion

        #region Events

        public event Events.ExternalError OnError
        {
            add { _manager.Events.OnError += value; }
            remove { _manager.Events.OnError -= value; }
        }

        public event Events.ExternalNewTag OnNewTag
        {
            add { _manager.Events.OnNewTag += value; }
            remove { _manager.Events.OnNewTag -= value; }
        }

        public event Events.ExternalLogMessage OnLogMessage
        {
            add { _manager.Events.OnLogMessage += value; }
            remove { _manager.Events.OnLogMessage -= value; }
        }

        public event Events.ExternalReady OnReady
        {
            add { _manager.Events.OnReady += value; }
            remove { _manager.Events.OnReady -= value; }
        }

        public event Events.ExternalResourceBound OnResourceBound
        {
            add { _manager.Events.OnResourceBound += value; }
            remove { _manager.Events.OnResourceBound -= value; }
        }

        public event Events.ExternalConnected OnConnected
        {
            add { _manager.Events.OnConnected += value; }
            remove { _manager.Events.OnConnected -= value; }
        }

        public event Events.ExternalDisconnected OnDisconnected
        {
            add { _manager.Events.OnDisconnected += value; }
            remove { _manager.Events.OnDisconnected -= value; }
        }

        public event Events.ExternalReceive OnReceive
        {
            add { _manager.Events.OnReceive += value; }
            remove { _manager.Events.OnReceive -= value; }
        }

        public event Events.ExternalChunk OnChunk
        {
            add { _manager.Events.OnChunk += value; }
            remove { _manager.Events.OnChunk -= value; }
        }

        #endregion

        #region Actions

        public void Connect()
        {
            _manager.Events.Connect(null);
        }

        public Task ConnectAsync()
        {
            return Task.Run(() => Connect());
        }

        public void Disconnect()
        {
            _manager.Events.Disconnect(null);
        }

        public Task DisconnectAsync()
        {
            return Task.Run(() => Disconnect());
        }

        public void Send(Tag tag)
        {
            Send(new TagEventArgs(tag));
        }

        public Task SendAsync(Tag tag)
        {
            return Task.Run(() => Send(tag));
        }

        public void Send(TagEventArgs e)
        {
            _manager.Events.Send(null, e);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool managed)
        {
            _manager.Dispose();
        }
    }
}