// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="offline.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Offline
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/offline";

        public static readonly XName Offline = XName.Get("offline", Name);
        public static readonly XName Item = XName.Get("item", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Offline))]
    public class Offline : Tag
    {
        public Offline() : base(Namespace.Offline)
        {
        }

        public Offline(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public enum ActionEnum
        {
            none,
            remove,
            view
        }

        public Item() : base(Namespace.Item)
        {
        }

        public Item(XElement other) : base(other)
        {
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string NodeAttr
        {
            get { return (string)GetAttributeValue("node"); }
            set { InnerElement.SetAttributeValue("node", value); }
        }

        public ActionEnum ActionAttr
        {
            get { return GetAttributeEnum<ActionEnum>("action"); }
            set { SetAttributeEnum<ActionEnum>("action", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/offline'
    xmlns='http://jabber.org/protocol/offline'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0013: http://www.xmpp.org/extensions/xep-0013.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='offline'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='item' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:attribute name='action' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='remove'/>
            <xs:enumeration value='view'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
      <xs:attribute name='node' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/