// --------------------------------------------------------------------------------------------------------------------
// <copyright file="bosh.cs" company="">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Bosh
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/httpbind";

        public const string Xmpp = "urn:xmpp:xbosh";

        public static XName body = XName.Get("body", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Body))]
    public class Body : Tag
    {
        public Body() : base(Namespace.body)
        {
        }

        public Body(XElement other) : base(other)
        {
        }

        public int? Wait
        {
            get { return GetAttributeValueAsInt("wait"); }
            set { SetAttributeValue("wait", value); }
        }

        public int? Inactivity
        {
            get { return GetAttributeValueAsInt("inactivity"); }
            set { SetAttributeValue("inactivity", value); }
        }

        public int? Polling
        {
            get { return GetAttributeValueAsInt("polling"); }
            set { SetAttributeValue("polling", value); }
        }

        public int? Requests
        {
            get { return GetAttributeValueAsInt("requests"); }
            set { SetAttributeValue("requests", value); }
        }

        public int? Hold
        {
            get { return GetAttributeValueAsInt("hold"); }
            set { SetAttributeValue("hold", value); }
        }

        public string Sid
        {
            get { return (string) GetAttributeValue("sid"); }
            set { SetAttributeValue("sid", value); }
        }

        public long? Rid
        {
            get { return GetAttributeValueAsLong("rid"); }
            set { SetAttributeValue("rid", value); }
        }

        public string From
        {
            get { return (string)GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        public string To
        {
            get { return (string)GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }

        public string Type
        {
            get { return (string)GetAttributeValue("type"); }
            set { SetAttributeValue("type", value); }
        }

        public bool? Restart
        {
            get { return GetAttributeValueAsBool(XName.Get("restart", Namespace.Xmpp)); }
            set { SetAttributeValue(XName.Get("restart", Namespace.Xmpp), value); }
        }

        public string Version
        {
            get { return (string) GetAttributeValue(XName.Get("version", Namespace.Xmpp)); }
            set { SetAttributeValue(XName.Get("version", Namespace.Xmpp), value); }
        }

        public string Lang
        {
            get { return (string) GetAttributeValue("lang"); }
            set { SetAttributeValue("lang", value); }
        }
    }
}