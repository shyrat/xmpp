using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Bookmarks
{
    public class Namespace
    {
        public const string XmlNamespace = "storage:bookmarks";

        public static readonly XName Storage = XName.Get("storage", XmlNamespace);
        public static readonly XName Conference = XName.Get("conference", XmlNamespace);
        public static readonly XName Url = XName.Get("url", XmlNamespace);
        public static readonly XName Nick = XName.Get("nick", XmlNamespace);
        public static readonly XName Password = XName.Get("password", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Storage))]
    public class Storage : Tag
    {
        public Storage()
            : base(Namespace.Storage)
        {
        }

        public Storage(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Conference> ConferenceElements
        {
            get { return Elements<Conference>(Namespace.Conference); }
        }

        public IEnumerable<Url> UrlElements
        {
            get { return Elements<Url>(Namespace.Url); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Conference))]
    public class Conference : Tag
    {
         public Conference()
            : base(Namespace.Storage)
        {
        }

         public Conference(XElement other)
            : base(other)
        {
        }

         public bool? AutojoinAttr
         {
             get { return GetAttributeValueAsBool("autojoin"); }
             set { InnerElement.SetAttributeValue("autojoin", value); }
         }

         public string JidAttr
         {
             get { return (string)GetAttributeValue("jid"); }
             set { InnerElement.SetAttributeValue("jid", value); }
         }

         public string NameAttr
         {
             get { return (string)GetAttributeValue("name"); }
             set { InnerElement.SetAttributeValue("name", value); }
         }

         public IEnumerable<Nick> NickElements
         {
             get { return Elements<Nick>(Namespace.Nick); }
         }

         public IEnumerable<Password> PasswordElements
         {
             get { return Elements<Password>(Namespace.Password); }
         }
    }

    [XmppTag(typeof(Namespace), typeof(Url))]
    public class Url : Tag
    {
        public Url()
            : base(Namespace.Storage)
        {
        }

        public Url(XElement other)
            : base(other)
        {
        }

        public string NameAttr
        {
            get { return (string)GetAttributeValue("name"); }
            set { InnerElement.SetAttributeValue("name", value); }
        }

        public string UrlAttr
        {
            get { return (string)GetAttributeValue("url"); }
            set { InnerElement.SetAttributeValue("url", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Nick))]
    public class Nick : Tag
    {
        public Nick()
            : base(Namespace.Storage)
        {
        }

        public Nick(XElement other)
            : base(other)
        {
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Password))]
    public class Password : Tag
    {
        public Password()
            : base(Namespace.Storage)
        {
        }

        public Password(XElement other)
            : base(other)
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
    targetNamespace='storage:bookmarks'
    xmlns='storage:bookmarks'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0048: http://www.xmpp.org/extensions/xep-0048.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='storage'>
    <xs:complexType>
      <xs:choice>
        <xs:element ref='conference'/>
        <xs:element ref='url'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='conference'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='nick' type='xs:string' minOccurs='0'/>
        <xs:element name='password' type='xs:string' minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='autojoin' type='xs:boolean' use='optional' default='false'/>
      <xs:attribute name='jid' type='xs:string' use='required'/>
      <xs:attribute name='name' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='url'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='name' type='xs:string' use='required'/>
          <xs:attribute name='url' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/