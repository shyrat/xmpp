// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="register.cs">
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

namespace XMPP.Tags.Jabber.iq.register
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:register";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The registered.
        /// </summary>
        public static XName registered = XName.Get("registered", Name);

        /// <summary>
        /// The instruction.
        /// </summary>
        public static XName instruction = XName.Get("instruction", Name);

        /// <summary>
        /// The username.
        /// </summary>
        public static XName username = XName.Get("username", Name);

        /// <summary>
        /// The nick.
        /// </summary>
        public static XName nick = XName.Get("nick", Name);

        /// <summary>
        /// The password.
        /// </summary>
        public static XName password = XName.Get("password", Name);

        /// <summary>
        /// The name.
        /// </summary>
        public static XName name = XName.Get("name", Name);

        /// <summary>
        /// The first.
        /// </summary>
        public static XName first = XName.Get("first", Name);

        /// <summary>
        /// The last.
        /// </summary>
        public static XName last = XName.Get("last", Name);

        /// <summary>
        /// The email.
        /// </summary>
        public static XName email = XName.Get("email", Name);

        /// <summary>
        /// The address.
        /// </summary>
        public static XName address = XName.Get("address", Name);

        /// <summary>
        /// The city.
        /// </summary>
        public static XName city = XName.Get("city", Name);

        /// <summary>
        /// The state.
        /// </summary>
        public static XName state = XName.Get("state", Name);

        /// <summary>
        /// The zip.
        /// </summary>
        public static XName zip = XName.Get("zip", Name);

        /// <summary>
        /// The phone.
        /// </summary>
        public static XName phone = XName.Get("phone", Name);

        /// <summary>
        /// The url.
        /// </summary>
        public static XName url = XName.Get("url", Name);

        /// <summary>
        /// The date.
        /// </summary>
        public static XName date = XName.Get("date", Name);

        /// <summary>
        /// The misc.
        /// </summary>
        public static XName misc = XName.Get("misc", Name);

        /// <summary>
        /// The text.
        /// </summary>
        public static XName text = XName.Get("text", Name);

        /// <summary>
        /// The key.
        /// </summary>
        public static XName key = XName.Get("key", Name);

        /// <summary>
        /// The remove.
        /// </summary>
        public static XName remove = XName.Get("remove", Name);
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
        /// Gets the registered elements.
        /// </summary>
        public IEnumerable<registered> registeredElements
        {
            get { return Elements<registered>(Namespace.registered); }
        }

        /// <summary>
        /// Gets the instruction elements.
        /// </summary>
        public IEnumerable<instruction> instructionElements
        {
            get { return Elements<instruction>(Namespace.instruction); }
        }

        /// <summary>
        /// Gets the username elements.
        /// </summary>
        public IEnumerable<username> usernameElements
        {
            get { return Elements<username>(Namespace.username); }
        }

        /// <summary>
        /// Gets the nick elements.
        /// </summary>
        public IEnumerable<nick> nickElements
        {
            get { return Elements<nick>(Namespace.nick); }
        }

        /// <summary>
        /// Gets the password elements.
        /// </summary>
        public IEnumerable<password> passwordElements
        {
            get { return Elements<password>(Namespace.password); }
        }

        /// <summary>
        /// Gets the name elements.
        /// </summary>
        public IEnumerable<name> nameElements
        {
            get { return Elements<name>(Namespace.name); }
        }

        /// <summary>
        /// Gets the first elements.
        /// </summary>
        public IEnumerable<first> firstElements
        {
            get { return Elements<first>(Namespace.first); }
        }

        /// <summary>
        /// Gets the last elements.
        /// </summary>
        public IEnumerable<last> lastElements
        {
            get { return Elements<last>(Namespace.last); }
        }

        /// <summary>
        /// Gets the email elements.
        /// </summary>
        public IEnumerable<email> emailElements
        {
            get { return Elements<email>(Namespace.email); }
        }

        /// <summary>
        /// Gets the address elements.
        /// </summary>
        public IEnumerable<address> addressElements
        {
            get { return Elements<address>(Namespace.address); }
        }

        /// <summary>
        /// Gets the city elements.
        /// </summary>
        public IEnumerable<city> cityElements
        {
            get { return Elements<city>(Namespace.city); }
        }

        /// <summary>
        /// Gets the state elements.
        /// </summary>
        public IEnumerable<state> stateElements
        {
            get { return Elements<state>(Namespace.state); }
        }

        /// <summary>
        /// Gets the zip elements.
        /// </summary>
        public IEnumerable<zip> zipElements
        {
            get { return Elements<zip>(Namespace.zip); }
        }

        /// <summary>
        /// Gets the phone elements.
        /// </summary>
        public IEnumerable<phone> phoneElements
        {
            get { return Elements<phone>(Namespace.phone); }
        }

        /// <summary>
        /// Gets the url elements.
        /// </summary>
        public IEnumerable<url> urlElements
        {
            get { return Elements<url>(Namespace.url); }
        }

        /// <summary>
        /// Gets the date elements.
        /// </summary>
        public IEnumerable<date> dateElements
        {
            get { return Elements<date>(Namespace.date); }
        }

        /// <summary>
        /// Gets the misc elements.
        /// </summary>
        public IEnumerable<misc> miscElements
        {
            get { return Elements<misc>(Namespace.misc); }
        }

        /// <summary>
        /// Gets the text elements.
        /// </summary>
        public IEnumerable<text> textElements
        {
            get { return Elements<text>(Namespace.text); }
        }

        /// <summary>
        /// Gets the key elements.
        /// </summary>
        public IEnumerable<key> keyElements
        {
            get { return Elements<key>(Namespace.key); }
        }

        /// <summary>
        /// Gets the remove elements.
        /// </summary>
        public IEnumerable<remove> removeElements
        {
            get { return Elements<remove>(Namespace.remove); }
        }
    }

    /// <summary>
    /// The registered.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(registered))]
    public class registered : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="registered"/> class.
        /// </summary>
        public registered() : base(Namespace.registered)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="registered"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public registered(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The instruction.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(instruction))]
    public class instruction : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="instruction"/> class.
        /// </summary>
        public instruction() : base(Namespace.instruction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="instruction"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public instruction(XElement other) : base(other)
        {
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
    /// The address.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(address))]
    public class address : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="address"/> class.
        /// </summary>
        public address() : base(Namespace.address)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="address"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public address(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The city.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(city))]
    public class city : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="city"/> class.
        /// </summary>
        public city() : base(Namespace.city)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="city"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public city(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The state.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(state))]
    public class state : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="state"/> class.
        /// </summary>
        public state() : base(Namespace.state)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="state"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public state(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The zip.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(zip))]
    public class zip : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="zip"/> class.
        /// </summary>
        public zip() : base(Namespace.zip)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="zip"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public zip(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The phone.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(phone))]
    public class phone : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="phone"/> class.
        /// </summary>
        public phone() : base(Namespace.phone)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="phone"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public phone(XElement other) : base(other)
        {
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
    /// The date.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(date))]
    public class date : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="date"/> class.
        /// </summary>
        public date() : base(Namespace.date)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="date"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public date(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The misc.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(misc))]
    public class misc : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="misc"/> class.
        /// </summary>
        public misc() : base(Namespace.misc)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="misc"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public misc(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The text.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(text))]
    public class text : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="text"/> class.
        /// </summary>
        public text() : base(Namespace.text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="text"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public text(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The key.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(key))]
    public class key : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="key"/> class.
        /// </summary>
        public key() : base(Namespace.key)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="key"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public key(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The remove.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(remove))]
    public class remove : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="remove"/> class.
        /// </summary>
        public remove() : base(Namespace.remove)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="remove"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public remove(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:register'
    xmlns='jabber:iq:register'
    elementFormDefault='qualified'>

  <xs:import namespace='jabber:x:data'
             schemaLocation='http://xmpp.org/schemas/x-data.xsd'/>
  <xs:import namespace='jabber:x:oob'
             schemaLocation='http://xmpp.org/schemas/x-oob.xsd'/>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0077: http://www.xmpp.org/extensions/xep-0077.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence xmlns:xdata='jabber:x:data'
                   xmlns:xoob='jabber:x:oob'>
        <xs:choice minOccurs='0'>
          <xs:sequence minOccurs='0'>
            <xs:element name='registered' type='empty' minOccurs='0'/>
            <xs:element name='instructions' type='xs:string' minOccurs='0'/>
            <xs:element name='username' type='xs:string' minOccurs='0'/>
            <xs:element name='nick' type='xs:string' minOccurs='0'/>
            <xs:element name='password' type='xs:string' minOccurs='0'/>
            <xs:element name='name' type='xs:string' minOccurs='0'/>
            <xs:element name='first' type='xs:string' minOccurs='0'/>
            <xs:element name='last' type='xs:string' minOccurs='0'/>
            <xs:element name='email' type='xs:string' minOccurs='0'/>
            <xs:element name='address' type='xs:string' minOccurs='0'/>
            <xs:element name='city' type='xs:string' minOccurs='0'/>
            <xs:element name='state' type='xs:string' minOccurs='0'/>
            <xs:element name='zip' type='xs:string' minOccurs='0'/>
            <xs:element name='phone' type='xs:string' minOccurs='0'/>
            <xs:element name='url' type='xs:string' minOccurs='0'/>
            <xs:element name='date' type='xs:string' minOccurs='0'/>
            <xs:element name='misc' type='xs:string' minOccurs='0'/>
            <xs:element name='text' type='xs:string' minOccurs='0'/>
            <xs:element name='key' type='xs:string' minOccurs='0'/>
          </xs:sequence>
          <xs:element name='remove' type='empty' minOccurs='0'/>
        </xs:choice>
        <xs:element ref='xdata:x' minOccurs='0'/>
        <xs:element ref='xoob:x' minOccurs='0'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/