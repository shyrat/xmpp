// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="oob.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.iq.oob
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:oob";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The desc.
        /// </summary>
        public static XName desc = XName.Get("desc", Name);

        /// <summary>
        /// The url.
        /// </summary>
        public static XName url = XName.Get("url", Name);
    }

    /// <summary>
    /// The query.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(query))]
    public class query : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        public query() : base(Namespace.query)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public query(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string sid
        {
            get { return (string) GetAttributeValue("sid"); }
            set { SetAttributeValue("sid", value); }
        }
    }

    /// <summary>
    /// The url.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(url))]
    public class url : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="url"/> class.
        /// </summary>
        public url() : base(Namespace.url)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="url"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public url(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The desc.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(desc))]
    public class desc : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="desc"/> class.
        /// </summary>
        public desc() : base(Namespace.desc)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="desc"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public desc(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:oob'
    xmlns='jabber:iq:oob'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0066: http://www.xmpp.org/extensions/xep-0066.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='url' type='xs:string' minOccurs='1'/>
        <xs:element name='desc' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='sid' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/