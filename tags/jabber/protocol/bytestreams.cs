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

namespace XMPP.Tags.Jabber.Protocol.bytestreams
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "http://jabber.org/protocol/bytestreams";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The streamhost.
        /// </summary>
        public static XName streamhost = XName.Get("streamhost", Name);

        /// <summary>
        /// The streamhost_used.
        /// </summary>
        public static XName streamhost_used = XName.Get("streamhost-used", Name);

        /// <summary>
        /// The udpsuccess.
        /// </summary>
        public static XName udpsuccess = XName.Get("udpsuccess", Name);

        /// <summary>
        /// The activate.
        /// </summary>
        public static XName activate = XName.Get("activate", Name);
    }

    /// <summary>
    /// The query.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(query))]
    public class query : Tag
    {
        /// <summary>
        /// The mode enum.
        /// </summary>
        public enum modeEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            none, 

            /// <summary>
            /// The tcp.
            /// </summary>
            tcp, 

            /// <summary>
            /// The udp.
            /// </summary>
            udp
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        public query() : base(Namespace.query)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public query(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the streamhost.
        /// </summary>
        public streamhost streamhost
        {
            get { return Element<streamhost>(Namespace.streamhost); }
        }

        /// <summary>
        /// Gets the streamhost_used.
        /// </summary>
        public streamhost_used streamhost_used
        {
            get { return Element<streamhost_used>(Namespace.streamhost_used); }
        }

        /// <summary>
        /// Gets the activate.
        /// </summary>
        public activate activate
        {
            get { return Element<activate>(Namespace.activate); }
        }

        /// <summary>
        /// Gets or sets the dstaddr.
        /// </summary>
        public string dstaddr
        {
            get { return (string) GetAttributeValue("dstaddr"); }
            set { SetAttributeValue("dstaddr", value); }
        }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string sid
        {
            get { return (string) GetAttributeValue("sid"); }
            set { SetAttributeValue("sid", value); }
        }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        public modeEnum mode
        {
            get { return GetAttributeEnum<modeEnum>("mode"); }
            set { SetAttributeEnum<modeEnum>("mode", value); }
        }
    }

    /// <summary>
    /// The streamhost.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(streamhost))]
    public class streamhost : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="streamhost"/> class.
        /// </summary>
        public streamhost() : base(Namespace.streamhost)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="streamhost"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public streamhost(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the jid.
        /// </summary>
        public string jid
        {
            get { return (string) GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string host
        {
            get { return (string) GetAttributeValue("host"); }
            set { SetAttributeValue("host", value); }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public string port
        {
            get { return (string) GetAttributeValue("port"); }
            set { SetAttributeValue("port", value); }
        }
    }

    /// <summary>
    /// The streamhost_used.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(streamhost_used))]
    public class streamhost_used : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="streamhost_used"/> class.
        /// </summary>
        public streamhost_used() : base(Namespace.streamhost_used)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="streamhost_used"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public streamhost_used(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the jid.
        /// </summary>
        public string jid
        {
            get { return (string) GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }
    }

    /// <summary>
    /// The udpsuccess.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(udpsuccess))]
    public class udpsuccess : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="udpsuccess"/> class.
        /// </summary>
        public udpsuccess() : base(Namespace.udpsuccess)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="udpsuccess"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public udpsuccess(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the dstaddr.
        /// </summary>
        public string dstaddr
        {
            get { return (string) GetAttributeValue("dstaddr"); }
            set { SetAttributeValue("dstaddr", value); }
        }
    }

    /// <summary>
    /// The activate.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(activate))]
    public class activate : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="activate"/> class.
        /// </summary>
        public activate() : base(Namespace.activate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="activate"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public activate(XElement other) : base(other)
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