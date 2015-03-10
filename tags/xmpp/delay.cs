// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="delay.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Delay
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:delay";

        public static readonly XName Delay = XName.Get("delay", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Delay))]
    public class Delay : Tag
    {
        public Delay() : base(Namespace.Delay)
        {
        }

        public Delay(XElement other)
            : base(other)
        {
        }

        public string From
        {
            get { return (string)GetAttributeValue("from"); }
            set { InnerElement.SetAttributeValue("from", value); }
        }

        public string Stamp
        {
            get { return (string)GetAttributeValue("stamp"); }
            set { InnerElement.SetAttributeValue("stamp", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:delay'
    xmlns='urn:xmpp:delay'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0203: http://www.xmpp.org/extensions/xep-0203.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='delay'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='from' type='xs:string' use='optional'/>
          <xs:attribute name='stamp' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/