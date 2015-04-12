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
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.XmppBind
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:ietf:params:xml:ns:xmpp-bind";

        public static readonly XName Bind = XName.Get("bind", XmlNamespace);
        public static readonly XName Jid = XName.Get("jid", XmlNamespace);
        public static readonly XName Resource = XName.Get("resource", XmlNamespace);
        public static readonly XName Required = XName.Get("required", XmlNamespace);
        public static readonly XName Optional = XName.Get("optional", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Bind))]
    public class Bind : Tag
    {
        public Bind() : base(Namespace.Bind)
        {
        }

        public Bind(XElement other) : base(other)
        {
        }

        public Jid Jid
        {
            get { return Element<Jid>(Namespace.Jid); }
        }

        public Required Required
        {
            get { return Element<Required>(Namespace.Required); }
        }

        public Optional Optional
        {
            get { return Element<Optional>(Namespace.Optional); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Jid))]
    public class Jid : Tag
    {
        public Jid() : base(Namespace.Jid)
        {
        }

        public Jid(XElement other) : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set
            {
                if (value.Length < 8 || value.Length > 3071)
                {
                    throw new Exception("Text out of range");
                }

                InnerElement.Value = value;
            }
        }

        /*public XMPP.Jid JID
        {
            get { return new XMPP.Jid(base.Value); }
            set { base.Value = value.ToString(); }
        }*/
    }

    [XmppTag(typeof(Namespace), typeof(Resource))]
    public class Resource : Tag
    {
        public Resource() : base(Namespace.Resource)
        {
        }

        public Resource(XElement other) : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set
            {
                if (value.Length < 1 || value.Length > 1023)
                {
                    throw new Exception("Text out of range");
                }

                InnerElement.Value = value;
            }
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
    targetNamespace='urn:ietf:params:xml:ns:xmpp-bind'
    xmlns='urn:ietf:params:xml:ns:xmpp-bind'
    elementFormDefault='qualified'>

  <xs:element name='bind'>
    <xs:complexType>
      <xs:choice>
        <xs:element name='resource' type='resourceType'/>
        <xs:element name='jid' type='fullJIDType'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='fullJIDType'>
    <xs:restriction base='xs:string'>
      <xs:minLength value='8'/>
      <xs:maxLength value='3071'/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name='resourceType'>
    <xs:restriction base='xs:string'>
      <xs:minLength value='1'/>
      <xs:maxLength value='1023'/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/