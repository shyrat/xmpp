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

namespace XMPP.Tags.Jabber.Iq.Roster
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:roster";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName Group = XName.Get("group", XmlNamespace);
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

        public string Ver
        {
            get { return (string)GetAttributeValue("ver"); }
            set { InnerElement.SetAttributeValue("ver", value); }
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public enum AskEnum
        {
            none,
            subscribe
        }

        public enum SubscriptionEnum
        {
            none,
            both,
            from,
            remove,
            to
        }

        public Item()
            : base(Namespace.Item)
        {
        }

        public Item(XElement other)
            : base(other)
        {
        }

        public string ApprovedAttr
        {
            get { return (string)GetAttributeValue("approved"); }
            set { InnerElement.SetAttributeValue("approved", value); }
        }

        public AskEnum AskAttr
        {
            get { return GetAttributeEnum<AskEnum>("ask"); }
            set { SetAttributeEnum<AskEnum>("ask", value); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
        }

        public string CompanyAttr
        {
            get { return (string)GetAttributeValue("company"); }
            set { InnerElement.SetAttributeValue("company", value); }
        }

        public SubscriptionEnum SubscriptionAttr
        {
            get { return GetAttributeEnum<SubscriptionEnum>("subscription"); }
            set { SetAttributeEnum<SubscriptionEnum>("subscription", value); }
        }

        public IEnumerable<Group> GroupElements
        {
            get { return Elements<Group>(Namespace.Group); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Group))]
    public class Group : Tag
    {
        public Group()
            : base(Namespace.Group)
        {
        }

        public Group(XElement other)
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
    targetNamespace='jabber:iq:roster'
    xmlns='jabber:iq:roster'
    elementFormDefault='qualified'>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='item'
                    minOccurs='0'
                    maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='ver'
                    type='xs:string'
                    use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='group'
                    minOccurs='0'
                    maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='approved'
                    type='xs:boolean'
                    use='optional'/>
      <xs:attribute name='ask' 
                    use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='subscribe'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='jid'
                    type='xs:string'
                    use='required'/>
      <xs:attribute name='name'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='subscription' 
                    use='optional'
                    default='none'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='both'/>
            <xs:enumeration value='from'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='remove'/>
            <xs:enumeration value='to'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='group' type='xs:string'/>

</xs:schema>

*/