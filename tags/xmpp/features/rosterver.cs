// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="rosterver.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Features.Rosterver
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:features:rosterver";

        public static readonly XName Ver = XName.Get("ver", Name);
        public static readonly XName Required = XName.Get("required", Name);
        public static readonly XName Optional = XName.Get("optional", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Ver))]
    public class Ver : Tag
    {
        public Ver() : base(Namespace.Ver)
        {
        }

        public Ver(XElement other) : base(other)
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
    targetNamespace='urn:xmpp:features:rosterver'
    xmlns='urn:xmpp:features:rosterver'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      RFC 6121: http://tools.ietf.org/html/rfc6121
    </xs:documentation>
  </xs:annotation>

  <xs:element name='ver' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/