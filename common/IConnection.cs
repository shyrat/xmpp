// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnection.cs" company="">
//   
// </copyright>
// <summary>
//   The Connection interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



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