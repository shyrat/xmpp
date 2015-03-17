using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Muc
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/muc";

        public static readonly XName X = XName.Get("x", XmlNamespace);
        public static readonly XName History = XName.Get("history", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public X()
            : base(Namespace.X)
        {
        }

        public X(XElement other)
            : base(other)
        {
        }

        public IEnumerable<History> HistoryElements
        {
            get { return Elements<History>(Namespace.History); }
        }

        public IEnumerable<Password> PasswordElements
        {
            get { return Elements<Password>(Namespace.Password); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(History))]
    public class History : Tag
    {
        public History()
            : base(Namespace.History)
        {
        }

        public History(XElement other)
            : base(other)
        {
        }

        public int? MaxcharsAttr
        {
            get { return GetAttributeValueAsInt("maxchars"); }
            set { InnerElement.SetAttributeValue("maxchars", value); }
        }

        public int? MaxstanzasAttr
        {
            get { return GetAttributeValueAsInt("maxstanzas"); }
            set { InnerElement.SetAttributeValue("maxstanzas", value); }
        }

        public int? SecondsAttr
        {
            get { return GetAttributeValueAsInt("seconds"); }
            set { InnerElement.SetAttributeValue("seconds", value); }
        }

        public string SinceAttr
        {
            get { return (string)GetAttributeValue("since"); }
            set { InnerElement.SetAttributeValue("since", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Password))]
    public class Password : Tag
    {
        public Password()
            : base(Namespace.Password)
        {
        }

        public Password(XElement other)
            : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/muc'
    xmlns='http://jabber.org/protocol/muc'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0045: http://www.xmpp.org/extensions/xep-0045.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='history' minOccurs='0'/>
        <xs:element name='password' type='xs:string' minOccurs='0'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='history'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='maxchars' type='xs:int' use='optional'/>
          <xs:attribute name='maxstanzas' type='xs:int' use='optional'/>
          <xs:attribute name='seconds' type='xs:int' use='optional'/>
          <xs:attribute name='since' type='xs:dateTime' use='optional'/>
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