// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="conference.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.X.Conference
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:x:conference";

        public static readonly XName X = XName.Get("x", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public X() : base(Namespace.X)
        {
        }

        public X(XElement other)
            : base(other)
        {
        }

        public string ContinueAttr
        {
            get { return (string)GetAttributeValue("continue"); }
            set { InnerElement.SetAttributeValue("continue", value); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public string PasswordAttr
        {
            get { return (string)GetAttributeValue("password"); }
            set { InnerElement.SetAttributeValue("password", value); }
        }

        public string ReasonAttr
        {
            get { return (string)GetAttributeValue("reason"); }
            set { InnerElement.SetAttributeValue("reason", value); }
        }

        public string ThreadAttr
        {
            get { return (string)GetAttributeValue("thread"); }
            set { InnerElement.SetAttributeValue("thread", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:x:conference'
    xmlns='jabber:x:conference'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0249: http://www.xmpp.org/extensions/xep-0249.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute
              name='continue'
              type='xs:boolean'
              use='optional'/>
          <xs:attribute
              name='jid'
              type='xs:string'
              use='required'/>
          <xs:attribute
              name='password'
              type='xs:string'
              use='optional'/>
          <xs:attribute
              name='reason'
              type='xs:string'
              use='optional'/>
          <xs:attribute
              name='thread'
              type='xs:string'
              use='optional'/>
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