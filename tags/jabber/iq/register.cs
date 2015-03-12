using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Register
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:iq:register";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName Registered = XName.Get("registered", XmlNamespace);
        public static readonly XName Instruction = XName.Get("instruction", XmlNamespace);
        public static readonly XName Username = XName.Get("username", XmlNamespace);
        public static readonly XName Nick = XName.Get("nick", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
        public static readonly XName Name = XName.Get("name", XmlNamespace);
        public static readonly XName First = XName.Get("first", XmlNamespace);
        public static readonly XName Last = XName.Get("last", XmlNamespace);
        public static readonly XName Email = XName.Get("email", XmlNamespace);
        public static readonly XName Address = XName.Get("address", XmlNamespace);
        public static readonly XName City = XName.Get("city", XmlNamespace);
        public static readonly XName State = XName.Get("state", XmlNamespace);
        public static readonly XName Zip = XName.Get("zip", XmlNamespace);
        public static readonly XName Phone = XName.Get("phone", XmlNamespace);
        public static readonly XName Url = XName.Get("url", XmlNamespace);
        public static readonly XName Date = XName.Get("date", XmlNamespace);
        public static readonly XName Misc = XName.Get("misc", XmlNamespace);
        public static readonly XName Text = XName.Get("text", XmlNamespace);
        public static readonly XName Key = XName.Get("key", XmlNamespace);
        public static readonly XName Remove = XName.Get("remove", XmlNamespace);
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

        public IEnumerable<Registered> RegisteredElements
        {
            get { return Elements<Registered>(Namespace.Registered); }
        }

        public IEnumerable<Instruction> InstructionElements
        {
            get { return Elements<Instruction>(Namespace.Instruction); }
        }

        public IEnumerable<Username> UsernameElements
        {
            get { return Elements<Username>(Namespace.Username); }
        }

        public IEnumerable<Nick> NickElements
        {
            get { return Elements<Nick>(Namespace.Nick); }
        }

        public IEnumerable<Password> PasswordElements
        {
            get { return Elements<Password>(Namespace.Password); }
        }

        public IEnumerable<Name> NameElements
        {
            get { return Elements<Name>(Namespace.Name); }
        }

        public IEnumerable<First> FirstElements
        {
            get { return Elements<First>(Namespace.First); }
        }

        public IEnumerable<Last> LastElements
        {
            get { return Elements<Last>(Namespace.Last); }
        }

        public IEnumerable<Email> EmailElements
        {
            get { return Elements<Email>(Namespace.Email); }
        }

        public IEnumerable<Address> AddressElements
        {
            get { return Elements<Address>(Namespace.Address); }
        }

        public IEnumerable<City> CityElements
        {
            get { return Elements<City>(Namespace.City); }
        }

        public IEnumerable<State> StateElements
        {
            get { return Elements<State>(Namespace.State); }
        }

        public IEnumerable<Zip> ZipElements
        {
            get { return Elements<Zip>(Namespace.Zip); }
        }

        public IEnumerable<Phone> PhoneElements
        {
            get { return Elements<Phone>(Namespace.Phone); }
        }

        public IEnumerable<Url> UrlElements
        {
            get { return Elements<Url>(Namespace.Url); }
        }

        public IEnumerable<Date> DateElements
        {
            get { return Elements<Date>(Namespace.Date); }
        }

        public IEnumerable<Misc> MiscElements
        {
            get { return Elements<Misc>(Namespace.Misc); }
        }

        public IEnumerable<Text> TextElements
        {
            get { return Elements<Text>(Namespace.Text); }
        }

        public IEnumerable<Key> KeyElements
        {
            get { return Elements<Key>(Namespace.Key); }
        }

        public IEnumerable<Remove> RemoveElements
        {
            get { return Elements<Remove>(Namespace.Remove); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Registered))]
    public class Registered : Tag
    {
        public Registered()
            : base(Namespace.Registered)
        {
        }

        public Registered(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Instruction))]
    public class Instruction : Tag
    {
        public Instruction()
            : base(Namespace.Instruction)
        {
        }

        public Instruction(XElement other)
            : base(other)
        {
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

    [XmppTag(typeof(Namespace), typeof(Nick))]
    public class Nick : Tag
    {
        public Nick()
            : base(Namespace.Nick)
        {
        }

        public Nick(XElement other)
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

    [XmppTag(typeof(Namespace), typeof(Name))]
    public class Name : Tag
    {
        public Name()
            : base(Namespace.Name)
        {
        }

        public Name(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(First))]
    public class First : Tag
    {
        public First()
            : base(Namespace.First)
        {
        }

        public First(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Last))]
    public class Last : Tag
    {
        public Last()
            : base(Namespace.Last)
        {
        }

        public Last(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Email))]
    public class Email : Tag
    {
        public Email()
            : base(Namespace.Email)
        {
        }

        public Email(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Address))]
    public class Address : Tag
    {
        public Address()
            : base(Namespace.Address)
        {
        }

        public Address(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(City))]
    public class City : Tag
    {
        public City()
            : base(Namespace.City)
        {
        }

        public City(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(State))]
    public class State : Tag
    {
        public State()
            : base(Namespace.State)
        {
        }

        public State(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Zip))]
    public class Zip : Tag
    {
        public Zip()
            : base(Namespace.Zip)
        {
        }

        public Zip(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Phone))]
    public class Phone : Tag
    {
        public Phone()
            : base(Namespace.Phone)
        {
        }

        public Phone(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Url))]
    public class Url : Tag
    {
        public Url()
            : base(Namespace.Url)
        {
        }

        public Url(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Date))]
    public class Date : Tag
    {
        public Date()
            : base(Namespace.Date)
        {
        }

        public Date(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Misc))]
    public class Misc : Tag
    {
        public Misc()
            : base(Namespace.Misc)
        {
        }

        public Misc(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Text))]
    public class Text : Tag
    {
        public Text()
            : base(Namespace.Text)
        {
        }

        public Text(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Key))]
    public class Key : Tag
    {
        public Key()
            : base(Namespace.Key)
        {
        }

        public Key(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Remove))]
    public class Remove : Tag
    {
        public Remove()
            : base(Namespace.Remove)
        {
        }

        public Remove(XElement other)
            : base(other)
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