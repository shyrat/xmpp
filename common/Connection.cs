// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Connection.cs">
//   
// </copyright>
// <summary>
//   The repeat.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using XMPP.compression;
using XMPP.Extensions;
using XMPP.Registries;
using XMPP.States;
using XMPP.Tags;
using Buffer = Windows.Storage.Streams.Buffer;

namespace XMPP.Ñommon
{

    #region helper

    /// <summary>
    /// The repeat.
    /// </summary>
    internal static class Repeat
    {
        /// <summary>
        /// The interval.
        /// </summary>
        /// <param name="pollInterval">
        /// The poll interval.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static Task Interval(TimeSpan pollInterval, Action action, CancellationToken token)
        {
            return Task.Factory.StartNew(() =>
            {
                for (;;)
                {
                    if (token.WaitCancellationRequested(pollInterval))
                        break;

                    action();
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }

    /// <summary>
    /// The cancellation token extensions.
    /// </summary>
    internal static class CancellationTokenExtensions
    {
        /// <summary>
        /// The wait cancellation requested.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitCancellationRequested(
            this CancellationToken token, 
            TimeSpan timeout)
        {
            return token.WaitHandle.WaitOne(timeout);
        }
    }

    #endregion

    /// <summary>
    /// The connection.
    /// </summary>
    public class Connection : IConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public Connection(Manager manager)
        {
            _manager = manager;
        }

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
            _elevateMutex.Dispose();
        }

        #region properties

        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        public bool IsConnected { get; private set; }

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

        #endregion

        #region member

        /// <summary>
        /// The _buffer size.
        /// </summary>
        private const int _bufferSize = 64*1024; // This is the maximal TCP packet size

        /// <summary>
        /// The _elevate mutex.
        /// </summary>
        private readonly ManualResetEvent _elevateMutex = new ManualResetEvent(true);

        /// <summary>
        /// The _encoding.
        /// </summary>
        private readonly UTF8Encoding _encoding = new UTF8Encoding();

        /// <summary>
        /// The _manager.
        /// </summary>
        private readonly Manager _manager;

        /// <summary>
        /// The _socket.
        /// </summary>
        private readonly StreamSocket _socket = new StreamSocket();

        /// <summary>
        /// The _socket read buffer.
        /// </summary>
        private readonly IBuffer _socketReadBuffer = new Buffer(_bufferSize);

        /// <summary>
        /// The _compression.
        /// </summary>
        private ICompression _compression;

        /// <summary>
        /// The _hostname.
        /// </summary>
        private HostName _hostname;

        /// <summary>
        /// The _is compression enabled.
        /// </summary>
        private bool _isCompressionEnabled;

        /// <summary>
        /// The _socket connector.
        /// </summary>
        private IAsyncAction _socketConnector;

        /// <summary>
        /// The _socket elevator.
        /// </summary>
        private IAsyncAction _socketElevator;

        /// <summary>
        /// The _socket reader.
        /// </summary>
        private IAsyncOperationWithProgress<IBuffer, uint> _socketReader;

        /// <summary>
        /// The _socket write message.
        /// </summary>
        private string _socketWriteMessage = string.Empty;

        /// <summary>
        /// The _socket writer.
        /// </summary>
        private IAsyncOperationWithProgress<uint, uint> _socketWriter;

        #endregion

        #region actions

        /// <summary>
        /// The connect.
        /// </summary>
        public void Connect()
        {
            SocketConnect();
        }

        /// <summary>
        /// The disconnect.
        /// </summary>
        public void Disconnect()
        {
            SocketDisconnect();
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public void Send(Tag tag)
        {
            // Remove comments
            var manipulationCopy = new XElement(tag);
            IEnumerable<XNode> descendants = manipulationCopy.DescendantNodesAndSelf();
            IEnumerable<XNode> comments = descendants.Where(node => node.NodeType == XmlNodeType.Comment);
            while (comments.Count() > 0)
                comments.First().Remove();

            Send(manipulationCopy.ToString());
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Send(string message)
        {
            SocketSend(message);
        }

        /// <summary>
        /// The enable ssl.
        /// </summary>
        public void EnableSSL()
        {
            if (!_manager.Settings.OldSSL)
                SocketElevate();
        }

        /// <summary>
        /// The enable compression.
        /// </summary>
        /// <param name="algorithm">
        /// The algorithm.
        /// </param>
        public void EnableCompression(string algorithm)
        {
            StartCompression(algorithm);
        }

        #endregion

        #region socket operations

        /// <summary>
        /// The socket connect.
        /// </summary>
        private void SocketConnect()
        {
            if (IsConnected)
            {
#if DEBUG
                _manager.Events.LogMessage(this, LogType.Warn, "Already connected");
#endif
                return;
            }

            if (_socketConnector != null && _socketConnector.Status == AsyncStatus.Started)
            {
#if DEBUG
                _manager.Events.LogMessage(this, LogType.Warn, "Already connecting");
#endif
                return;
            }

            CleanupState();

            try
            {
                _hostname = new HostName(_manager.Settings.Hostname);
            }
            catch
            {
                ConnectionError(ErrorType.InvalidHostName, ErrorPolicyType.Deactivate);
                return;
            }

            _socket.Control.KeepAlive = false;

            SocketProtectionLevel protection = _manager.Settings.OldSSL
                ? SocketProtectionLevel.SslAllowNullEncryption
                : SocketProtectionLevel.PlainSocket;
            _socketConnector = _socket.ConnectAsync(_hostname, _manager.Settings.Port.ToString(), protection);
            _socketConnector.Completed = OnSocketConnectorCompleted;
        }

        /// <summary>
        /// The socket disconnect.
        /// </summary>
        private void SocketDisconnect()
        {
            if (IsConnected)
            {
                SocketSend("</stream:stream>", true);
            }

#if DEBUG
            else
            {
                _manager.Events.LogMessage(this, LogType.Warn, "Already disconnected");
            }
#endif

            CleanupState();

            _manager.Events.Disconnected(this);
        }

        /// <summary>
        /// The socket send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="synchronized">
        /// The synchronized.
        /// </param>
        private void SocketSend(string message, bool synchronized = false)
        {
            if (!IsConnected || string.IsNullOrEmpty(message)) return;

            // Prepare message
            _socketWriteMessage = message;
            byte[] writeBytes = _encoding.GetBytes(message);

            if (_isCompressionEnabled)
                writeBytes = _compression.Deflate(writeBytes);

            IBuffer sendBuffer = CryptographicBuffer.CreateFromByteArray(writeBytes);

            if (synchronized)
            {
// Wait for completion
                _elevateMutex.WaitOne(4000);
                _socket.OutputStream.WriteAsync(sendBuffer).AsTask().Wait(4000);
            }
            else
            {
// wait for last task and start new one
                // Wait for other reads to finish 
                if (_socketWriter != null && _socketWriter.Status == AsyncStatus.Started)
                {
                    try
                    {
                        _socketWriter.AsTask().Wait(4000);
                    }
                    catch
                    {
                        // if (_socketWriter.Status == AsyncStatus.Started)
                        // {
                        // ConnectionError(ErrorType.WriteStateMismatch, ErrorPolicyType.Reconnect);
                        // return;
                        // }
                    }
                }

                _elevateMutex.WaitOne(4000);

                if (IsConnected)
                {
                    _socketWriter = _socket.OutputStream.WriteAsync(sendBuffer);
                    _socketWriter.Completed = OnSocketWriterCompleted;
                }
            }
        }

        /// <summary>
        /// The socket read.
        /// </summary>
        private void SocketRead()
        {
            try
            {
                if (!IsConnected) return;
                _elevateMutex.WaitOne(4000);

                _socketReader = _socket.InputStream.ReadAsync(_socketReadBuffer, _bufferSize, InputStreamOptions.Partial);
                _socketReader.Completed = OnSocketReaderCompleted;
            }
            catch
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect);
            }
        }

        /// <summary>
        /// The socket elevate.
        /// </summary>
        private void SocketElevate()
        {
            if (!IsConnected) return;

            _elevateMutex.Reset();

            if (_socketReader != null)
                _socketReader.Cancel();

            // Wait for other reads to finish 
            if (_socketWriter != null && _socketWriter.Status == AsyncStatus.Started)
            {
                try
                {
                    _socketWriter.AsTask().Wait(4000);
                }
                catch
                {
                    if (_socketWriter.Status == AsyncStatus.Started)
                    {
                        ConnectionError(ErrorType.WriteStateMismatch, ErrorPolicyType.Reconnect);
                        return;
                    }
                }
            }

            _socketElevator = _socket.UpgradeToSslAsync(SocketProtectionLevel.SslAllowNullEncryption, _hostname);
            _socketElevator.Completed = OnSocketElevatorCompleted;
        }

        /// <summary>
        /// The cleanup state.
        /// </summary>
        private void CleanupState()
        {
            IsConnected = false;

            _manager.ProcessComplete.Set();

            _elevateMutex.Set();

            _manager.Parser.Clear();

            if (_socketConnector != null) _socketConnector.Cancel();
            if (_socketElevator != null) _socketElevator.Cancel();
            if (_socketReader != null) _socketReader.Cancel();
            if (_socketWriter != null) _socketWriter.Cancel();

            _socket.Dispose();
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
            CleanupState();
            _manager.Events.Error(this, type, policy, cause);
        }

        /// <summary>
        /// The start compression.
        /// </summary>
        /// <param name="algorithm">
        /// The algorithm.
        /// </param>
        private void StartCompression(string algorithm)
        {
            _compression = Static.CompressionRegistry.GetCompression(algorithm);
            _isCompressionEnabled = true;
        }

        #endregion

        #region events

        /// <summary>
        /// The on socket connector completed.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="status">
        /// The status.
        /// </param>
        private void OnSocketConnectorCompleted(IAsyncAction action, AsyncStatus status)
        {
            if (status == AsyncStatus.Completed)
            {
                IsConnected = true;

                if (_manager.Settings.UseKeepAlive)
                {
                    // Create keepalive check
                    var cancellationTokenSource = new CancellationTokenSource();
                    Task task = Repeat.Interval(
                        TimeSpan.FromSeconds(_manager.Settings.KeepAliveTime), 
                        () => OnKeepAlive(), 
                        cancellationTokenSource.Token
                        );
                }

                // Signal that we have a connection
                _manager.Events.Connected(this);

                // Start receiving data
                SocketRead();

                _manager.State = new ConnectedState(_manager);
                _manager.State.Execute();
            }
            else if (status == AsyncStatus.Error)
            {
                ConnectionError(ErrorType.ConnectToServerFailed, ErrorPolicyType.Reconnect, action.ErrorCode.Message);
            }
        }

        /// <summary>
        /// The on socket reader completed.
        /// </summary>
        /// <param name="asyncInfo">
        /// The async info.
        /// </param>
        /// <param name="asyncStatus">
        /// The async status.
        /// </param>
        private void OnSocketReaderCompleted(IAsyncOperationWithProgress<IBuffer, uint> asyncInfo, 
            AsyncStatus asyncStatus)
        {
            if (asyncStatus == AsyncStatus.Completed)
            {
                _manager.ProcessComplete.Reset();

                IBuffer readBuffer = asyncInfo.GetResults();

                if (readBuffer.Length == 0)
                {
                    // This is not neccessarily an error, it can be just fine
                    // ConnectionError(ErrorType.ServerDisconnected, "Server sent empty package");
                    return;
                }

                // Get data
                var readBytes = new byte[readBuffer.Length];
                DataReader dataReader = DataReader.FromBuffer(readBuffer);
                dataReader.ReadBytes(readBytes);
                dataReader.DetachBuffer();

                // Check if it is a keepalive
                if (!(readBytes.Length == 1 && (readBytes[0] == 0 || readBytes[0] == ' ')))
                {
                    // Trim
                    readBytes = readBytes.TrimNull();

                    if (readBytes == null || readBytes.Length == 0)
                    {
                        ConnectionError(ErrorType.ServerDisconnected, ErrorPolicyType.Reconnect, 
                            "Server sent empty package");
                        return;
                    }

                    // Decompress
                    if (_isCompressionEnabled)
                        readBytes = _compression.Inflate(readBytes, readBytes.Length);

                    // Encode to string
                    string data = _encoding.GetString(readBytes, 0, readBytes.Length);

                    // Add to parser
#if DEBUG
                    _manager.Events.LogMessage(this, LogType.Debug, "Incoming data: {0}", data);
#endif

                    _manager.Parser.Parse(data);
                }

                _manager.ProcessComplete.Set();

                SocketRead();
            }
            else if (asyncStatus == AsyncStatus.Error)
            {
                ConnectionError(ErrorType.SocketReadInterrupted, ErrorPolicyType.Reconnect);
            }
        }

        /// <summary>
        /// The on socket writer completed.
        /// </summary>
        /// <param name="asyncInfo">
        /// The async info.
        /// </param>
        /// <param name="asyncStatus">
        /// The async status.
        /// </param>
        private void OnSocketWriterCompleted(IAsyncOperationWithProgress<uint, uint> asyncInfo, AsyncStatus asyncStatus)
        {
            if (asyncStatus == AsyncStatus.Completed)
            {
#if DEBUG
                _manager.Events.LogMessage(this, LogType.Debug, "Outgoing Message: {0}", _socketWriteMessage);
#endif
                _socketWriteMessage = string.Empty;
            }
            else if (asyncStatus == AsyncStatus.Error)
            {
                ConnectionError(ErrorType.SocketWriteInterrupted, ErrorPolicyType.Reconnect);
            }
        }

        /// <summary>
        /// The on socket elevator completed.
        /// </summary>
        /// <param name="asyncInfo">
        /// The async info.
        /// </param>
        /// <param name="asyncStatus">
        /// The async status.
        /// </param>
        private void OnSocketElevatorCompleted(IAsyncAction asyncInfo, AsyncStatus asyncStatus)
        {
            if (asyncStatus == AsyncStatus.Completed)
            {
                _elevateMutex.Set();
                SocketRead();
            }
            else if (asyncStatus == AsyncStatus.Error)
            {
                if (asyncInfo.ErrorCode.HResult == -2146762487) // Certificate invalid
                    ConnectionError(ErrorType.InvalidSslCertificate, ErrorPolicyType.Deactivate);
                else if (asyncInfo.ErrorCode.HResult == -2146762481) // CN MISMATCH 
                    ConnectionError(ErrorType.InvalidSslCertificate, ErrorPolicyType.Deactivate, 
                        "The server sent a SSL certificate with a wrong CN entry");
                else
                    ConnectionError(ErrorType.InvalidSslCertificate, ErrorPolicyType.Deactivate, 
                        asyncInfo.ErrorCode.Message);
            }
        }

        /// <summary>
        /// The on keep alive.
        /// </summary>
        private void OnKeepAlive()
        {
            Send(" ");
            Debug.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:tt") + " KeepAlive");
        }

        #endregion
    }
}