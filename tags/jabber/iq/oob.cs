using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Oob
{
    public class Namespace
    {
        public const string Name = "jabber:iq:oob";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName Desc = XName.Get("desc", Name);
        public static readonly XName Url = XName.Get("url", Name);
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

        public string SidAttr
        {
            get { return (string)GetAttributeValue("sid"); }
            set { SetAttributeValue("sid", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Url))]
    public class Url : Tag
    {
        public Url()
            : base(Namespace.Url)
        {
        }

        public Url(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Desc))]
    public class Desc : Tag
    {
        public Desc()
            : base(Namespace.Desc)
        {
        }

        public Desc(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:oob'
    xmlns='jabber:iq:oob'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0066: http://www.xmpp.org/extensions/xep-0066.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='url' type='xs:string' minOccurs='1'/>
        <xs:element name='desc' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='sid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/