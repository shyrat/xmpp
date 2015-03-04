// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="auth.cs">
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

namespace XMPP.Tags.Jabber.iq.auth
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:auth";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The username.
        /// </summary>
        public static XName username = XName.Get("username", Name);

        /// <summary>
        /// The password.
        /// </summary>
        public static XName password = XName.Get("password", Name);

        /// <summary>
        /// The digest.
        /// </summary>
        public static XName digest = XName.Get("digest", Name);

        /// <summary>
        /// The resource.
        /// </summary>
        public static XName resource = XName.Get("resource", Name);
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
        /// Gets the username elements.
        /// </summary>
        public IEnumerable<username> usernameElements
        {
            get { return Elements<username>(Namespace.username); }
        }

        /// <summary>
        /// Gets the password elements.
        /// </summary>
        public IEnumerable<password> passwordElements
        {
            get { return Elements<password>(Namespace.password); }
        }

        /// <summary>
        /// Gets the digest elements.
        /// </summary>
        public IEnumerable<digest> digestElements
        {
            get { return Elements<digest>(Namespace.digest); }
        }

        /// <summary>
        /// Gets the resource elements.
        /// </summary>
        public IEnumerable<resource> resourceElements
        {
            get { return Elements<resource>(Namespace.resource); }
        }
    }

    /// <summary>
    /// The username.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(username))]
    public class username : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="username"/> class.
        /// </summary>
        public username() : base(Namespace.username)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="username"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public username(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The password.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(password))]
    public class password : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="password"/> class.
        /// </summary>
        public password() : base(Namespace.password)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="password"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public password(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The digest.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(digest))]
    public class digest : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="digest"/> class.
        /// </summary>
        public digest() : base(Namespace.digest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="digest"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public digest(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The resource.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(resource))]
    public class resource : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="resource"/> class.
        /// </summary>
        public resource() : base(Namespace.resource)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="resource"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public resource(XElement other) : base(other)
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