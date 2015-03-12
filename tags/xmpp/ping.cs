// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ping.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Ping
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:ping";

        public static readonly XName Ping = XName.Get("ping", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Ping))]
    public class Ping : Tag
    {
        public Ping() : base(Namespace.Ping)
        {
        }

        public Ping(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:ping'
    xmlns='urn:xmpp:ping'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0199: http://www.xmpp.org/extensions/xep-0199.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='ping' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/