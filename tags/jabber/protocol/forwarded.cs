using System.Xml.Linq;
using XMPP.registries;

namespace XMPP.tags.jabber.protocol.forwarded
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:forward:0";
        public static XName forwarded = XName.Get("forwarded", Name);
    }

    [XMPPTag(typeof(Namespace), typeof(forwarded))]
    public class forwarded : Tag
    {
        public forwarded() : base(Namespace.forwarded) { }
        public forwarded(XElement other) : base(other) { }
    }
}
