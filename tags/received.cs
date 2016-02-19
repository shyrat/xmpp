using System.Xml.Linq;
using XMPP.registries;

namespace XMPP.tags.jabber.features.received
{
    public class Namespace
    {
        public static string Name = "urn:xmpp:receipts";
        public static XName received = XName.Get("received", Name);
    }

    [XMPPTag(typeof(Namespace), typeof(received))]
    public class received : Tag
    {
        public received() : base(Namespace.received) { }
        public received(XElement other) : base(other) { }

        public string id { get { return (string)GetAttributeValue("id"); } set { SetAttributeValue("id", value); } }
    }
}

/* FROM http://xmpp.org/extensions/xep-0184.html

<message
    from='kingrichard@royalty.england.lit/throne'
    id='bi29sg183b4v'
    to='northumberland@shakespeare.lit/westminster'>
  <received xmlns='urn:xmpp:receipts' id='richard2-4.1.247'/>
</message>
*/