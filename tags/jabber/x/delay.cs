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

namespace XMPP.Tags.Jabber.X.delay
{
    public class Namespace
    {
        public const string Name = "jabber:x:delay";

        public static readonly XName X = XName.Get("x", Name);
    }

    /// <summary>
    /// The x.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(x))]
    public class x : Tag
    {
        public x() : base(Namespace.X)
        {
        }

        public x(XElement other) : base(other)
        {
        }

        public string FromAttr
        {
            get { return (string)GetAttributeValue("from"); }
            set { InnerElement.SetAttributeValue("from", value); }
        }

        public string StampAttr
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
    targetNamespace='jabber:x:delay'
    xmlns='jabber:x:delay'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0091: http://www.xmpp.org/extensions/xep-0091.html

      NOTE: This protocol has been deprecated in favor of the 
            Delayed Delivery protocol specified in XEP-0203:
            http://www.xmpp.org/extensions/xep-0203.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
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