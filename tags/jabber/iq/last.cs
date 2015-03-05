using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.iq.last
{
    public class Namespace
    {
        public const string Name = "jabber:iq:last";

        public static readonly XName Query = XName.Get("query", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query()
            : base(Namespace.Query)
        {
        }

        public Query(XElement other)
            : base(other)
        {
        }

        public string Seconds
        {
            get { return (string)GetAttributeValue("seconds"); }
            set { SetAttributeValue("seconds", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:last'
    xmlns='jabber:iq:last'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0012: http://www.xmpp.org/extensions/xep-0012.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='seconds' type='xs:unsignedLong' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/