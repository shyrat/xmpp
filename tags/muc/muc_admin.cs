using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Muc.Admin
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/muc#admin";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName Actor = XName.Get("actor", XmlNamespace);
        public static readonly XName Reason = XName.Get("reason", XmlNamespace);
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

        public IEnumerable<Item> ActorElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    public enum AffiliationEnum
    {
        admin,
        member,
        none,
        outcast,
        owner
    }

    public enum RoleEnum
    {
        moderator,
        none,
        participant,
        visitor
    }

    [XmppTag(typeof(Namespace), typeof(Actor))]
    public class Actor : Tag
    {
        public Actor()
            : base(Namespace.Actor)
        {
        }

        public Actor(XElement other)
            : base(other)
        {
        }

        public string ActorAttr
        {
            get { return (string)GetAttributeValue("actor"); }
            set { InnerElement.SetAttributeValue("actor", value); }
        }

        public string NickAttr
        {
            get { return (string)GetAttributeValue("nick"); }
            set { InnerElement.SetAttributeValue("nick", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Reason))]
    public class Reason : Tag
    {
        public Reason()
            : base(Namespace.Reason)
        {
        }

        public Reason(XElement other)
            : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
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

        public IEnumerable<Actor> ActorElements
        {
            get { return Elements<Actor>(Namespace.Actor); }
        }

        public IEnumerable<Reason> ReasonElements
        {
            get { return Elements<Reason>(Namespace.Reason); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string NickAttr
        {
            get { return (string)GetAttributeValue("nick"); }
            set { InnerElement.SetAttributeValue("nick", value); }
        }

        public AffiliationEnum AffiliationAttr
        {
            get { return GetAttributeEnum<AffiliationEnum>("affiliation"); }
            set { SetAttributeEnum<AffiliationEnum>("affiliation", value); }
        }

        public RoleEnum RoleAttr
        {
            get { return GetAttributeEnum<RoleEnum>("role"); }
            set { SetAttributeEnum<RoleEnum>("role", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/muc#admin'
    xmlns='http://jabber.org/protocol/muc#admin'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0045: http://www.xmpp.org/extensions/xep-0045.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='item' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='actor' minOccurs='0'/>
        <xs:element ref='reason' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='affiliation' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='admin'/>
            <xs:enumeration value='member'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='outcast'/>
            <xs:enumeration value='owner'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
      <xs:attribute name='nick' type='xs:string' use='optional'/>
      <xs:attribute name='role' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='moderator'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='participant'/>
            <xs:enumeration value='visitor'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='actor'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='jid' type='xs:string' use='optional'/>
          <xs:attribute name='nick' type='xs:string' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='reason' type='xs:string'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/