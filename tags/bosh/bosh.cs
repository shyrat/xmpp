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

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Bosh
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/httpbind";
        public const string Xmpp = "urn:xmpp:xbosh";

        public static readonly XName Body = XName.Get("body", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Body))]
    public class Body : Tag
    {
        public Body() : base(Namespace.Body)
        {
        }

        public Body(XElement other) : base(other)
        {
        }

        public int? WaitAttr
        {
            get { return GetAttributeValueAsInt("wait"); }
            set { InnerElement.SetAttributeValue("wait", value); }
        }

        public string VerAttr
        {
            get { return (string)GetAttributeValue("ver"); }
            set { InnerElement.SetAttributeValue("ver", value); }
        }

        public int? InactivityAttr
        {
            get { return GetAttributeValueAsInt("inactivity"); }
            set { InnerElement.SetAttributeValue("inactivity", value); }
        }

        public int? PollingAttr
        {
            get { return GetAttributeValueAsInt("polling"); }
            set { InnerElement.SetAttributeValue("polling", value); }
        }

        public int? RequestsAttr
        {
            get { return GetAttributeValueAsInt("requests"); }
            set { InnerElement.SetAttributeValue("requests", value); }
        }

        public int? HoldAttr
        {
            get { return GetAttributeValueAsInt("hold"); }
            set { InnerElement.SetAttributeValue("hold", value); }
        }

        public string SidAttr
        {
            get { return (string) GetAttributeValue("sid"); }
            set { InnerElement.SetAttributeValue("sid", value); }
        }

        public long? RidAttr
        {
            get { return GetAttributeValueAsLong("rid"); }
            set { InnerElement.SetAttributeValue("rid", value); }
        }

        public string FromAttr
        {
            get { return (string)GetAttributeValue("from"); }
            set { InnerElement.SetAttributeValue("from", value); }
        }

        public string ToAttr
        {
            get { return (string)GetAttributeValue("to"); }
            set { InnerElement.SetAttributeValue("to", value); }
        }

        public string TypeAttr
        {
            get { return (string)GetAttributeValue("type"); }
            set { InnerElement.SetAttributeValue("type", value); }
        }

        public string ConditionAttr
        {
            get { return (string)GetAttributeValue("condition"); }
            set { InnerElement.SetAttributeValue("condition", value); }
        }

        public bool? RestartAttr
        {
            get { return GetAttributeValueAsBool(XName.Get("restart", Namespace.Xmpp)); }
            set { InnerElement.SetAttributeValue(XName.Get("restart", Namespace.Xmpp), value); }
        }

        public string VersionAttr
        {
            get { return (string)GetAttributeValue(XName.Get("version", Namespace.Xmpp)); }
            set { InnerElement.SetAttributeValue(XName.Get("version", Namespace.Xmpp), value); }
        }

        public string LangAttr
        {
            get { return (string)GetAttributeValue("lang"); }
            set { InnerElement.SetAttributeValue("lang", value); }
        }
    }
}