// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ServerFeaturesState.cs">
//   
// </copyright>
// <summary>
//   The server features state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Xml.Linq;
using XMPP.Registries;
using XMPP.SASL;
using XMPP.Tags;
using XMPP.Tags.Jabber.Protocol.Compress;
using XMPP.Tags.Streams;
using XMPP.Tags.XmppSasl;
using XMPP.Tags.XmppTls;
using XMPP.Ñommon;
using Namespace = XMPP.Tags.XmppStreams.Namespace;
using Text = XMPP.Tags.XmppStreams.Text;

namespace XMPP.States
{
    public class ServerFeaturesState : IState
    {
        public ServerFeaturesState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            Features features = null;

            if (data is Stream)
            {
                var stream = data as Stream;
                if (!stream.VersionAttr.StartsWith("1."))
                {
                    Manager.Events.Error(
                        this,
                        ErrorType.XmppVersionNotSupported,
                        ErrorPolicyType.Deactivate, 
                        "Expecting stream:features from 1.x server");

                    return;
                }

                features = stream.Features;
            }
            else if (data is Error)
            {
                var error = data as Error;
                string message = string.Empty;

                if (error.HasElements)
                {
                    var text = error.Element<Text>(Namespace.Text);
                    if (text != null)
                    {
                        message = text.Value;
                    }
                    else if (error.Elements().Any())
                    {
                        XElement element = error.Elements().First();
                        if (element != null)
                            message = element.Name.LocalName;
                    }
                }

                Manager.Events.Error(this, ErrorType.ServerError, ErrorPolicyType.Reconnect, message);
                return;
            }
            else if (data is Features)
            {
                features = data as Features;
            }

            if (features != null)
            {
                if (features.StartTls != null && Manager.Settings.SSL)
                {
                    Manager.State = new StartTlsState(Manager);
                    var tls = new StartTls();
                    Manager.Connection.Send(tls);
                    return;
                }

                if (!Manager.IsAuthenticated)
                {
#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Creating SASL Processor");
#endif
                    if ((features.Mechanisms.Types & MechanismType.Xoauth2 & Manager.Settings.AuthenticationTypes) ==
                        MechanismType.Xoauth2)
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "Creating XOAUTH2 processor");
#endif
                        Manager.SaslProcessor = new XOAuth2Processor(Manager);
                    }
                    else if ((features.Mechanisms.Types & MechanismType.Scram & Manager.Settings.AuthenticationTypes) ==
                             MechanismType.Scram)
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "Creating SCRAM-SHA-1 Processor");
#endif
                        Manager.SaslProcessor = new ScramProcessor(Manager);
                    }
                    else if ((features.Mechanisms.Types & MechanismType.DigestMd5 &
                              Manager.Settings.AuthenticationTypes) == MechanismType.DigestMd5)
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "Creating DIGEST-MD5 Processor");
#endif
                        Manager.SaslProcessor = new Md5Processor(Manager);
                    }
                    else if ((features.Mechanisms.Types & MechanismType.External &
                              Manager.Settings.AuthenticationTypes) == MechanismType.External)
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "External Not Supported");
#endif
                    }
                    else if ((features.Mechanisms.Types & MechanismType.Plain &
                              Manager.Settings.AuthenticationTypes) == MechanismType.Plain)
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "Creating PLAIN SASL processor");
#endif
                        Manager.SaslProcessor = new PlainProcessor(Manager);
                    }
                    else
                    {
                        Manager.SaslProcessor = null;

                        string supported = string.Empty;
                        foreach (Mechanism element in features.Mechanisms.MechanismElements)
                        {
                            if (!string.IsNullOrEmpty(supported))
                                supported += ", ";

                            supported += element.Value;
                        }

                        Manager.Events.Error(this, ErrorType.NoSupportedAuthenticationMethod, ErrorPolicyType.Deactivate, supported);

                        return;
                    }

#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Sending auth with mechanism type");
#endif
                    Manager.State = new SaslState(Manager);

                    Manager.Connection.Send(Manager.SaslProcessor.Initialize());

                    return;
                }

                // Takes place after authentication according to XEP-0170
                if (!Manager.IsCompressed && Static.CompressionRegistry.AlgorithmsAvailable && !Manager.Settings.SSL &&
                    features.Compression != null)
                {
#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Info, "Starting compression");
#endif

                    // Do we have a stream for any of the compressions supported by the server?
                    foreach (string algorithm in
                        features.Compression.Methods.Where(Static.CompressionRegistry.SupportsAlgorithm))
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "Using {0} for compression", algorithm);
#endif
                        var c = new Compress();
                        var m = new Method { Value = Manager.CompressionAlgorithm = algorithm };

                        c.Add(m);
                        Manager.Connection.Send(c);
                        Manager.State = new CompressedState(Manager);
                        return;
                    }
                }

#if DEBUG
                Manager.Events.LogMessage(this, LogType.Debug, "Authenticated");
#endif
                Manager.State = new BindingState(Manager);
                Manager.State.Execute();
            }
        }
    }
}