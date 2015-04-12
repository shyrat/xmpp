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
using System.Text;
using System.Xml.Linq;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Ñommon;

namespace XMPP.SASL
{
    public class XOAuth2Processor : SaslProcessor
    {
        public XOAuth2Processor(Manager manager)
            : base(manager)
        {
        }

        public override Tag Step(Tag tag)
        {
            if (((XElement)tag).Name.LocalName == "success")
            {
#if DEBUG
                Manager.Events.LogMessage(this, LogType.Debug, "Plan login successful");
#endif
            }

            return tag;
        }

        public override Tag Initialize()
        {
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Initializing XOAUTH2 Processor");
            Manager.Events.LogMessage(this, LogType.Debug, "ID User: {0}", Manager.Settings.Id);
#endif

            XNamespace auth = "http://www.google.com/talk/protocol/auth";

            var authtag = new Auth { MechanismAttr = MechanismType.Xoauth2 };
            ((XElement)authtag).Add(new XAttribute(XNamespace.Xmlns + "auth", auth));
            ((XElement)authtag).Add(new XAttribute(auth + "service", "oauth2"));

            var sb = new StringBuilder();

            sb.Append((char)0);
            sb.Append(Manager.Settings.Id);
            sb.Append((char)0);
            sb.Append(string.Empty);

            ((XElement)authtag).Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));

            return authtag;
        }
    }
}