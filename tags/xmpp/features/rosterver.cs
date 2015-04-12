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

namespace XMPP.Tags.Xmpp.Features.Rosterver
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:features:rosterver";

        public static readonly XName Ver = XName.Get("ver", XmlNamespace);
        public static readonly XName Required = XName.Get("required", XmlNamespace);
        public static readonly XName Optional = XName.Get("optional", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Ver))]
    public class Ver : Tag
    {
        public Ver() : base(Namespace.Ver)
        {
        }

        public Ver(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Required))]
    public class Required : Tag
    {
        public Required() : base(Namespace.Required)
        {
        }

        public Required(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Optional))]
    public class Optional : Tag
    {
        public Optional() : base(Namespace.Optional)
        {
        }

        public Optional(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:features:rosterver'
    xmlns='urn:xmpp:features:rosterver'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      RFC 6121: http://tools.ietf.org/html/rfc6121
    </xs:documentation>
  </xs:annotation>

  <xs:element name='ver' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/