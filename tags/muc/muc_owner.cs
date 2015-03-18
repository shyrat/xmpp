using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Muc.Owner
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/muc#owner";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Destroy = XName.Get("destroy", XmlNamespace);
        public static readonly XName Reason = XName.Get("reason", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query()
            : base(Namespace.Query)
        {
        }

        public Query(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Jabber.X.Dataforms.X> XElements
        {
            get { return Elements<Jabber.X.Dataforms.X>(Jabber.X.Dataforms.Namespace.X); }
        }

        public IEnumerable<Destroy> DestroyElements
        {
            get { return Elements<Destroy>(Namespace.Destroy); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Destroy))]
    public class Destroy : Tag
    {
        public Destroy()
            : base(Namespace.Destroy)
        {
        }

        public Destroy(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Password> PasswordElements
        {
            get { return Elements<Password>(Namespace.Password); }
        }

        public IEnumerable<Reason> ReasonElements
        {
            get { return Elements<Reason>(Namespace.Reason); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Reason))]
    public class Reason : Tag
    {
        public Reason()
            : base(Namespace.Reason)
        {
        }

        public Reason(XElement other)
            : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
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
    targetNamespace='http://jabber.org/protocol/muc#owner'
    xmlns='http://jabber.org/protocol/muc#owner'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0045: http://www.xmpp.org/extensions/xep-0045.html
    </xs:documentation>
  </xs:annotation>

  <xs:import 
      namespace='jabber:x:data'
      schemaLocation='http://www.xmpp.org/schemas/x-data.xsd'/>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice xmlns:xdata='jabber:x:data' minOccurs='0'>
        <xs:element ref='xdata:x'/>
        <xs:element ref='destroy'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='destroy'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='password' type='xs:string' minOccurs='0'/>
        <xs:element name='reason' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='jid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/