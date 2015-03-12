// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="archive.cs">
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

namespace XMPP.Tags.Xmpp.Archive
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:archive";

        public static readonly XName Auto = XName.Get("auto", XmlNamespace);
        public static readonly XName Changed = XName.Get("changed", XmlNamespace);
        public static readonly XName Chat = XName.Get("chat", XmlNamespace);
        public static readonly XName Body = XName.Get("body", XmlNamespace);
        public static readonly XName Default = XName.Get("default", XmlNamespace);
        public static readonly XName Feature = XName.Get("feature", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName List = XName.Get("list", XmlNamespace);
        public static readonly XName Method = XName.Get("method", XmlNamespace);
        public static readonly XName Modified = XName.Get("modified", XmlNamespace);
        public static readonly XName Removed = XName.Get("removed", XmlNamespace);
        public static readonly XName Note = XName.Get("note", XmlNamespace);
        public static readonly XName Pref = XName.Get("pref", XmlNamespace);
        public static readonly XName ItemRemove = XName.Get("itemremove", XmlNamespace);
        public static readonly XName Remove = XName.Get("remove", XmlNamespace);
        public static readonly XName Retrieve = XName.Get("retrieve", XmlNamespace);
        public static readonly XName Save = XName.Get("save", XmlNamespace);
        public static readonly XName From = XName.Get("from", XmlNamespace);
        public static readonly XName Next = XName.Get("next", XmlNamespace);
        public static readonly XName Previous = XName.Get("previous", XmlNamespace);
        public static readonly XName To = XName.Get("to", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Auto))]
    public class Auto : Tag
    {
        public Auto() : base(Namespace.Auto)
        {
        }

        public Auto(XElement other) : base(other)
        {
        }

        public string SaveAttr
        {
            get { return (string)GetAttributeValue("save"); }
            set { InnerElement.SetAttributeValue("save", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Changed))]
    public class Changed : Tag
    {
        public Changed() : base(Namespace.Changed)
        {
        }

        public Changed(XElement other) : base(other)
        {
        }

        public string ExactmatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }

        public string VersionAttr
        {
            get { return (string)GetAttributeValue("version"); }
            set { InnerElement.SetAttributeValue("version", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Chat))]
    public class Chat : Tag
    {
        public Chat() : base(Namespace.Chat)
        {
        }

        public Chat(XElement other) : base(other)
        {
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string SubjectAttr
        {
            get { return (string)GetAttributeValue("subject"); }
            set { InnerElement.SetAttributeValue("subject", value); }
        }

        public string ThreadAttr
        {
            get { return (string)GetAttributeValue("thread"); }
            set { InnerElement.SetAttributeValue("thread", value); }
        }

        public string VersionAttr
        {
            get { return (string)GetAttributeValue("version"); }
            set { InnerElement.SetAttributeValue("version", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }

        public From From
        {
            get { return Element<From>(Namespace.From); }
        }

        public Next Next
        {
            get { return Element<Next>(Namespace.Next); }
        }

        public Previous Previous
        {
            get { return Element<Previous>(Namespace.Previous); }
        }

        public To To
        {
            get { return Element<To>(Namespace.To); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Body))]
    public class Body : Tag
    {
        public Body() : base(Namespace.Body)
        {
        }

        public Body(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Default))]
    public class Default : Tag
    {
        public enum OtrEnum
        {
            none,
            approve,
            concede,
            forbid,
            oppose,
            prefer,
            require
        }

        public enum SaveEnum
        {
            none,
            body,
            @false,
            message,
            stream
        }

        public Default() : base(Namespace.Default)
        {
        }

        public Default(XElement other) : base(other)
        {
        }

        public string ExpireAttr
        {
            get { return (string)GetAttributeValue("expire"); }
            set { InnerElement.SetAttributeValue("expire", value); }
        }

        public string UnsetAttr
        {
            get { return (string)GetAttributeValue("unset"); }
            set { InnerElement.SetAttributeValue("unset", value); }
        }

        public OtrEnum OtrAttr
        {
            get { return GetAttributeEnum<OtrEnum>("otr"); }
            set { SetAttributeEnum<OtrEnum>("otr", value); }
        }

        public SaveEnum SaveAttr
        {
            get { return GetAttributeEnum<SaveEnum>("save"); }
            set { SetAttributeEnum<SaveEnum>("save", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public enum OtrEnum
        {
            none,
            approve,
            concede,
            forbid,
            oppose,
            prefer,
            require
        }

        public enum SaveEnum
        {
            none,
            body,
            @false,
            message,
            stream
        }

        public Item() : base(Namespace.Item)
        {
        }

        public Item(XElement other) : base(other)
        {
        }

        public string ExactmatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string ExpireAttr
        {
            get { return (string)GetAttributeValue("expire"); }
            set { InnerElement.SetAttributeValue("expire", value); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { InnerElement.SetAttributeValue("jid", value); }
        }

        public OtrEnum OtrAttr
        {
            get { return GetAttributeEnum<OtrEnum>("otr"); }
            set { SetAttributeEnum<OtrEnum>("otr", value); }
        }

        public SaveEnum SaveAttr
        {
            get { return GetAttributeEnum<SaveEnum>("save"); }
            set { SetAttributeEnum<SaveEnum>("save", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Method))]
    public class Method : Tag
    {
        public enum UseEnum
        {
            none,
            concede,
            forbid,
            prefer
        }

        public Method() : base(Namespace.Method)
        {
        }

        public Method(XElement other) : base(other)
        {
        }

        public string TypeAttr
        {
            get { return (string)GetAttributeValue("type"); }
            set { InnerElement.SetAttributeValue("type", value); }
        }

        public UseEnum UseAttr
        {
            get { return GetAttributeEnum<UseEnum>("use"); }
            set { SetAttributeEnum<UseEnum>("use", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Modified))]
    public class Modified : Tag
    {
        public Modified() : base(Namespace.Modified)
        {
        }

        public Modified(XElement other) : base(other)
        {
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public IEnumerable<Changed> ChangedElements
        {
            get { return Elements<Changed>(Namespace.Changed); }
        }

        public IEnumerable<Removed> RemovedElements
        {
            get { return Elements<Removed>(Namespace.Removed); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Note))]
    public class Note : Tag
    {
        public Note() : base(Namespace.Note)
        {
        }

        public Note(XElement other) : base(other)
        {
        }

        public string UtcAttr
        {
            get { return (string)GetAttributeValue("utc"); }
            set { InnerElement.SetAttributeValue("utc", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Pref))]
    public class Pref : Tag
    {
        public Pref() : base(Namespace.Pref)
        {
        }

        public Pref(XElement other) : base(other)
        {
        }

        public IEnumerable<Auto> AutoElements
        {
            get { return Elements<Auto>(Namespace.Auto); }
        }

        public IEnumerable<Default> DefaultElements
        {
            get { return Elements<Default>(Namespace.Default); }
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }

        public IEnumerable<Method> MethodElements
        {
            get { return Elements<Method>(Namespace.Method); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(ItemRemove))]
    public class ItemRemove : Tag
    {
        public ItemRemove() : base(Namespace.ItemRemove)
        {
        }

        public ItemRemove(XElement other)
            : base(other)
        {
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Remove))]
    public class Remove : Tag
    {
        public Remove() : base(Namespace.Remove)
        {
        }

        public Remove(XElement other) : base(other)
        {
        }

        public string EndAttr
        {
            get { return (string)GetAttributeValue("end"); }
            set { InnerElement.SetAttributeValue("end", value); }
        }

        public string ExactMatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string OpenAttr
        {
            get { return (string)GetAttributeValue("open"); }
            set { InnerElement.SetAttributeValue("open", value); }
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Removed))]
    public class Removed : Tag
    {
        public Removed() : base(Namespace.Removed)
        {
        }

        public Removed(XElement other) : base(other)
        {
        }

        public string ExactMatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }

        public string VersionAttr
        {
            get { return (string)GetAttributeValue("version"); }
            set { InnerElement.SetAttributeValue("version", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Retrieve))]
    public class Retrieve : Tag
    {
        public Retrieve() : base(Namespace.Retrieve)
        {
        }

        public Retrieve(XElement other) : base(other)
        {
        }

        public string ExactMatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Save))]
    public class Save : Tag
    {
        public Save() : base(Namespace.Save)
        {
        }

        public Save(XElement other) : base(other)
        {
        }

        public Chat Chat
        {
            get { return Element<Chat>(Namespace.Chat); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(From))]
    public class From : Tag
    {
        public From() : base(Namespace.From)
        {
        }

        public From(XElement other) : base(other)
        {
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

        public string SecsAttr
        {
            get { return (string)GetAttributeValue("secs"); }
            set { InnerElement.SetAttributeValue("secs", value); }
        }

        public string UtcAttr
        {
            get { return (string)GetAttributeValue("utc"); }
            set { InnerElement.SetAttributeValue("utc", value); }
        }

        public IEnumerable<Body> BodyElements
        {
            get { return Elements<Body>(Namespace.Body); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Next))]
    public class Next : Tag
    {
        public Next() : base(Namespace.Next)
        {
        }

        public Next(XElement other) : base(other)
        {
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Previous))]
    public class Previous : Tag
    {
        public Previous() : base(Namespace.Previous)
        {
        }

        public Previous(XElement other) : base(other)
        {
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(To))]
    public class To : Tag
    {
        public To() : base(Namespace.To)
        {
        }

        public To(XElement other) : base(other)
        {
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

        public string SecsAttr
        {
            get { return (string)GetAttributeValue("secs"); }
            set { InnerElement.SetAttributeValue("secs", value); }
        }

        public string UtcAttr
        {
            get { return (string)GetAttributeValue("utc"); }
            set { InnerElement.SetAttributeValue("utc", value); }
        }

        public IEnumerable<Body> BodyElements
        {
            get { return Elements<Body>(Namespace.Body); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:archive'
    xmlns='urn:xmpp:archive'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0136: http://www.xmpp.org/extensions/xep-0136.html
    </xs:documentation>
  </xs:annotation>

  <xs:annotation>
    <xs:documentation>
      The allowable root elements for the namespace defined
      herein are:
        - auto
        - chat
        - itemremove
        - list
        - modified
        - pref
        - remove
        - retrieve
        - save
    </xs:documentation>
  </xs:annotation>

  <xs:element name='auto'>
    <xs:complexType>
      <xs:sequence>
        <xs:any processContents='lax' namespace='##other' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='save' type='xs:boolean' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='changed'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
          <xs:attribute name='start' type='xs:dateTime' use='required'/>
          <xs:attribute name='with' type='xs:string' use='required'/>
          <xs:attribute name='version' type='xs:nonNegativeInteger' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='chat'>
    <xs:complexType>
      <xs:choice minOccurs='0' maxOccurs='unbounded'>
        <xs:element name='from' type='messageType'/>
        <xs:element name='next' type='linkType'/>
        <xs:element ref='note'/>
        <xs:element name='previous' type='linkType'/>
        <xs:element name='to' type='messageType'/>
        <xs:any processContents='lax' namespace='##other'/>
      </xs:choice>
      <xs:attribute name='start' type='xs:dateTime' use='required'/>
      <xs:attribute name='subject' type='xs:string' use='optional'/>
      <xs:attribute name='thread' use='optional' type='xs:string'/>
      <xs:attribute name='version' use='optional' type='xs:nonNegativeInteger'/>
      <xs:attribute name='with' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:complexType name='messageType'>
    <xs:sequence>
      <xs:element name='body' type='xs:string' minOccurs='0' maxOccurs='unbounded'/>
      <xs:any processContents='lax' namespace='##other' minOccurs='0' maxOccurs='unbounded'/>
    </xs:sequence>
    <xs:attribute name='jid' type='xs:string' use='optional'/>
    <xs:attribute name='name' type='xs:string' use='optional'/>
    <xs:attribute name='secs' type='xs:nonNegativeInteger' use='optional'/>
    <xs:attribute name='utc' type='xs:dateTime' use='optional'/>
  </xs:complexType>

  <xs:complexType name='linkType'>
    <xs:simpleContent>
      <xs:extension base='empty'>
        <xs:attribute name='start' type='xs:dateTime' use='optional'/>
        <xs:attribute name='with' type='xs:string' use='optional'/>
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType>

  <xs:element name='default'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='expire' type='xs:nonNegativeInteger' use='optional'/>
          <xs:attribute name='otr' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='approve'/>
                <xs:enumeration value='concede'/>
                <xs:enumeration value='forbid'/>
                <xs:enumeration value='oppose'/>
                <xs:enumeration value='prefer'/>
                <xs:enumeration value='require'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
          <xs:attribute name='save' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='body'/>
                <xs:enumeration value='false'/>
                <xs:enumeration value='message'/>
                <xs:enumeration value='stream'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
          <xs:attribute name='unset' use='optional' type='xs:boolean'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='feature'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='default' minOccurs='0' maxOccurs='1'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
          <xs:attribute name='expire' type='xs:nonNegativeInteger' use='optional'/>
          <xs:attribute name='jid' use='required' type='xs:string'/>
          <xs:attribute name='otr' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='approve'/>
                <xs:enumeration value='concede'/>
                <xs:enumeration value='forbid'/>
                <xs:enumeration value='oppose'/>
                <xs:enumeration value='prefer'/>
                <xs:enumeration value='require'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
          <xs:attribute name='save' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='body'/>
                <xs:enumeration value='false'/>
                <xs:enumeration value='message'/>
                <xs:enumeration value='stream'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='list'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='chat' minOccurs='0' maxOccurs='unbounded'/>
        <xs:any processContents='lax' namespace='##other' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='end' type='xs:dateTime' use='optional'/>
      <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
      <xs:attribute name='start' type='xs:dateTime' use='optional'/>
      <xs:attribute name='with' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='method'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='type' type='xs:string' use='required'/>
          <xs:attribute name='use' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='concede'/>
                <xs:enumeration value='forbid'/>
                <xs:enumeration value='prefer'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='modified'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='changed' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='removed' minOccurs='0' maxOccurs='unbounded'/>
        <xs:any processContents='lax' namespace='##other' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='start' type='xs:dateTime' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='note'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='utc' type='xs:dateTime' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='pref'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='auto' minOccurs='0' maxOccurs='1'/>
        <xs:element ref='default' minOccurs='0' maxOccurs='1'/>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='method' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='itemremove'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='item' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='remove'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='end' type='xs:dateTime' use='optional'/>
          <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
          <xs:attribute name='open' use='optional' type='xs:boolean'/>
          <xs:attribute name='start' type='xs:dateTime' use='required'/>
          <xs:attribute name='with' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='removed'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
          <xs:attribute name='start' type='xs:dateTime' use='required'/>
          <xs:attribute name='with' type='xs:string' use='required'/>
          <xs:attribute name='version' type='xs:nonNegativeInteger' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='retrieve'>
    <xs:complexType>
      <xs:sequence>
        <xs:any processContents='lax' namespace='##other' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='exactmatch' type='xs:boolean' use='optional'/>
      <xs:attribute name='start' type='xs:dateTime' use='required'/>
      <xs:attribute name='with' type='xs:string' use='required'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='save'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='chat' minOccurs='1' maxOccurs='1'/>
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