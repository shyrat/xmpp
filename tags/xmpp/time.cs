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

namespace XMPP.Tags.Xmpp.Time
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:time";

        public static readonly XName Time = XName.Get("time", XmlNamespace);
        public static readonly XName Tzo = XName.Get("tzo", XmlNamespace);
        public static readonly XName Utc = XName.Get("utc", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Time))]
    public class Time : Tag
    {
        public Time() : base(Namespace.Time)
        {
        }

        public Time(XElement other) : base(other)
        {
        }

        public IEnumerable<Tzo> TzoElements
        {
            get { return Elements<Tzo>(Namespace.Tzo); }
        }

        public IEnumerable<Utc> UtcElements
        {
            get { return Elements<Utc>(Namespace.Utc); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Tzo))]
    public class Tzo : Tag
    {
        public Tzo() : base(Namespace.Tzo)
        {
        }

        public Tzo(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Utc))]
    public class Utc : Tag
    {
        public Utc() : base(Namespace.Utc)
        {
        }

        public Utc(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:time'
    xmlns='urn:xmpp:time'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0202: http://www.xmpp.org/extensions/xep-0202.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='time'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element name='tzo' type='xs:string'/>
        <xs:element name='utc' type='xs:string'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/