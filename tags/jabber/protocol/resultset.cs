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

namespace XMPP.Tags.Jabber.Protocol.Resultset
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/rsm";

        public static readonly XName Set = XName.Get("set", XmlNamespace);
        public static readonly XName After = XName.Get("after", XmlNamespace);
        public static readonly XName Before = XName.Get("before", XmlNamespace);
        public static readonly XName Count = XName.Get("count", XmlNamespace);
        public static readonly XName First = XName.Get("first", XmlNamespace);
        public static readonly XName Index = XName.Get("index", XmlNamespace);
        public static readonly XName Last = XName.Get("last", XmlNamespace);
        public static readonly XName Max = XName.Get("max", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Set))]
    public class Set : Tag
    {
        public Set() : base(Namespace.Set)
        {
        }

        public Set(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(After))]
    public class After : Tag
    {
        public After() : base(Namespace.After)
        {
        }

        public After(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Before))]
    public class Before : Tag
    {
        public Before() : base(Namespace.Before)
        {
        }

        public Before(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Count))]
    public class Count : Tag
    {
        public Count() : base(Namespace.Count)
        {
        }

        public Count(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(First))]
    public class First : Tag
    {
        public First() : base(Namespace.First)
        {
        }

        public First(XElement other) : base(other)
        {
        }

        public int? IndexAttr
        {
            get { return GetAttributeValueAsInt("index"); }
            set { InnerElement.SetAttributeValue("index", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Index))]
    public class Index : Tag
    {
        public Index() : base(Namespace.Index)
        {
        }

        public Index(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Last))]
    public class Last : Tag
    {
        public Last() : base(Namespace.Last)
        {
        }

        public Last(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Max))]
    public class Max : Tag
    {
        public Max() : base(Namespace.Max)
        {
        }

        public Max(XElement other) : base(other)
        {
        }

        public int Value
        {
            get { return int.Parse(InnerElement.Value); }
            set { InnerElement.Value = value.ToString(); }
        }
    }
}

/*
 * <?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/rsm'
    xmlns='http://jabber.org/protocol/rsm'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0059: http://www.xmpp.org/extensions/xep-0059.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='set'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='after' type='xs:string' minOccurs='0' maxOccurs='1'/>
        <xs:element name='before' type='xs:string' minOccurs='0' maxOccurs='1'/>
        <xs:element name='count' type='xs:int' minOccurs='0' maxOccurs='1'/>
        <xs:element ref='first' minOccurs='0' maxOccurs='1'/>
        <xs:element name='index' type='xs:int' minOccurs='0' maxOccurs='1'/>
        <xs:element name='last' type='xs:string' minOccurs='0' maxOccurs='1'/>
        <xs:element name='max' type='xs:int' minOccurs='0' maxOccurs='1'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='first'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='index' type='xs:int' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/