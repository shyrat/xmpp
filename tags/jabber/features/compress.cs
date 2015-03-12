// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="compress.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Reatures.Compress
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/features/compress";

        public static readonly XName Compression = XName.Get("compression", XmlNamespace);
        public static readonly XName Method = XName.Get("method", XmlNamespace);
        public static readonly XName Compress = XName.Get("compress", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Compression))]
    public class Compression : Tag
    {
        public Compression() : base(Namespace.Compression)
        {
        }

        public Compression(XElement other) : base(other)
        {
        }

        public IEnumerable<Method> MethodElements
        {
            get { return Elements<Method>(Namespace.Method); }
        }

        public string[] Methods
        {
            get
            {
                var methods = new List<string>();
                foreach (Method method in MethodElements)
                    methods.Add(method.Value);

                return methods.ToArray();
            }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Method))]
    public class Method : Tag
    {
        public Method() : base(Namespace.Method)
        {
        }

        public Method(XElement other) : base(other)
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
    targetNamespace='http://jabber.org/features/compress'
    xmlns='http://jabber.org/features/compress'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0138: http://www.xmpp.org/extensions/xep-0138.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='compression'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='method' type='xs:NCName' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/