using System.Xml.Linq;
using XMPP.registries;
using XMPP.tags.jabber.client;

namespace XMPP.tags.xmpp.receipts
{
    public class Namespace
    {
        public static string Name = "urn:xmpp:receipts";
        public static XName received = XName.Get("received", Name);
        public static XName request = XName.Get("request", Name);
    }

    [XMPPTag(typeof(Namespace), typeof(received))]
    public class received : Tag
    {
        public received() : base(Namespace.received) { }
        public received(XElement other) : base(other) { }

        public string id { get { return (string)GetAttributeValue("id"); } set { SetAttributeValue("id", value); } }

        //utility
        internal static message GetReciptMessage(message toAck)
        {
            var ackMessage = new message()
            {
                to = toAck.from,
                from = toAck.to
            };

            ackMessage.Add(new received() { id = toAck.id });

            return ackMessage;
        }
    }

    [XMPPTag(typeof(Namespace), typeof(request))]
    public class request : Tag
    {
        public request() : base(Namespace.request) { }
        public request(XElement other) : base(other) { }
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