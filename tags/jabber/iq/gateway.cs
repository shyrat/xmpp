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

namespace XMPP.Tags.Jabber.Iq.Gateway
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:gateway";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Desc = XName.Get("desc", XmlNamespace);
        public static readonly XName Prompt = XName.Get("prompt", XmlNamespace);
        public static readonly XName Jid = XName.Get("jid", XmlNamespace);
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

        public Jid Jid
        {
            get { return Element<Jid>(Namespace.Jid); }
        }

        public IEnumerable<Desc> DescElements
        {
            get { return Elements<Desc>(Namespace.Desc); }
        }

        public IEnumerable<Prompt> PromptElements
        {
            get { return Elements<Prompt>(Namespace.Prompt); }
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

    [XmppTag(typeof(Namespace), typeof(Prompt))]
    public class Prompt : Tag
    {
        public Prompt()
            : base(Namespace.Prompt)
        {
        }

        public Prompt(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Jid))]
    public class Jid : Tag
    {
        public Jid()
            : base(Namespace.Jid)
        {
        }

        public Jid(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:gateway'
    xmlns='jabber:iq:gateway'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0100: http://www.xmpp.org/extensions/xep-0100.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:sequence>
          <xs:element name='desc' minOccurs='0' type='xs:string'/>
          <xs:element name='prompt' type='xs:string'/>
        </xs:sequence>
        <xs:element name='jid' type='xs:string'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/