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
using XMPP.Tags;

namespace XMPP.Сommon
{
    /// <summary>
    /// The Connection interface.
    /// </summary>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets the hostname.
        /// </summary>
        string Hostname { get; }

        /// <summary>
        /// Gets a value indicating whether is ssl enabled.
        /// </summary>
        bool IsSSLEnabled { get; }

        /// <summary>
        /// The connect.
        /// </summary>
        void Connect();

        /// <summary>
        /// The disconnect.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        void Send(Tag tag);

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Send(string message);

        /// <summary>
        /// The enable ssl.
        /// </summary>
        void EnableSSL();

        /// <summary>
        /// The enable compression.
        /// </summary>
        /// <param name="algorithm">
        /// The algorithm.
        /// </param>
        void EnableCompression(string algorithm);
    }
}