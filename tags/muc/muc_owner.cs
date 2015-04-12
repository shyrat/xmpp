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

namespace XMPP.Tags.Muc.Owner
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/muc#owner";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Destroy = XName.Get("destroy", XmlNamespace);
        public static readonly XName Reason = XName.Get("reason", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
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

        public IEnumerable<Jabber.X.Dataforms.X> XElements
        {
            get { return Elements<Jabber.X.Dataforms.X>(Jabber.X.Dataforms.Namespace.X); }
        }

        public IEnumerable<Destroy> DestroyElements
        {
            get { return Elements<Destroy>(Namespace.Destroy); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Destroy))]
    public class Destroy : Tag
    {
        public Destroy()
            : base(Namespace.Destroy)
        {
        }

        public Destroy(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Password> PasswordElements
        {
            get { return Elements<Password>(Namespace.Password); }
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

    [XmppTag(typeof(Namespace), typeof(Password))]
    public class Password : Tag
    {
        public Password()
            : base(Namespace.Password)
        {
        }

        public Password(XElement other)
            : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/muc#owner'
    xmlns='http://jabber.org/protocol/muc#owner'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0045: http://www.xmpp.org/extensions/xep-0045.html
    </xs:documentation>
  </xs:annotation>

  <xs:import 
      namespace='jabber:x:data'
      schemaLocation='http://www.xmpp.org/schemas/x-data.xsd'/>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice xmlns:xdata='jabber:x:data' minOccurs='0'>
        <xs:element ref='xdata:x'/>
        <xs:element ref='destroy'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='destroy'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='password' type='xs:string' minOccurs='0'/>
        <xs:element name='reason' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/