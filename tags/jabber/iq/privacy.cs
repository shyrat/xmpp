// Copyright © 2006 - 2012 Dieter Lunn
// Modified 2012 Paul Freund ( freund.paul@lvl3.org )
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
// You should have received a copy of the GNU Lesser General Public License along
// with this library; if not, write to the Free Software Foundation, Inc., 59
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Privacy
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:privacy";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Active = XName.Get("active", XmlNamespace);
        public static readonly XName Default = XName.Get("default", XmlNamespace);
        public static readonly XName List = XName.Get("list", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName Iq = XName.Get("iq", XmlNamespace);
        public static readonly XName Message = XName.Get("message", XmlNamespace);
        public static readonly XName PresenceIn = XName.Get("presence-in", XmlNamespace);
        public static readonly XName PresenceOut = XName.Get("presence-out", XmlNamespace);
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

        public IEnumerable<Active> ActiveElements
        {
            get { return Elements<Active>(Namespace.Active); }
        }

        public IEnumerable<Default> DefaultElements
        {
            get { return Elements<Default>(Namespace.Default); }
        }

        public IEnumerable<List> ListElements
        {
            get { return Elements<List>(Namespace.List); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Active))]
    public class Active : Tag
    {
        public Active()
            : base(Namespace.Active)
        {
        }

        public Active(XElement other)
            : base(other)
        {
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Default))]
    public class Default : Tag
    {
        public Default()
            : base(Namespace.Default)
        {
        }

        public Default(XElement other)
            : base(other)
        {
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(List))]
    public class List : Tag
    {
        public List()
            : base(Namespace.List)
        {
        }

        public List(XElement other)
            : base(other)
        {
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
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
            allow,
            deny
        }

        public enum TypeEnum
        {
            none,
            group,
            jid,
            subscription
        }

        public Item()
            : base(Namespace.Item)
        {
        }

        public Item(XElement other)
            : base(other)
        {
        }

        public ActionEnum SecondsAttr
        {
            get { return GetAttributeEnum<ActionEnum>("action"); }
            set { SetAttributeEnum<ActionEnum>("action", value); }
        }

        public string OrderAttr
        {
            get { return (string)GetAttributeValue("order"); }
            set { InnerElement.SetAttributeValue("order", value); }
        }

        public TypeEnum TypeAttr
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string ValueAttr
        {
            get { return (string)GetAttributeValue("value"); }
            set { InnerElement.SetAttributeValue("value", value); }
        }

        public IEnumerable<Iq> IqElements
        {
            get { return Elements<Iq>(Namespace.Iq); }
        }

        public IEnumerable<Message> MessageElements
        {
            get { return Elements<Message>(Namespace.Message); }
        }

        public IEnumerable<PresenceIn> PresenceInElements
        {
            get { return Elements<PresenceIn>(Namespace.PresenceIn); }
        }

        public IEnumerable<PresenceOut> PresenceOutElements
        {
            get { return Elements<PresenceOut>(Namespace.PresenceOut); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Iq))]
    public class Iq : Tag
    {
        public Iq()
            : base(Namespace.Iq)
        {
        }

        public Iq(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Message))]
    public class Message : Tag
    {
        public Message()
            : base(Namespace.Message)
        {
        }

        public Message(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PresenceIn))]
    public class PresenceIn : Tag
    {
        public PresenceIn()
            : base(Namespace.PresenceIn)
        {
        }

        public PresenceIn(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PresenceOut))]
    public class PresenceOut : Tag
    {
        public PresenceOut()
            : base(Namespace.PresenceOut)
        {
        }

        public PresenceOut(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
  xmlns:xs='http://www.w3.org/2001/XMLSchema'
  targetNamespace='jabber:iq:privacy'
  xmlns='jabber:iq:privacy'
  elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0016: http://www.xmpp.org/extensions/xep-0016.html
    </xs:documentation>
  </xs:annotation>

<xs:element name='query'>
  <xs:complexType>
    <xs:sequence>
      <xs:element ref='active'
                  minOccurs='0'/>
      <xs:element ref='default'
                  minOccurs='0'/>
      <xs:element ref='list'
                  minOccurs='0'
                  maxOccurs='unbounded'/>
    </xs:sequence>
  </xs:complexType>
</xs:element>

<xs:element name='active'>
  <xs:complexType>
    <xs:simpleContent>
      <xs:extension base='xs:NMTOKEN'>
        <xs:attribute name='name'
                      type='xs:string'
                      use='optional'/>
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType>
</xs:element>

<xs:element name='default'>
  <xs:complexType>
    <xs:simpleContent>
      <xs:extension base='xs:NMTOKEN'>
        <xs:attribute name='name'
                      type='xs:string'
                      use='optional'/>
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType>
</xs:element>

<xs:element name='list'>
  <xs:complexType>
    <xs:sequence>
      <xs:element ref='item'
                  minOccurs='0'
                  maxOccurs='unbounded'/>
    </xs:sequence>
    <xs:attribute name='name'
                  type='xs:string'
                  use='required'/>
  </xs:complexType>
</xs:element>

<xs:element name='item'>
  <xs:complexType>
    <xs:sequence>
      <xs:element name='iq'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='message'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='presence-in'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='presence-out'
                  minOccurs='0'
                  type='empty'/>
    </xs:sequence>
    <xs:attribute name='action' use='required'>
      <xs:simpleType>
        <xs:restriction base='xs:NCName'>
          <xs:enumeration value='allow'/>
          <xs:enumeration value='deny'/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name='order'
                  type='xs:unsignedInt'
                  use='required'/>
    <xs:attribute name='type' use='optional'>
      <xs:simpleType>
        <xs:restriction base='xs:NCName'>
          <xs:enumeration value='group'/>
          <xs:enumeration value='jid'/>
          <xs:enumeration value='subscription'/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name='value'
                  type='xs:string'
                  use='optional'/>
  </xs:complexType>
</xs:element>

<xs:simpleType name='empty'>
  <xs:restriction base='xs:string'>
    <xs:enumeration value=''/>
  </xs:restriction>
</xs:simpleType>

</xs:schema>

*/