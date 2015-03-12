// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="amp.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Reatures.Amp
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/features/amp";

        public static readonly XName Amp = XName.Get("amp", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Amp))]
    public class Amp : Tag
    {
        public Amp() : base(Namespace.Amp)
        {
        }

        public Amp(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/features/amp'
    xmlns='http://jabber.org/features/amp'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0079: http://www.xmpp.org/extensions/xep-0079.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='amp' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/