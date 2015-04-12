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

namespace XMPP.Tags.Jabber.Protocol.Offline
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/offline";

        public static readonly XName Offline = XName.Get("offline", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
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