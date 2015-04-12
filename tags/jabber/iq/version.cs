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

namespace XMPP.Tags.Jabber.Iq.Version
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:version";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Name = XName.Get("name", XmlNamespace);
        public static readonly XName Version = XName.Get("version", XmlNamespace);
        public static readonly XName Os = XName.Get("os", XmlNamespace);
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

        public IEnumerable<Name> NameElements
        {
            get { return Elements<Name>(Namespace.Name); }
        }

        public IEnumerable<Version> VersionElements
        {
            get { return Elements<Version>(Namespace.Version); }
        }

        public IEnumerable<Os> OsElements
        {
            get { return Elements<Os>(Namespace.Os); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Name))]
    public class Name : Tag
    {
        public Name()
            : base(Namespace.Name)
        {
        }

        public Name(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Version))]
    public class Version : Tag
    {
        public Version()
            : base(Namespace.Version)
        {
        }

        public Version(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Os))]
    public class Os : Tag
    {
        public Os()
            : base(Namespace.Os)
        {
        }

        public Os(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:version'
    xmlns='jabber:iq:version'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0092: http://www.xmpp.org/extensions/xep-0092.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element name='name' type='xs:string' minOccurs='1'/>
        <xs:element name='version' type='xs:string' minOccurs='1'/>
        <xs:element name='os' type='xs:string' minOccurs='0'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/