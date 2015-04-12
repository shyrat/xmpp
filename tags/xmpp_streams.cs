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

namespace XMPP.Tags.XmppStreams
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:ietf:params:xml:ns:xmpp-streams";

        public static readonly XName BadFormat = XName.Get("bad-format", XmlNamespace);
        public static readonly XName BadNamespacePrefix = XName.Get("bad-namespace-prefix", XmlNamespace);
        public static readonly XName Conflict = XName.Get("conflict", XmlNamespace);
        public static readonly XName ConnectionTimeout = XName.Get("connection-timeout", XmlNamespace);
        public static readonly XName HostGone = XName.Get("host-gone", XmlNamespace);
        public static readonly XName HostUnknown = XName.Get("host-unknown", XmlNamespace);
        public static readonly XName ImproperAddressing = XName.Get("improper-addressing", XmlNamespace);
        public static readonly XName InternalServerError = XName.Get("internal-server-error", XmlNamespace);
        public static readonly XName InvalidFrom = XName.Get("invalid-from", XmlNamespace);
        public static readonly XName InvalidId = XName.Get("invalid-id", XmlNamespace);
        public static readonly XName InvalidNamespace = XName.Get("invalid-namespace", XmlNamespace);
        public static readonly XName InvalidXml = XName.Get("invalid-xml", XmlNamespace);
        public static readonly XName NotAuthorized = XName.Get("not-authorized", XmlNamespace);
        public static readonly XName PolicyViolation = XName.Get("policy-violation", XmlNamespace);
        public static readonly XName RemoteConnectionFailed = XName.Get("remote-connection-failed", XmlNamespace);
        public static readonly XName Reset = XName.Get("reset", XmlNamespace);
        public static readonly XName ResourceConstraint = XName.Get("resource-constraint", XmlNamespace);
        public static readonly XName RestrictedXml = XName.Get("restricted-xml", XmlNamespace);
        public static readonly XName SeeOtherHost = XName.Get("see-other-host", XmlNamespace);
        public static readonly XName SystemShutdown = XName.Get("system-shutdown", XmlNamespace);
        public static readonly XName UndefinedCondition = XName.Get("undefined-condition", XmlNamespace);
        public static readonly XName UnsupportedEncoding = XName.Get("unsupported-encoding", XmlNamespace);
        public static readonly XName UnsupportedStanzaType = XName.Get("unsupported-stanza-type", XmlNamespace);
        public static readonly XName UnsupportedVersion = XName.Get("unsupported-version", XmlNamespace);
        public static readonly XName XmlNotWellFormed = XName.Get("xml-not-well-formed", XmlNamespace);
        public static readonly XName Text = XName.Get("text", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(BadFormat))]
    public class BadFormat : Tag
    {
        public BadFormat() : base(Namespace.BadFormat)
        {
        }

        public BadFormat(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(BadNamespacePrefix))]
    public class BadNamespacePrefix : Tag
    {
        public BadNamespacePrefix() : base(Namespace.BadNamespacePrefix)
        {
        }

        public BadNamespacePrefix(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Conflict))]
    public class Conflict : Tag
    {
        public Conflict() : base(Namespace.Conflict)
        {
        }

        public Conflict(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ConnectionTimeout))]
    public class ConnectionTimeout : Tag
    {
        public ConnectionTimeout() : base(Namespace.ConnectionTimeout)
        {
        }

        public ConnectionTimeout(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HostGone))]
    public class HostGone : Tag
    {
        public HostGone() : base(Namespace.HostGone)
        {
        }

        public HostGone(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(HostUnknown))]
    public class HostUnknown : Tag
    {
        public HostUnknown() : base(Namespace.HostUnknown)
        {
        }

        public HostUnknown(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ImproperAddressing))]
    public class ImproperAddressing : Tag
    {
        public ImproperAddressing() : base(Namespace.ImproperAddressing)
        {
        }

        public ImproperAddressing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InternalServerError))]
    public class InternalServerError : Tag
    {
        public InternalServerError() : base(Namespace.InternalServerError)
        {
        }

        public InternalServerError(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidFrom))]
    public class InvalidFrom : Tag
    {
        public InvalidFrom() : base(Namespace.InvalidFrom)
        {
        }

        public InvalidFrom(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidId))]
    public class InvalidId : Tag
    {
        public InvalidId() : base(Namespace.InvalidId)
        {
        }

        public InvalidId(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidNamespace))]
    public class InvalidNamespace : Tag
    {
        public InvalidNamespace() : base(Namespace.InvalidNamespace)
        {
        }

        public InvalidNamespace(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidXml))]
    public class InvalidXml : Tag
    {
        public InvalidXml() : base(Namespace.InvalidXml)
        {
        }

        public InvalidXml(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(NotAuthorized))]
    public class NotAuthorized : Tag
    {
        public NotAuthorized() : base(Namespace.NotAuthorized)
        {
        }

        public NotAuthorized(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PolicyViolation))]
    public class PolicyViolation : Tag
    {
        public PolicyViolation() : base(Namespace.PolicyViolation)
        {
        }

        public PolicyViolation(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RemoteConnectionFailed))]
    public class RemoteConnectionFailed : Tag
    {
        public RemoteConnectionFailed() : base(Namespace.RemoteConnectionFailed)
        {
        }

        public RemoteConnectionFailed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Reset))]
    public class Reset : Tag
    {
        public Reset() : base(Namespace.Reset)
        {
        }

        public Reset(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ResourceConstraint))]
    public class ResourceConstraint : Tag
    {
        public ResourceConstraint() : base(Namespace.ResourceConstraint)
        {
        }

        public ResourceConstraint(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RestrictedXml))]
    public class RestrictedXml : Tag
    {
        public RestrictedXml() : base(Namespace.RestrictedXml)
        {
        }

        public RestrictedXml(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(SeeOtherHost))]
    public class SeeOtherHost : Tag
    {
        public SeeOtherHost() : base(Namespace.SeeOtherHost)
        {
        }

        public SeeOtherHost(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(SystemShutdown))]
    public class SystemShutdown : Tag
    {
        public SystemShutdown() : base(Namespace.SystemShutdown)
        {
        }

        public SystemShutdown(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UndefinedCondition))]
    public class UndefinedCondition : Tag
    {
        public UndefinedCondition() : base(Namespace.UndefinedCondition)
        {
        }

        public UndefinedCondition(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedEncoding))]
    public class UnsupportedEncoding : Tag
    {
        public UnsupportedEncoding() : base(Namespace.UnsupportedEncoding)
        {
        }

        public UnsupportedEncoding(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedStanzaType))]
    public class UnsupportedStanzaType : Tag
    {
        public UnsupportedStanzaType() : base(Namespace.UnsupportedStanzaType)
        {
        }

        public UnsupportedStanzaType(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedVersion))]
    public class UnsupportedVersion : Tag
    {
        public UnsupportedVersion() : base(Namespace.UnsupportedVersion)
        {
        }

        public UnsupportedVersion(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(XmlNotWellFormed))]
    public class XmlNotWellFormed : Tag
    {
        public XmlNotWellFormed() : base(Namespace.XmlNotWellFormed)
        {
        }

        public XmlNotWellFormed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Text))]
    public class Text : Tag
    {
        public Text() : base(Namespace.Text)
        {
        }

        public Text(XElement other) : base(other)
        {
        }
    }
}

/*

<?xml version="1.0" encoding="UTF-8" ?> 
- <xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" targetNamespace="urn:ietf:params:xml:ns:xmpp-streams" xmlns="urn:ietf:params:xml:ns:xmpp-streams" elementFormDefault="qualified">
  <xs:import namespace="http://www.w3.org/XML/1998/namespace" schemaLocation="http://www.w3.org/2001/03/xml.xsd" /> 
  <xs:element name="bad-format" type="empty" /> 
  <xs:element name="bad-namespace-prefix" type="empty" /> 
  <xs:element name="conflict" type="empty" /> 
  <xs:element name="connection-timeout" type="empty" /> 
  <xs:element name="host-gone" type="empty" /> 
  <xs:element name="host-unknown" type="empty" /> 
  <xs:element name="improper-addressing" type="empty" /> 
  <xs:element name="internal-server-error" type="empty" /> 
  <xs:element name="invalid-from" type="empty" /> 
  <xs:element name="invalid-id" type="empty" /> 
  <xs:element name="invalid-namespace" type="empty" /> 
  <xs:element name="invalid-xml" type="empty" /> 
  <xs:element name="not-authorized" type="empty" /> 
  <xs:element name="policy-violation" type="empty" /> 
  <xs:element name="remote-connection-failed" type="empty" /> 
  <xs:element name="reset" type="empty" /> 
  <xs:element name="resource-constraint" type="empty" /> 
  <xs:element name="restricted-xml" type="empty" /> 
  <xs:element name="see-other-host" type="xs:string" /> 
  <xs:element name="system-shutdown" type="empty" /> 
  <xs:element name="undefined-condition" type="empty" /> 
  <xs:element name="unsupported-encoding" type="empty" /> 
  <xs:element name="unsupported-stanza-type" type="empty" /> 
  <xs:element name="unsupported-version" type="empty" /> 
  <xs:element name="xml-not-well-formed" type="empty" /> 
- <xs:group name="streamErrorGroup">
- <xs:choice>
  <xs:element ref="bad-format" /> 
  <xs:element ref="bad-namespace-prefix" /> 
  <xs:element ref="conflict" /> 
  <xs:element ref="connection-timeout" /> 
  <xs:element ref="host-gone" /> 
  <xs:element ref="host-unknown" /> 
  <xs:element ref="improper-addressing" /> 
  <xs:element ref="internal-server-error" /> 
  <xs:element ref="invalid-from" /> 
  <xs:element ref="invalid-id" /> 
  <xs:element ref="invalid-namespace" /> 
  <xs:element ref="invalid-xml" /> 
  <xs:element ref="not-authorized" /> 
  <xs:element ref="policy-violation" /> 
  <xs:element ref="remote-connection-failed" /> 
  <xs:element ref="reset" /> 
  <xs:element ref="resource-constraint" /> 
  <xs:element ref="restricted-xml" /> 
  <xs:element ref="see-other-host" /> 
  <xs:element ref="system-shutdown" /> 
  <xs:element ref="undefined-condition" /> 
  <xs:element ref="unsupported-encoding" /> 
  <xs:element ref="unsupported-stanza-type" /> 
  <xs:element ref="unsupported-version" /> 
  <xs:element ref="xml-not-well-formed" /> 
  </xs:choice>
  </xs:group>
- <xs:element name="text">
- <xs:complexType>
- <xs:simpleContent>
- <xs:extension base="xs:string">
  <xs:attribute ref="xml:lang" use="optional" /> 
  </xs:extension>
  </xs:simpleContent>
  </xs:complexType>
  </xs:element>
- <xs:simpleType name="empty">
- <xs:restriction base="xs:string">
  <xs:enumeration value="" /> 
  </xs:restriction>
  </xs:simpleType>
  </xs:schema>

*/