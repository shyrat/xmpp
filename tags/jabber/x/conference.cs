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

namespace XMPP.Tags.Jabber.X.Conference
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:x:conference";

        public static readonly XName X = XName.Get("x", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public X() : base(Namespace.X)
        {
        }

        public X(XElement other)
            : base(other)
        {
        }

        public string ContinueAttr
        {
            get { return (string)GetAttributeValue("continue"); }
            set { InnerElement.SetAttributeValue("continue", value); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string PasswordAttr
        {
            get { return (string)GetAttributeValue("password"); }
            set { InnerElement.SetAttributeValue("password", value); }
        }

        public string ReasonAttr
        {
            get { return (string)GetAttributeValue("reason"); }
            set { InnerElement.SetAttributeValue("reason", value); }
        }

        public string ThreadAttr
        {
            get { return (string)GetAttributeValue("thread"); }
            set { InnerElement.SetAttributeValue("thread", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:x:conference'
    xmlns='jabber:x:conference'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0249: http://www.xmpp.org/extensions/xep-0249.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute
              name='continue'
              type='xs:boolean'
              use='optional'/>
          <xs:attribute
              name='jid'
              type='xs:string'
              use='required'/>
          <xs:attribute
              name='password'
              type='xs:string'
              use='optional'/>
          <xs:attribute
              name='reason'
              type='xs:string'
              use='optional'/>
          <xs:attribute
              name='thread'
              type='xs:string'
              use='optional'/>
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