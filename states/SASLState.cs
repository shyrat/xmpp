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

using System.Linq;
using System.Xml.Linq;
using XMPP.SASL;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class SaslState : IState
    {
        public SaslState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Processing next SASL step");
#endif
            Tag res = Manager.SaslProcessor.Step(data);
            switch (((XElement)res).Name.LocalName)
            {
                case "success":
                {
#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Success, sending start stream again");
#endif
                    Manager.IsAuthenticated = true;

                    if (Manager.Transport == Transport.Socket)
                    {
                        Manager.State = new ConnectedState(Manager);
                        Manager.State.Execute();
                    }
                    else
                    {
                        (Manager.Connection as Bosh).Restart();
                    }

                    break;
                }

                case "failure":
                {
                    var type = ErrorType.Undefined;

                    if (Manager.SaslProcessor is Md5Processor)
                        type = ErrorType.Md5AuthError;

                    if (Manager.SaslProcessor is PlainProcessor)
                        type = ErrorType.PlainAuthError;

                    if (Manager.SaslProcessor is ScramProcessor)
                        type = ErrorType.ScramAuthError;

                    if (Manager.SaslProcessor is XOAuth2Processor)
                        type = ErrorType.Oauth2AuthError;

                    string text = string.Empty;

                    var failure = data as Failure;
                    if (null != failure && failure.TextElements.Any())
                    {
                        text = failure.TextElements.First().Value;
                    }

                    Manager.Events.Error(this, type, ErrorPolicyType.Deactivate, text);

                    return;
                }

                default:
                {
                    Manager.Connection.Send(res);
                    break;
                }
            }
        }
    }
}