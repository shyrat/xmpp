
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.XmppTls
{
    public class Namespace
    {
        public const string Name = "urn:ietf:params:xml:ns:xmpp-tls";

        public static readonly XName StartTls = XName.Get("starttls", Name);
        public static readonly XName Proceed = XName.Get("proceed", Name);
        public static readonly XName Failure = XName.Get("failure", Name);
        public static readonly XName Required = XName.Get("required", Name);
        public static readonly XName Optional = XName.Get("optional", Name);
    }

    [XmppTag(typeof(Namespace), typeof(StartTls))]
    public class StartTls : Tag
    {
        public StartTls() : base(Namespace.StartTls)
        {
        }

        public StartTls(XElement other) : base(other)
        {
        }

        public Required Required
        {
            get { return Element<Required>(Namespace.Required); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Proceed))]
    public class Proceed : Tag
    {
        public Proceed() : base(Namespace.Proceed)
        {
        }

        public Proceed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Failure))]
    public class Failure : Tag
    {
        public Failure() : base(Namespace.Failure)
        {
        }

        public Failure(XElement other) : base(other)
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
    targetNamespace='urn:ietf:params:xml:ns:xmpp-tls'
    xmlns='urn:ietf:params:xml:ns:xmpp-tls'
    elementFormDefault='qualified'>

  <xs:element name='starttls'>
    <xs:complexType>
      <xs:choice minOccurs='0' maxOccurs='1'>
        <xs:element name='required' type='empty'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='proceed' type='empty'/>

  <xs:element name='failure' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/