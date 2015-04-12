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

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.DiscoXitems
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/disco#items";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query() : base(Namespace.Query)
        {
        }

        public Query(XElement other) : base(other)
        {
        }

        public string NodeAttr
        {
            get { return (string)GetAttributeValue("node"); }
            set { InnerElement.SetAttributeValue("node", value); }
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public Item() : base(Namespace.Item)
        {
        }

        public Item(XElement other) : base(other)
        {
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set
            {
                if (value.Length < 8 || value.Length > 3071)
                {
                    throw new Exception("Text out of range");
                }

                InnerElement.SetAttributeValue("jid", value);
            }
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
        }

        public string NodeAttr
        {
            get { return (string)GetAttributeValue("node"); }
            set { InnerElement.SetAttributeValue("node", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8' ?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/disco#items'
    xmlns='http://jabber.org/protocol/disco#items'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0030: http://www.xmpp.org/extensions/xep-0030.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='node' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='jid' type='fullJIDType' use='required'/>
          <xs:attribute name='name' type='xs:string' use='optional'/>
          <xs:attribute name='node' type='xs:string' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='fullJIDType'>
    <xs:restriction base='xs:string'>
      <xs:minLength value='8'/>
      <xs:maxLength value='3071'/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/