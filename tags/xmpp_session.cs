
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.XmppSession
{
    public class Namespace
    {
        public const string Name = "urn:ietf:params:xml:ns:xmpp-session";

        public static readonly XName Session = XName.Get("session", Name);
        public static readonly XName Required = XName.Get("required", Name);
        public static readonly XName Optional = XName.Get("optional", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Session))]
    public class Session : Tag
    {
        public Session() : base(Namespace.Session)
        {
        }

        public Session(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Required))]
    public class Required : Tag
    {
        public Required() : base(Namespace.Required)
        {
        }

        public Required(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Optional))]
    public class Optional : Tag
    {
        public Optional() : base(Namespace.Optional)
        {
        }

        public Optional(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:ietf:params:xml:ns:xmpp-session'
    xmlns='urn:ietf:params:xml:ns:xmpp-session'
    elementFormDefault='qualified'>

  <xs:element name='session' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/