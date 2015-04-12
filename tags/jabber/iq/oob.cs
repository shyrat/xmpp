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

namespace XMPP.Tags.Jabber.Iq.Oob
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:oob";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Desc = XName.Get("desc", XmlNamespace);
        public static readonly XName Url = XName.Get("url", XmlNamespace);
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

        public string SidAttr
        {
            get { return (string)GetAttributeValue("sid"); }
            set { InnerElement.SetAttributeValue("sid", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Url))]
    public class Url : Tag
    {
        public Url()
            : base(Namespace.Url)
        {
        }

        public Url(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Desc))]
    public class Desc : Tag
    {
        public Desc()
            : base(Namespace.Desc)
        {
        }

        public Desc(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:oob'
    xmlns='jabber:iq:oob'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0066: http://www.xmpp.org/extensions/xep-0066.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='url' type='xs:string' minOccurs='1'/>
        <xs:element name='desc' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='sid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/