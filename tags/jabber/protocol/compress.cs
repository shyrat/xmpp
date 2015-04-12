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

namespace XMPP.Tags.Jabber.Protocol.Compress
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/compress";

        public static readonly XName Compress = XName.Get("compress", XmlNamespace);
        public static readonly XName Method = XName.Get("method", XmlNamespace);
        public static readonly XName Compressed = XName.Get("compressed", XmlNamespace);
        public static readonly XName Failure = XName.Get("failure", XmlNamespace);
        public static readonly XName SetupFailed = XName.Get("setup-failed", XmlNamespace);
        public static readonly XName ProcessingFailed = XName.Get("processing-failed", XmlNamespace);
        public static readonly XName UnsupportedMethod = XName.Get("unsupported-method", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Compress))]
    public class Compress : Tag
    {
        public Compress() : base(Namespace.Compress)
        {
        }

        public Compress(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Method> MethodElements
        {
            get { return Elements<Method>(Namespace.Method); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Method))]
    public class Method : Tag
    {
        public Method() : base(Namespace.Method)
        {
        }

        public Method(XElement other) : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Compressed))]
    public class Compressed : Tag
    {
        public Compressed() : base(Namespace.Compressed)
        {
        }

        public Compressed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Failure))]
    public class Failure : Tag
    {
        public Failure() : base(Namespace.Failure)
        {
        }

        public Failure(XElement other) : base(other)
        {
        }

        public SetupFailed SetupFailed
        {
            get { return Element<SetupFailed>(Namespace.SetupFailed); }
        }

        public ProcessingFailed ProcessingFailed
        {
            get { return Element<ProcessingFailed>(Namespace.ProcessingFailed); }
        }

        public UnsupportedMethod UnsupportedMethod
        {
            get { return Element<UnsupportedMethod>(Namespace.UnsupportedMethod); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(SetupFailed))]
    public class SetupFailed : Tag
    {
        public SetupFailed() : base(Namespace.SetupFailed)
        {
        }

        public SetupFailed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ProcessingFailed))]
    public class ProcessingFailed : Tag
    {
        public ProcessingFailed() : base(Namespace.ProcessingFailed)
        {
        }

        public ProcessingFailed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedMethod))]
    public class UnsupportedMethod : Tag
    {
        public UnsupportedMethod() : base(Namespace.UnsupportedMethod)
        {
        }

        public UnsupportedMethod(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/compress'
    xmlns='http://jabber.org/protocol/compress'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0138: http://www.xmpp.org/extensions/xep-0138.html
    </xs:documentation>
  </xs:annotation>

  <xs:import namespace='urn:ietf:params:xml:ns:xmpp-stanzas'
             schemaLocation='http://xmpp.org/schemas/stanzaerror.xsd'/>

  <xs:element name='compress'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='method' type='xs:NCName' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='compressed' type='empty'/>

  <xs:element name='failure'>
    <xs:complexType>
      <xs:choice>
        <xs:element name='setup-failed' type='empty'/>
        <xs:element name='processing-failed' type='empty'/>
        <xs:element name='unsupported-method' type='empty'/>
        <xs:sequence xmlns:err='urn:ietf:params:xml:ns:xmpp-stanzas'>
          <xs:group ref='err:stanzaErrorGroup'/>
          <xs:element ref='err:text' minOccurs='0'/>
        </xs:sequence>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/