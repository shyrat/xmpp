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

namespace XMPP.Tags.Muc.User
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/muc#user";

        public static readonly XName X = XName.Get("x", XmlNamespace);
        public static readonly XName Decline = XName.Get("decline", XmlNamespace);
        public static readonly XName Reason = XName.Get("reason", XmlNamespace);
        public static readonly XName Destroy = XName.Get("destroy", XmlNamespace);
        public static readonly XName Invite = XName.Get("invite", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
        public static readonly XName Status = XName.Get("status", XmlNamespace);
        public static readonly XName Actor = XName.Get("actor", XmlNamespace);
        public static readonly XName Continue = XName.Get("continue", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public X()
            : base(Namespace.X)
        {
        }

        public X(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Decline> DeclineElements
        {
            get { return Elements<Decline>(Namespace.Decline); }
        }

        public IEnumerable<Destroy> DestroyElements
        {
            get { return Elements<Destroy>(Namespace.Destroy); }
        }

        public IEnumerable<Invite> InviteElements
        {
            get { return Elements<Invite>(Namespace.Invite); }
        }

        public IEnumerable<Status> StatusElements
        {
            get { return Elements<Status>(Namespace.Status); }
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Decline))]
    public class Decline : Tag
    {
        public Decline()
            : base(Namespace.Decline)
        {
        }

        public Decline(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Reason> DeclineElements
        {
            get { return Elements<Reason>(Namespace.Reason); }
        }

        public string FromAttr
        {
            get { return (string)GetAttributeValue("from"); }
            set { InnerElement.SetAttributeValue("from", value); }
        }

        public string ToAttr
        {
            get { return (string)GetAttributeValue("to"); }
            set { InnerElement.SetAttributeValue("to", value); }
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

        public IEnumerable<Reason> DeclineElements
        {
            get { return Elements<Reason>(Namespace.Reason); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Invite))]
    public class Invite : Tag
    {
        public Invite()
            : base(Namespace.Invite)
        {
        }

        public Invite(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Reason> DeclineElements
        {
            get { return Elements<Reason>(Namespace.Reason); }
        }

        public string FromAttr
        {
            get { return (string)GetAttributeValue("from"); }
            set { InnerElement.SetAttributeValue("from", value); }
        }

        public string ToAttr
        {
            get { return (string)GetAttributeValue("to"); }
            set { InnerElement.SetAttributeValue("to", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Status))]
    public class Status : Tag
    {
        public Status()
            : base(Namespace.Status)
        {
        }

        public Status(XElement other)
            : base(other)
        {
        }

        public int? CodeAttr
        {
            get { return GetAttributeValueAsInt("code"); }
            set { InnerElement.SetAttributeValue("code", value); }
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

    [XmppTag(typeof(Namespace), typeof(Actor))]
    public class Actor : Tag
    {
        public Actor()
            : base(Namespace.Actor)
        {
        }

        public Actor(XElement other)
            : base(other)
        {
        }

        public string ActorAttr
        {
            get { return (string)GetAttributeValue("actor"); }
            set { InnerElement.SetAttributeValue("actor", value); }
        }

        public string NickAttr
        {
            get { return (string)GetAttributeValue("nick"); }
            set { InnerElement.SetAttributeValue("nick", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Continue))]
    public class Continue : Tag
    {
        public Continue()
            : base(Namespace.Continue)
        {
        }

        public Continue(XElement other)
            : base(other)
        {
        }

        public string ThreadAttr
        {
            get { return (string)GetAttributeValue("thread"); }
            set { InnerElement.SetAttributeValue("thread", value); }
        }
    }

    public enum AffiliationEnum
    {
        admin,
        member,
        none,
        outcast,
        owner
    }

    public enum RoleEnum
    {
        moderator,
        none,
        participant,
        visitor
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

        public IEnumerable<Actor> ActorElements
        {
            get { return Elements<Actor>(Namespace.Actor); }
        }

        public IEnumerable<Continue> ContinueElements
        {
            get { return Elements<Continue>(Namespace.Continue); }
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

        public string NickAttr
        {
            get { return (string)GetAttributeValue("nick"); }
            set { InnerElement.SetAttributeValue("nick", value); }
        }

        public AffiliationEnum AffiliationAttr
        {
            get { return GetAttributeEnum<AffiliationEnum>("affiliation"); }
            set { SetAttributeEnum<AffiliationEnum>("affiliation", value); }
        }

        public RoleEnum RoleAttr
        {
            get { return GetAttributeEnum<RoleEnum>("role"); }
            set { SetAttributeEnum<RoleEnum>("role", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/muc#user'
    xmlns='http://jabber.org/protocol/muc#user'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0045: http://www.xmpp.org/extensions/xep-0045.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:choice minOccurs='0' maxOccurs='unbounded'>
        <xs:element ref='decline' minOccurs='0'/>
        <xs:element ref='destroy' minOccurs='0'/>
        <xs:element ref='invite' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element name='password' type='xs:string' minOccurs='0'/>
        <xs:element ref='status' minOccurs='0' maxOccurs='unbounded'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='decline'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='reason' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='from' type='xs:string' use='optional'/>
      <xs:attribute name='to' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='destroy'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='reason' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='invite'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='reason' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='from' type='xs:string' use='optional'/>
      <xs:attribute name='to' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='actor' minOccurs='0'/>
        <xs:element ref='continue' minOccurs='0'/>
        <xs:element ref='reason' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='affiliation' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='admin'/>
            <xs:enumeration value='member'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='outcast'/>
            <xs:enumeration value='owner'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
      <xs:attribute name='nick' type='xs:string' use='optional'/>
      <xs:attribute name='role' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='moderator'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='participant'/>
            <xs:enumeration value='visitor'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='actor'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='jid' type='xs:string' use='optional'/>
          <xs:attribute name='nick' type='xs:string' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='continue'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='thread' type='xs:string' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='status'>
    <xs:complexType>
      <xs:attribute name='code' use='required'>
        <xs:simpleType>
          <xs:restriction base='xs:int'>
            <xs:minInclusive value='100'/>
            <xs:maxInclusive value='999'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='reason' type='xs:string'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/