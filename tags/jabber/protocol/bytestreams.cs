// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="bytestreams.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.ByteStreams
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/bytestreams";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName Streamhost = XName.Get("streamhost", Name);
        public static readonly XName StreamhostUsed = XName.Get("streamhost-used", Name);
        public static readonly XName Udpsuccess = XName.Get("udpsuccess", Name);
        public static readonly XName Activate = XName.Get("activate", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public enum ModeEnum
        {
            none,
            tcp,
            udp
        }

        public Query() : base(Namespace.Query)
        {
        }

        public Query(XElement other) : base(other)
        {
        }

        public Streamhost Streamhost
        {
            get { return Element<Streamhost>(Namespace.Streamhost); }
        }

        public StreamhostUsed StreamHostUsed
        {
            get { return Element<StreamhostUsed>(Namespace.StreamhostUsed); }
        }

        public Activate Activate
        {
            get { return Element<Activate>(Namespace.Activate); }
        }

        public string DstAddrAttr
        {
            get { return (string)GetAttributeValue("dstaddr"); }
            set { InnerElement.SetAttributeValue("dstaddr", value); }
        }

        public string SidAttr
        {
            get { return (string)GetAttributeValue("sid"); }
            set { InnerElement.SetAttributeValue("sid", value); }
        }

        public ModeEnum ModeAttr
        {
            get { return GetAttributeEnum<ModeEnum>("mode"); }
            set { SetAttributeEnum<ModeEnum>("mode", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Streamhost))]
    public class Streamhost : Tag
    {
        public Streamhost() : base(Namespace.Streamhost)
        {
        }

        public Streamhost(XElement other) : base(other)
        {
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string HostAttr
        {
            get { return (string)GetAttributeValue("host"); }
            set { InnerElement.SetAttributeValue("host", value); }
        }

        public string PortAttr
        {
            get { return (string)GetAttributeValue("port"); }
            set { InnerElement.SetAttributeValue("port", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(StreamhostUsed))]
    public class StreamhostUsed : Tag
    {
        public StreamhostUsed() : base(Namespace.StreamhostUsed)
        {
        }

        public StreamhostUsed(XElement other) : base(other)
        {
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Udpsuccess))]
    public class Udpsuccess : Tag
    {
        public Udpsuccess() : base(Namespace.Udpsuccess)
        {
        }

        public Udpsuccess(XElement other) : base(other)
        {
        }

        public string DstAddrAttr
        {
            get { return (string)GetAttributeValue("dstaddr"); }
            set { InnerElement.SetAttributeValue("dstaddr", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Activate))]
    public class Activate : Tag
    {
        public Activate() : base(Namespace.Activate)
        {
        }

        public Activate(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/bytestreams'
    xmlns='http://jabber.org/protocol/bytestreams'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0065: http://www.xmpp.org/extensions/xep-0065.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:element ref='streamhost' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='streamhost-used' minOccurs='0'/>
        <xs:element name='activate' type='xs:string' minOccurs='0'/>
      </xs:choice>
      <xs:attribute name='dstaddr' type='xs:string' use='optional'/>
      <xs:attribute name='mode' use='optional' default='tcp'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='tcp'/>
            <xs:enumeration value='udp'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='sid' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='streamhost'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='jid' type='xs:string' use='required'/>
          <xs:attribute name='host' type='xs:string' use='required'/>
          <xs:attribute name='port' type='xs:string' use='optional' default='1080'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='streamhost-used'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='jid' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='udpsuccess'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='dstaddr' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/