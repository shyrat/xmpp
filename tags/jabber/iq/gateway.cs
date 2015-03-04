// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="gateway.cs">
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

namespace XMPP.Tags.Jabber.iq.gateway
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:gateway";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The desc.
        /// </summary>
        public static XName desc = XName.Get("desc", Name);

        /// <summary>
        /// The prompt.
        /// </summary>
        public static XName prompt = XName.Get("prompt", Name);

        /// <summary>
        /// The jid.
        /// </summary>
        public static XName jid = XName.Get("jid", Name);
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
        /// Gets the jid.
        /// </summary>
        public jid jid
        {
            get { return Element<jid>(Namespace.jid); }
        }

        /// <summary>
        /// Gets the desc elements.
        /// </summary>
        public IEnumerable<desc> descElements
        {
            get { return Elements<desc>(Namespace.desc); }
        }

        /// <summary>
        /// Gets the prompt elements.
        /// </summary>
        public IEnumerable<prompt> promptElements
        {
            get { return Elements<prompt>(Namespace.prompt); }
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

    /// <summary>
    /// The prompt.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(prompt))]
    public class prompt : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="prompt"/> class.
        /// </summary>
        public prompt() : base(Namespace.prompt)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="prompt"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public prompt(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The jid.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(jid))]
    public class jid : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="jid"/> class.
        /// </summary>
        public jid() : base(Namespace.jid)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="jid"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public jid(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:gateway'
    xmlns='jabber:iq:gateway'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0100: http://www.xmpp.org/extensions/xep-0100.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:sequence>
          <xs:element name='desc' minOccurs='0' type='xs:string'/>
          <xs:element name='prompt' type='xs:string'/>
        </xs:sequence>
        <xs:element name='jid' type='xs:string'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/