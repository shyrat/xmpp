// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="version.cs">
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

namespace XMPP.Tags.Jabber.iq.version
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:version";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The name.
        /// </summary>
        public static XName name = XName.Get("name", Name);

        /// <summary>
        /// The version.
        /// </summary>
        public static XName version = XName.Get("version", Name);

        /// <summary>
        /// The os.
        /// </summary>
        public static XName os = XName.Get("os", Name);
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
        /// Gets the name elements.
        /// </summary>
        public IEnumerable<name> nameElements
        {
            get { return Elements<name>(Namespace.name); }
        }

        /// <summary>
        /// Gets the version elements.
        /// </summary>
        public IEnumerable<version> versionElements
        {
            get { return Elements<version>(Namespace.version); }
        }

        /// <summary>
        /// Gets the os elements.
        /// </summary>
        public IEnumerable<os> osElements
        {
            get { return Elements<os>(Namespace.os); }
        }
    }

    /// <summary>
    /// The name.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(name))]
    public class name : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="name"/> class.
        /// </summary>
        public name() : base(Namespace.name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="name"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public name(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The version.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(version))]
    public class version : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="version"/> class.
        /// </summary>
        public version() : base(Namespace.version)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="version"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public version(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The os.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(os))]
    public class os : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="os"/> class.
        /// </summary>
        public os() : base(Namespace.os)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="os"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public os(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:version'
    xmlns='jabber:iq:version'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0092: http://www.xmpp.org/extensions/xep-0092.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element name='name' type='xs:string' minOccurs='1'/>
        <xs:element name='version' type='xs:string' minOccurs='1'/>
        <xs:element name='os' type='xs:string' minOccurs='0'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/