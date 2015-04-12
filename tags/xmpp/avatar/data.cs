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

namespace XMPP.Tags.Xmpp.Avatar.Data
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:avatar:data";

        public static readonly XName Data = XName.Get("data", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Data))]
    public class Data : Tag
    {
        public Data() : base(Namespace.Data)
        {
        }

        public Data(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:avatar:data'
    xmlns='urn:xmpp:avatar:data'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0084: http://www.xmpp.org/extensions/xep-0084.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='data' type='xs:base64Binary'/>

</xs:schema>

*/