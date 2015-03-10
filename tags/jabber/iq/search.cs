using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Search
{
    public class Namespace
    {
        public const string Name = "jabber:iq:search";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName Instructions = XName.Get("instructions", Name);
        public static readonly XName First = XName.Get("first", Name);
        public static readonly XName Last = XName.Get("last", Name);
        public static readonly XName Nick = XName.Get("nick", Name);
        public static readonly XName Email = XName.Get("email", Name);
        public static readonly XName Item = XName.Get("item", Name);
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

        public Instructions Instructions
        {
            get { return Element<Instructions>(Namespace.Instructions); }
        }

        public First First
        {
            get { return Element<First>(Namespace.First); }
        }

        public Last Last
        {
            get { return Element<Last>(Namespace.Last); }
        }

        public Nick Nick
        {
            get { return Element<Nick>(Namespace.Nick); }
        }

        public Email Email
        {
            get { return Element<Email>(Namespace.Email); }
        }

        public Item Item
        {
            get { return Element<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Instructions))]
    public class Instructions : Tag
    {
        public Instructions()
            : base(Namespace.Instructions)
        {
        }

        public Instructions(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(First))]
    public class First : Tag
    {
        public First()
            : base(Namespace.First)
        {
        }

        public First(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Last))]
    public class Last : Tag
    {
        public Last()
            : base(Namespace.Last)
        {
        }

        public Last(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Nick))]
    public class Nick : Tag
    {
        public Nick()
            : base(Namespace.Nick)
        {
        }

        public Nick(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Email))]
    public class Email : Tag
    {
        public Email()
            : base(Namespace.Email)
        {
        }

        public Email(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public Item()
            : base(Namespace.Item)
        {
        }

        public Item(XElement other)
            : base(other)
        {
        }

        public string Jid
        {
            get { return (string)GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }

        public First First
        {
            get { return Element<First>(Namespace.First); }
        }

        public Last Last
        {
            get { return Element<Last>(Namespace.Last); }
        }

        public Nick Nick
        {
            get { return Element<Nick>(Namespace.Nick); }
        }

        public Email Email
        {
            get { return Element<Email>(Namespace.Email); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:search'
    xmlns='jabber:iq:search'
    elementFormDefault='qualified'>

  <xs:import namespace='jabber:x:data'
             schemaLocation='http://xmpp.org/schemas/x-data.xsd'/>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0055: http://xmpp.org/extensions/xep-0055.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:choice xmlns:xdata='jabber:x:data'>
          <xs:element name='instructions' type='xs:string' minOccurs='0'/>
          <xs:element name='first' type='xs:string' minOccurs='0'/>
          <xs:element name='last' type='xs:string' minOccurs='0'/>
          <xs:element name='nick' type='xs:string' minOccurs='0'/>
          <xs:element name='email' type='xs:string' minOccurs='0'/>
          <xs:element ref='xdata:x' minOccurs='0'/>
        </xs:choice>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:all>
        <xs:element name='first' type='xs:string'/>
        <xs:element name='last' type='xs:string'/>
        <xs:element name='nick' type='xs:string'/>
        <xs:element name='email' type='xs:string'/>
      </xs:all>
      <xs:attribute name='jid' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/