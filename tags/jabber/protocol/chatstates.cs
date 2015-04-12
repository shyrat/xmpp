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

namespace XMPP.Tags.Jabber.Protocol.Chatstates
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/chatstates";

        public static readonly XName Active = XName.Get("active", XmlNamespace);
        public static readonly XName Composing = XName.Get("composing", XmlNamespace);
        public static readonly XName Gone = XName.Get("gone", XmlNamespace);
        public static readonly XName Inactive = XName.Get("inactive", XmlNamespace);
        public static readonly XName Paused = XName.Get("paused", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Active))]
    public class Active : Tag
    {
        public Active() : base(Namespace.Active)
        {
        }

        public Active(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Composing))]
    public class Composing : Tag
    {
        public Composing() : base(Namespace.Composing)
        {
        }

        public Composing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Gone))]
    public class Gone : Tag
    {
        public Gone() : base(Namespace.Gone)
        {
        }

        public Gone(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Inactive))]
    public class Inactive : Tag
    {
        public Inactive() : base(Namespace.Inactive)
        {
        }

        public Inactive(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Paused))]
    public class Paused : Tag
    {
        public Paused() : base(Namespace.Paused)
        {
        }

        public Paused(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/chatstates'
    xmlns='http://jabber.org/protocol/chatstates'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0085: http://www.xmpp.org/extensions/xep-0085.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='active' type='empty'/>
  <xs:element name='composing' type='empty'/>
  <xs:element name='gone' type='empty'/>
  <xs:element name='inactive' type='empty'/>
  <xs:element name='paused' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/