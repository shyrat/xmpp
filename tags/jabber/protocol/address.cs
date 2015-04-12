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

namespace XMPP.Tags.Jabber.Protocol.Address
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/address";

        public static readonly XName Addresses = XName.Get("addresses", XmlNamespace);
        public static readonly XName Address = XName.Get("address", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Addresses))]
    public class Addresses : Tag
    {
        public Addresses() : base(Namespace.Addresses)
        {
        }

        public Addresses(XElement other) : base(other)
        {
        }

        public IEnumerable<Address> AddressElements
        {
            get { return Elements<Address>(Namespace.Address); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Address))]
    public class Address : Tag
    {
        public enum TypeEnum
        {
            none,
            bcc,
            cc,
            noreply,
            replyroom,
            replyto,
            to
        }

        public Address() : base(Namespace.Address)
        {
        }

        public Address(XElement other)
            : base(other)
        {
        }

        public string DeliveredAttr
        {
            get { return (string)GetAttributeValue("delivered"); }
            set { InnerElement.SetAttributeValue("delivered", value); }
        }

        public string DescAttr
        {
            get { return (string)GetAttributeValue("desc"); }
            set { InnerElement.SetAttributeValue("desc", value); }
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

        public TypeEnum TypeAttr
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string UriAttr
        {
            get { return (string)GetAttributeValue("uri"); }
            set { InnerElement.SetAttributeValue("uri", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/address'
    xmlns='http://jabber.org/protocol/address'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0033: http://www.xmpp.org/extensions/xep-0033.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='addresses'>
     <xs:complexType>
        <xs:sequence>
           <xs:element ref='address'
                       minOccurs='1'
                       maxOccurs='unbounded'/>
        </xs:sequence>
     </xs:complexType>
  </xs:element>

  <xs:element name='address'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='delivered' use='optional' fixed='true'/>
          <xs:attribute name='desc' use='optional' type='xs:string'/>
          <xs:attribute name='jid' use='optional' type='xs:string'/>
          <xs:attribute name='node' use='optional' type='xs:string'/>
          <xs:attribute name='type' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='bcc'/>
                <xs:enumeration value='cc'/>
                <xs:enumeration value='noreply'/>
                <xs:enumeration value='replyroom'/>
                <xs:enumeration value='replyto'/>
                <xs:enumeration value='to'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
          <xs:attribute name='uri' use='optional' type='xs:string'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/