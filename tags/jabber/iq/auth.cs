using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Auth
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:auth";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Username = XName.Get("username", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
        public static readonly XName Digest = XName.Get("digest", XmlNamespace);
        public static readonly XName Resource = XName.Get("resource", XmlNamespace);
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

        public IEnumerable<Username> UsernameElements
        {
            get { return Elements<Username>(Namespace.Username); }
        }

        public IEnumerable<Password> PasswordElements
        {
            get { return Elements<Password>(Namespace.Password); }
        }

        public IEnumerable<Digest> DigestElements
        {
            get { return Elements<Digest>(Namespace.Digest); }
        }

        public IEnumerable<Resource> ResourceElements
        {
            get { return Elements<Resource>(Namespace.Resource); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Username))]
    public class Username : Tag
    {
        public Username()
            : base(Namespace.Username)
        {
        }

        public Username(XElement other)
            : base(other)
        {
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
    }

    [XmppTag(typeof(Namespace), typeof(Digest))]
    public class Digest : Tag
    {
        public Digest()
            : base(Namespace.Digest)
        {
        }

        public Digest(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Resource))]
    public class Resource : Tag
    {
        public Resource()
            : base(Namespace.Resource)
        {
        }

        public Resource(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:auth'
    xmlns='jabber:iq:auth'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      NOTE WELL: Non-SASL Authentication via the jabber:iq:auth
      protocol has been superseded by SASL Authentication as 
      defined in RFC 3920, and is now obsolete.

      For historical purposes, the protocol documented by this 
      schema is defined in XEP-0078: 

      http://www.xmpp.org/extensions/xep-0078.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='username' type='xs:string' minOccurs='0'/>
        <xs:choice>
          <xs:element name='password' type='xs:string' minOccurs='0'/>
          <xs:element name='digest' type='xs:string' minOccurs='0'/>
        </xs:choice>
        <xs:element name='resource' type='xs:string' minOccurs='0'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/