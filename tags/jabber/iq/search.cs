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

namespace XMPP.Tags.Jabber.Iq.Search
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:search";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Instructions = XName.Get("instructions", XmlNamespace);
        public static readonly XName First = XName.Get("first", XmlNamespace);
        public static readonly XName Last = XName.Get("last", XmlNamespace);
        public static readonly XName Nick = XName.Get("nick", XmlNamespace);
        public static readonly XName Email = XName.Get("email", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
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

        public Instructions Instructions
        {
            get { return Element<Instructions>(Namespace.Instructions); }
        }

        public First First
        {
            get { return Element<First>(Namespace.First); }
        }

        public Last Last
        {
            get { return Element<Last>(Namespace.Last); }
        }

        public Nick Nick
        {
            get { return Element<Nick>(Namespace.Nick); }
        }

        public Email Email
        {
            get { return Element<Email>(Namespace.Email); }
        }

        public Item Item
        {
            get { return Element<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Instructions))]
    public class Instructions : Tag
    {
        public Instructions()
            : base(Namespace.Instructions)
        {
        }

        public Instructions(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(First))]
    public class First : Tag
    {
        public First()
            : base(Namespace.First)
        {
        }

        public First(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Last))]
    public class Last : Tag
    {
        public Last()
            : base(Namespace.Last)
        {
        }

        public Last(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Nick))]
    public class Nick : Tag
    {
        public Nick()
            : base(Namespace.Nick)
        {
        }

        public Nick(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Email))]
    public class Email : Tag
    {
        public Email()
            : base(Namespace.Email)
        {
        }

        public Email(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public Item()
            : base(Namespace.Item)
        {
        }

        public Item(XElement other)
            : base(other)
        {
        }

        public string Jid
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public First First
        {
            get { return Element<First>(Namespace.First); }
        }

        public Last Last
        {
            get { return Element<Last>(Namespace.Last); }
        }

        public Nick Nick
        {
            get { return Element<Nick>(Namespace.Nick); }
        }

        public Email Email
        {
            get { return Element<Email>(Namespace.Email); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:search'
    xmlns='jabber:iq:search'
    elementFormDefault='qualified'>

  <xs:import namespace='jabber:x:data'
             schemaLocation='http://xmpp.org/schemas/x-data.xsd'/>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0055: http://xmpp.org/extensions/xep-0055.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:choice xmlns:xdata='jabber:x:data'>
          <xs:element name='instructions' type='xs:string' minOccurs='0'/>
          <xs:element name='first' type='xs:string' minOccurs='0'/>
          <xs:element name='last' type='xs:string' minOccurs='0'/>
          <xs:element name='nick' type='xs:string' minOccurs='0'/>
          <xs:element name='email' type='xs:string' minOccurs='0'/>
          <xs:element ref='xdata:x' minOccurs='0'/>
        </xs:choice>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:all>
        <xs:element name='first' type='xs:string'/>
        <xs:element name='last' type='xs:string'/>
        <xs:element name='nick' type='xs:string'/>
        <xs:element name='email' type='xs:string'/>
      </xs:all>
      <xs:attribute name='jid' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/