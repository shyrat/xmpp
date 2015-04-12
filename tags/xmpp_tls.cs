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

namespace XMPP.Tags.XmppTls
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:ietf:params:xml:ns:xmpp-tls";

        public static readonly XName StartTls = XName.Get("starttls", XmlNamespace);
        public static readonly XName Proceed = XName.Get("proceed", XmlNamespace);
        public static readonly XName Failure = XName.Get("failure", XmlNamespace);
        public static readonly XName Required = XName.Get("required", XmlNamespace);
        public static readonly XName Optional = XName.Get("optional", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(StartTls))]
    public class StartTls : Tag
    {
        public StartTls() : base(Namespace.StartTls)
        {
        }

        public StartTls(XElement other) : base(other)
        {
        }

        public Required Required
        {
            get { return Element<Required>(Namespace.Required); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Proceed))]
    public class Proceed : Tag
    {
        public Proceed() : base(Namespace.Proceed)
        {
        }

        public Proceed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Failure))]
    public class Failure : Tag
    {
        public Failure() : base(Namespace.Failure)
        {
        }

        public Failure(XElement other) : base(other)
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
    targetNamespace='urn:ietf:params:xml:ns:xmpp-tls'
    xmlns='urn:ietf:params:xml:ns:xmpp-tls'
    elementFormDefault='qualified'>

  <xs:element name='starttls'>
    <xs:complexType>
      <xs:choice minOccurs='0' maxOccurs='1'>
        <xs:element name='required' type='empty'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='proceed' type='empty'/>

  <xs:element name='failure' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/