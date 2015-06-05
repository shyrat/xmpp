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
// Temple Place, Suite 330, Boston, MA 02111-1307 USA\

using System;
using XMPP.Tags;

namespace XMPP
{
    public enum LogType
    {
        Warn,
        Debug,
        Info,
        Error,
        Fatal
    }

    public enum ErrorPolicyType
    {
        Informative, // Just tell about the error
        Deactivate, // Deactivate account
        Reconnect, // Automatically handeled and turned to Deactivate if neccesary
        Severe // The application can not run like this
    }

    public enum ErrorType
    {
        None, // Default
        Undefined, // Internal
        AuthenticationFailed, // Deactivate
        XmppVersionNotSupported, // Deactivate
        NoSupportedAuthenticationMethod, // Deactivate
        InvalidXmlFragment, // Informative
        BindingToResourceFailed, // Deactivate
        Md5AuthError, // Deactivate
        Oauth2AuthError, // Deactivate
        ScramAuthError, // Deactivate
        PlainAuthError, // Deactivate
        InvalidHostName, // Deactivate
        WriteStateMismatch, // Reconnect
        ConnectToServerFailed, // Reconnect
        ServerDisconnected, // Reconnect
        SocketReadInterrupted, // Reconnect
        SocketWriteInterrupted, // Reconnect
        InvalidSslCertificate, // Deactivate
        SocketChangeFailed, // Reconnect
        MissingPassword, // Deactivate

        /// <summary>
        /// The missing host.
        /// </summary>
        MissingHost, // Deactivate

        /// <summary>
        /// The missing jid.
        /// </summary>
        MissingJID, // Deactivate

        /// <summary>
        /// The server error.
        /// </summary>
        ServerError // Reconnect
        , // External

        /// <summary>
        /// The register control channel.
        /// </summary>
        RegisterControlChannel, // Reconnect

        /// <summary>
        /// The unregister control channel.
        /// </summary>
        UnregisterControlChannel, // Reconnect

        /// <summary>
        /// The wait for push enabled.
        /// </summary>
        WaitForPushEnabled, // Reconnect

        /// <summary>
        /// The background task create.
        /// </summary>
        BackgroundTaskCreate, // Reconnect

        /// <summary>
        /// The invalid settings.
        /// </summary>
        InvalidSettings, // Deactivate

        /// <summary>
        /// The invalid jid.
        /// </summary>
        InvalidJID, // Deactivate

        /// <summary>
        /// The invalid hostname.
        /// </summary>
        InvalidHostname, // Deactivate

        /// <summary>
        /// The invalid connection id.
        /// </summary>
        InvalidConnectionId, // Deactivate

        /// <summary>
        /// The not connected.
        /// </summary>
        NotConnected, // Informative

        /// <summary>
        /// The no internet.
        /// </summary>
        NoInternet, // Informative

        /// <summary>
        /// The no hardware slots allowed.
        /// </summary>
        NoHardwareSlotsAllowed, // Deactivate

        /// <summary>
        /// The register system events.
        /// </summary>
        RegisterSystemEvents, // Severe

        /// <summary>
        /// The unregister system events.
        /// </summary>
        UnregisterSystemEvents, // Severe

        /// <summary>
        /// The request background access.
        /// </summary>
        RequestBackgroundAccess // Severe

        // ,// Server
        // Stanza_bad_request,
        // Stanza_conflict,
        // Stanza_feature_not_implemented,
        // Stanza_forbidden,
        // Stanza_gone,
        // Stanza_internal_server_error,
        // Stanza_item_not_found,
        // Stanza_jid_malformed,
        // Stanza_not_acceptable,
        // Stanza_not_authorized,
        // Stanza_not_allowed,                                   
        // Stanza_payment_required,
        // Stanza_policy_violation,
        // Stanza_recipient_unavailable,                         
        // Stanza_redirect,
        // Stanza_registration_required,
        // Stanza_remote_server_not_found,
        // Stanza_remote_server_timeout,
        // Stanza_resource_constraint,
        // Stanza_service_unavailable,
        // Stanza_subscription_required,
        // Stanza_undefined_condition,
        // Stanza_unexpected_request

        // ,// Stream
        // Stream_bad_format,
        // Stream_bad_namespace_prefix,
        // Stream_conflict,
        // Stream_connection_timeout,
        // Stream_host_gone,
        // Stream_host_unknown,
        // Stream_improper_addressing,
        // Stream_internal_server_error,
        // Stream_invalid_from,
        // Stream_invalid_id,
        // Stream_invalid_namespace,
        // Stream_invalid_xml,                                   
        // Stream_not_authorized,
        // Stream_policy_violation,
        // Stream_remote_connection_failed,
        // Stream_reset,
        // Stream_resource_constraint,
        // Stream_restricted_xml,
        // Stream_see_other_host,
        // Stream_system_shutdown,
        // Stream_undefined_condition,
        // Stream_unsupported_encoding,
        // Stream_unsupported_stanza_type,
        // Stream_unsupported_version,
        // Stream_xml_not_well_formed           
    }

    /// <summary>
    /// The chunk direction.
    /// </summary>
    public enum ChunkDirection
    {
        /// <summary>
        /// The incomming.
        /// </summary>
        Incomming,

        /// <summary>
        /// The outgoing.
        /// </summary>
        Outgoing
    }
}

namespace XMPP.Сommon
{
    /// <summary>
    /// The tag event args.
    /// </summary>
    public class TagEventArgs : EventArgs
    {
        /// <summary>
        /// The tag.
        /// </summary>
        public Tag tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagEventArgs"/> class.
        /// </summary>
        /// <param name="tag_">
        /// The tag_.
        /// </param>
        public TagEventArgs(Tag tag_)
        {
            tag = tag_;
        }
    }

    /// <summary>
    /// The log event args.
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// The message.
        /// </summary>
        public string message;

        /// <summary>
        /// The type.
        /// </summary>
        public LogType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
        /// </summary>
        /// <param name="message_">
        /// The message_.
        /// </param>
        /// <param name="type_">
        /// The type_.
        /// </param>
        public LogEventArgs(string message_, LogType type_)
        {
            message = message_;
            type = type_;
        }
    }

    /// <summary>
    /// The chunk log event args.
    /// </summary>
    public class ChunkLogEventArgs : LogEventArgs
    {
        /// <summary>
        /// The direction.
        /// </summary>
        public ChunkDirection Direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkLogEventArgs"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="direction">
        /// The direction.
        /// </param>
        public ChunkLogEventArgs(string message, ChunkDirection direction)
            : base(message, LogType.Info)
        {
            Direction = direction;
        }
    }

    /// <summary>
    /// The error event args.
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        /// <summary>
        /// The message.
        /// </summary>
        public string message;

        /// <summary>
        /// The policy.
        /// </summary>
        public ErrorPolicyType policy;

        /// <summary>
        /// The type.
        /// </summary>
        public ErrorType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
        /// </summary>
        /// <param name="message_">
        /// The message_.
        /// </param>
        /// <param name="type_">
        /// The type_.
        /// </param>
        /// <param name="policy_">
        /// The policy_.
        /// </param>
        public ErrorEventArgs(string message_, ErrorType type_, ErrorPolicyType policy_)
        {
            message = message_;
            type = type_;
            policy = policy_;
        }
    }

    /// <summary>
    /// The resource bound event args.
    /// </summary>
    public class ResourceBoundEventArgs : EventArgs
    {
        /// <summary>
        /// The jid.
        /// </summary>
        public string jid;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceBoundEventArgs"/> class.
        /// </summary>
        /// <param name="jid_">
        /// The jid_.
        /// </param>
        public ResourceBoundEventArgs(string jid_)
        {
            jid = jid_;
        }
    }

    /// <summary>
    /// The events.
    /// </summary>
    public class Events
    {
        #region internal

        #region Connect

        /// <summary>
        /// The internal connect.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void InternalConnect(object sender, EventArgs e);

        /// <summary>
        /// The on connect.
        /// </summary>
        public event InternalConnect OnConnect;

        /// <summary>
        /// The connect.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Connect(object sender, EventArgs e = default(EventArgs))
        {
            var handler = OnConnect;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Disconnect

        /// <summary>
        /// The internal disconnect.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void InternalDisconnect(object sender, EventArgs e);

        /// <summary>
        /// The on disconnect.
        /// </summary>
        public event InternalDisconnect OnDisconnect;

        /// <summary>
        /// The disconnect.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Disconnect(object sender, EventArgs e = default(EventArgs))
        {
            var handler = OnDisconnect;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Send

        /// <summary>
        /// The internal send.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void InternalSend(object sender, TagEventArgs e);

        /// <summary>
        /// The on send.
        /// </summary>
        public event InternalSend OnSend;

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public void Send(object sender, Tag tag)
        {
            Send(sender, new TagEventArgs(tag));
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Send(object sender, TagEventArgs e)
        {
            var handler = OnSend;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #endregion

        #region external

        #region NewTag

        /// <summary>
        /// The external new tag.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalNewTag(object sender, TagEventArgs e);

        /// <summary>
        /// The on new tag.
        /// </summary>
        public event ExternalNewTag OnNewTag;

        /// <summary>
        /// The new tag.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public void NewTag(object sender, Tag tag)
        {
            NewTag(sender, new TagEventArgs(tag));
        }

        /// <summary>
        /// The new tag.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void NewTag(object sender, TagEventArgs e)
        {
            var handler = OnNewTag;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Receive

        /// <summary>
        /// The external receive.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalReceive(object sender, TagEventArgs e);

        /// <summary>
        /// The on receive.
        /// </summary>
        public event ExternalReceive OnReceive;

        /// <summary>
        /// The receive.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        public void Receive(object sender, Tag tag)
        {
            Receive(sender, new TagEventArgs(tag));
        }

        /// <summary>
        /// The receive.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Receive(object sender, TagEventArgs e)
        {
            var handler = OnReceive;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Error

        /// <summary>
        /// The external error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalError(object sender, ErrorEventArgs e);

        /// <summary>
        /// The on error.
        /// </summary>
        public event ExternalError OnError;

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="policy">
        /// The policy.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public void Error(object sender, ErrorType type, ErrorPolicyType policy, string format, params object[] parameters)
        {
            Error(sender, type, policy, string.Format(format, parameters));
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="policy">
        /// The policy.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Error(object sender, ErrorType type, ErrorPolicyType policy, string message = "")
        {
            Error(sender, new ErrorEventArgs(message, type, policy));
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Error(object sender, ErrorEventArgs e)
        {
            var handler = OnError;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region LogMessage

        /// <summary>
        /// The external log message.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalLogMessage(object sender, LogEventArgs e);

        /// <summary>
        /// The on log message.
        /// </summary>
        public event ExternalLogMessage OnLogMessage;

        /// <summary>
        /// The log message.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public void LogMessage(object sender, LogType type, string format, params object[] parameters)
        {
            LogMessage(sender, type, string.Format(format, parameters));
        }

        /// <summary>
        /// The log message.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void LogMessage(object sender, LogType type, string message)
        {
            LogMessage(sender, new LogEventArgs(message, type));
        }

        /// <summary>
        /// The log message.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void LogMessage(object sender, LogEventArgs e)
        {
            var handler = OnLogMessage;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Trace stream

        /// <summary>
        /// The external chunk.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalChunk(object sender, ChunkLogEventArgs e);

        /// <summary>
        /// The on chunk.
        /// </summary>
        public event ExternalChunk OnChunk;

        /// <summary>
        /// The chunk.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Chunk(object sender, ChunkLogEventArgs e = default(ChunkLogEventArgs))
        {
            var handler = OnChunk;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Ready

        /// <summary>
        /// The external ready.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalReady(object sender, EventArgs e);

        /// <summary>
        /// The on ready.
        /// </summary>
        public event ExternalReady OnReady;

        /// <summary>
        /// The ready.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Ready(object sender, EventArgs e = default(EventArgs))
        {
            var handler = OnReady;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region ResourceBound

        /// <summary>
        /// The external resource bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalResourceBound(object sender, ResourceBoundEventArgs e);

        /// <summary>
        /// The on resource bound.
        /// </summary>
        public event ExternalResourceBound OnResourceBound;

        /// <summary>
        /// The resource bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="jid">
        /// The jid.
        /// </param>
        public void ResourceBound(object sender, string jid)
        {
            ResourceBound(this, new ResourceBoundEventArgs(jid));
        }

        /// <summary>
        /// The resource bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void ResourceBound(object sender, ResourceBoundEventArgs e)
        {
            var handler = OnResourceBound;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Connected

        /// <summary>
        /// The external connected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalConnected(object sender, EventArgs e);

        /// <summary>
        /// The on connected.
        /// </summary>
        public event ExternalConnected OnConnected;

        /// <summary>
        /// The connected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Connected(object sender, EventArgs e = default(EventArgs))
        {
            var handler = OnConnected;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #region Disconnected

        /// <summary>
        /// The external disconnected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ExternalDisconnected(object sender, EventArgs e);

        /// <summary>
        /// The on disconnected.
        /// </summary>
        public event ExternalDisconnected OnDisconnected;

        /// <summary>
        /// The disconnected.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void Disconnected(object sender, EventArgs e = default(EventArgs))
        {
            var handler = OnDisconnected;
            if (handler != null) handler(sender, e);
        }

        #endregion

        #endregion
    }
}