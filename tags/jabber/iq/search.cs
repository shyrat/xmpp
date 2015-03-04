// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="search.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.iq.search
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:search";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The instructions.
        /// </summary>
        public static XName instructions = XName.Get("instructions", Name);

        /// <summary>
        /// The first.
        /// </summary>
        public static XName first = XName.Get("first", Name);

        /// <summary>
        /// The last.
        /// </summary>
        public static XName last = XName.Get("last", Name);

        /// <summary>
        /// The nick.
        /// </summary>
        public static XName nick = XName.Get("nick", Name);

        /// <summary>
        /// The email.
        /// </summary>
        public static XName email = XName.Get("email", Name);

        /// <summary>
        /// The item.
        /// </summary>
        public static XName item = XName.Get("item", Name);
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
        /// Gets the instructions.
        /// </summary>
        public instructions instructions
        {
            get { return Element<instructions>(Namespace.instructions); }
        }

        /// <summary>
        /// Gets the first.
        /// </summary>
        public first first
        {
            get { return Element<first>(Namespace.first); }
        }

        /// <summary>
        /// Gets the last.
        /// </summary>
        public last last
        {
            get { return Element<last>(Namespace.last); }
        }

        /// <summary>
        /// Gets the nick.
        /// </summary>
        public nick nick
        {
            get { return Element<nick>(Namespace.nick); }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        public email email
        {
            get { return Element<email>(Namespace.email); }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        public item item
        {
            get { return Element<item>(Namespace.item); }
        }
    }

    /// <summary>
    /// The instructions.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(instructions))]
    public class instructions : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="instructions"/> class.
        /// </summary>
        public instructions() : base(Namespace.instructions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="instructions"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public instructions(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The first.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(first))]
    public class first : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="first"/> class.
        /// </summary>
        public first() : base(Namespace.first)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="first"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public first(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The last.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(last))]
    public class last : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="last"/> class.
        /// </summary>
        public last() : base(Namespace.last)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="last"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public last(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The nick.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(nick))]
    public class nick : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="nick"/> class.
        /// </summary>
        public nick() : base(Namespace.nick)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="nick"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public nick(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The email.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(email))]
    public class email : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="email"/> class.
        /// </summary>
        public email() : base(Namespace.email)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="email"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public email(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The item.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(item))]
    public class item : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="item"/> class.
        /// </summary>
        public item() : base(Namespace.item)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="item"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public item(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the jid.
        /// </summary>
        public string jid
        {
            get { return (string) GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }

        /// <summary>
        /// Gets the first.
        /// </summary>
        public first first
        {
            get { return Element<first>(Namespace.first); }
        }

        /// <summary>
        /// Gets the last.
        /// </summary>
        public last last
        {
            get { return Element<last>(Namespace.last); }
        }

        /// <summary>
        /// Gets the nick.
        /// </summary>
        public nick nick
        {
            get { return Element<nick>(Namespace.nick); }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        public email email
        {
            get { return Element<email>(Namespace.email); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:search'
    xmlns='jabber:iq:search'
    elementFormDefault='qualified'>

  <xs:import namespace='jabber:x:data'
             schemaLocation='http://xmpp.org/schemas/x-data.xsd'/>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0055: http://xmpp.org/extensions/xep-0055.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:choice xmlns:xdata='jabber:x:data'>
          <xs:element name='instructions' type='xs:string' minOccurs='0'/>
          <xs:element name='first' type='xs:string' minOccurs='0'/>
          <xs:element name='last' type='xs:string' minOccurs='0'/>
          <xs:element name='nick' type='xs:string' minOccurs='0'/>
          <xs:element name='email' type='xs:string' minOccurs='0'/>
          <xs:element ref='xdata:x' minOccurs='0'/>
        </xs:choice>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:all>
        <xs:element name='first' type='xs:string'/>
        <xs:element name='last' type='xs:string'/>
        <xs:element name='nick' type='xs:string'/>
        <xs:element name='email' type='xs:string'/>
      </xs:all>
      <xs:attribute name='jid' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/