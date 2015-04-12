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

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Caps
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/caps";

        public static readonly XName C = XName.Get("c", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(C))]
    public class C : Tag
    {
        public C() : base(Namespace.C)
        {
        }

        public C(XElement other) : base(other)
        {
        }

        public string ExtAttr
        {
            get { return (string)GetAttributeValue("ext"); }
            set { InnerElement.SetAttributeValue("ext", value); }
        }

        public string HashAttr
        {
            get { return (string)GetAttributeValue("hash"); }
            set { InnerElement.SetAttributeValue("hash", value); }
        }

        public string NodeAttr
        {
            get { return (string)GetAttributeValue("node"); }
            set { InnerElement.SetAttributeValue("node", value); }
        }

        public string VerAttr
        {
            get { return (string)GetAttributeValue("ver"); }
            set { InnerElement.SetAttributeValue("ver", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/caps'
    xmlns='http://jabber.org/protocol/caps'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0115: http://www.xmpp.org/extensions/xep-0115.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='c'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='ext' type='xs:NMTOKENS' use='optional'/>
          <xs:attribute name='hash' type='xs:NMTOKEN' use='required'/>
          <xs:attribute name='node' type='xs:string' use='required'/>
          <xs:attribute name='ver' type='xs:string' use='required'/>
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