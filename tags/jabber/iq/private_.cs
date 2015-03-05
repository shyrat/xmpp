using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.iq.private_
{
    public class Namespace
    {
        public const string Name = "jabber:iq:private";

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
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:private'
    xmlns='jabber:iq:private'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0049: http://www.xmpp.org/extensions/xep-0049.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:any namespace='##other'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/