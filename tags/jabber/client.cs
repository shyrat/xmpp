// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="client.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Client
{
    public class Namespace
    {
        public const string Name = "jabber:client";

        public static readonly XName Message = XName.Get("message", Name);
        public static readonly XName Iq = XName.Get("iq", Name);
        public static readonly XName Presence = XName.Get("presence", Name);
        public static readonly XName Priority = XName.Get("priority", Name);
        public static readonly XName Show = XName.Get("show", Name);
        public static readonly XName Status = XName.Get("status", Name);
        public static readonly XName Body = XName.Get("body", Name);
        public static readonly XName Subject = XName.Get("subject", Name);
        public static readonly XName Thread = XName.Get("thread", Name);
        public static readonly XName Error = XName.Get("error", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Message))]
    public class Message : Tag
    {
        public enum TypeEnum
        {
            none,
            chat,
            error,
            groupchat,
            headline,
            normal
        }

        public Message() : base(Namespace.Message)
        {
        }

        public Message(XElement other) : base(other)
        {
        }

        public string From
        {
            get { return (string)GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        public string To
        {
            get { return (string)GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }

        public TypeEnum Type
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string Id
        {
            get { return (string)GetAttributeValue("id"); }
            set { SetAttributeValue("id", value); }
        }

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }

        public IEnumerable<Body> BodyElements
        {
            get { return Elements<Body>(Namespace.Body); }
        }

        public IEnumerable<Subject> SubjectElements
        {
            get { return Elements<Subject>(Namespace.Subject); }
        }

        public IEnumerable<Thread> ThreadElements
        {
            get { return Elements<Thread>(Namespace.Thread); }
        }

        public IEnumerable<Error> ErrorElements
        {
            get { return Elements<Error>(Namespace.Error); }
        }

        public string Body
        {
            get { return string.Join(" ", from body in BodyElements select body.Value); }
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

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Subject))]
    public class Subject : Tag
    {
        public Subject() : base(Namespace.Subject)
        {
        }

        public Subject(XElement other) : base(other)
        {
        }

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }
    }


    [XmppTag(typeof(Namespace), typeof(Thread))]
    public class Thread : Tag
    {
        public Thread() : base(Namespace.Thread)
        {
        }

        public Thread(XElement other) : base(other)
        {
        }

        public string ParentAttr
        {
            get { return (string)GetAttributeValue("parent"); }
            set { SetAttributeValue("parent", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Presence))]
    public class Presence : Tag
    {
        public enum TypeEnum
        {
            none,
            error,
            probe,
            subscribe,
            subscribed,
            unavailable,
            unsubscribe,
            unsubscribed
        }

        public Presence() : base(Namespace.Presence)
        {
            Id = NextId();
        }

        public Presence(XElement other) : base(other)
        {
            Id = NextId();
        }

        public string From
        {
            get { return (string)GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        public string To
        {
            get { return (string)GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }

        public TypeEnum Type
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string Id
        {
            get { return (string)GetAttributeValue("id"); }
            set { SetAttributeValue("id", value); }
        }

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }

        public IEnumerable<Show> ShowElements
        {
            get { return Elements<Show>(Namespace.Show); }
        }

        public IEnumerable<Status> StatusElements
        {
            get { return Elements<Status>(Namespace.Status); }
        }

        public IEnumerable<Priority> PriorityElements
        {
            get { return Elements<Priority>(Namespace.Priority); }
        }

        public IEnumerable<Error> ErrorElements
        {
            get { return Elements<Error>(Namespace.Error); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Show))]
    public class Show : Tag
    {
        public enum ValueEnum
        {
            none,
            away,
            chat,
            dnd,
            xa
        }

        public Show() : base(Namespace.Show)
        {
        }

        public Show(XElement other) : base(other)
        {
        }

        public new ValueEnum Value
        {
            get { return (ValueEnum) Enum.Parse(typeof(ValueEnum), base.Value, true); }
            set { base.Value = value.ToString(); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Status))]
    public class Status : Tag
    {
        public Status() : base(Namespace.Status)
        {
        }

        public Status(XElement other) : base(other)
        {
        }

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }

        public new string Value
        {
            get { return base.Value; }
            set
            {
                if (value.Length < 1 || value.Length > 1024)
                {
                    throw new Exception("Text out of range");
                }

                base.Value = value;
            }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Priority))]
    public class Priority : Tag
    {
        public Priority() : base(Namespace.Priority)
        {
        }

        public Priority(XElement other) : base(other)
        {
        }

        public new int Value
        {
            get { return Convert.ToInt32(base.Value); }
            set { base.Value = value.ToString(); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Iq))]
    public class Iq : Tag
    {
        public enum TypeEnum
        {
            none,
            error,
            get,
            result,
            set
        }

        public Iq() : base(Namespace.Iq)
        {
        }

        public Iq(XElement other) : base(other)
        {
        }

        public string From
        {
            get { return (string) GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        public string To
        {
            get { return (string)GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }

        public TypeEnum Type
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string Id
        {
            get { return (string)GetAttributeValue("id"); }
            set { SetAttributeValue("id", value); }
        }

        public string Lang
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }

        public IEnumerable<Error> ErrorElements
        {
            get { return Elements<Error>(Namespace.Error); }
        }

        public Tag Payload
        {
            get { return Get(Elements().FirstOrDefault()); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Error))]
    public class Error : Tag
    {
        public enum TypeEnum
        {
            none,
            auth,
            cancel,
            @continue,
            modify,
            wait,
        }

        public Error() : base(Namespace.Error)
        {
        }

        public Error(XElement other) : base(other)
        {
        }

        public string By
        {
            get { return (string)GetAttributeValue("by"); }
            set { SetAttributeValue("by", value); }
        }

        public TypeEnum Type
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:client'
    xmlns='jabber:client'
    elementFormDefault='qualified'>

  <xs:import namespace='urn:ietf:params:xml:ns:xmpp-stanzas'
             schemaLocation='http://xmpp.org/schemas/stanzaerror.xsd'/>
  <xs:import namespace='http://www.w3.org/XML/1998/namespace'
             schemaLocation='http://www.w3.org/2001/03/xml.xsd'/>

  <xs:element name='message'>
     <xs:complexType>
        <xs:sequence>
          <xs:choice minOccurs='0' maxOccurs='unbounded'>
            <xs:element ref='subject'/>
            <xs:element ref='body'/>
            <xs:element ref='thread'/>
          </xs:choice>
          <xs:any     namespace='##other'
                      minOccurs='0'
                      maxOccurs='unbounded'
                      processContents='lax'/>
          <xs:element ref='error'
                      minOccurs='0'/>
        </xs:sequence>
        <xs:attribute name='from'
                      type='xs:string'
                      use='optional'/>
        <xs:attribute name='id'
                      type='xs:NMTOKEN'
                      use='optional'/>
        <xs:attribute name='to'
                      type='xs:string'
                      use='optional'/>
        <xs:attribute name='type' 
                      use='optional' 
                      default='normal'>
          <xs:simpleType>
            <xs:restriction base='xs:NMTOKEN'>
              <xs:enumeration value='chat'/>
              <xs:enumeration value='error'/>
              <xs:enumeration value='groupchat'/>
              <xs:enumeration value='headline'/>
              <xs:enumeration value='normal'/>
            </xs:restriction>
          </xs:simpleType>
        </xs:attribute>
        <xs:attribute ref='xml:lang' use='optional'/>
     </xs:complexType>
  </xs:element>

  <xs:element name='body'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute ref='xml:lang' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='subject'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute ref='xml:lang' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='thread'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:NMTOKEN'>
          <xs:attribute name='parent'
                        type='xs:NMTOKEN'
                        use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='presence'>
    <xs:complexType>
      <xs:sequence>
        <xs:choice minOccurs='0' maxOccurs='unbounded'>
          <xs:element ref='show'/>
          <xs:element ref='status'/>
          <xs:element ref='priority'/>
        </xs:choice>
        <xs:any     namespace='##other'
                    minOccurs='0'
                    maxOccurs='unbounded'
                    processContents='lax'/>
        <xs:element ref='error'
                    minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='from'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='id'
                    type='xs:NMTOKEN'
                    use='optional'/>
      <xs:attribute name='to'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='type' use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='error'/>
            <xs:enumeration value='probe'/>
            <xs:enumeration value='subscribe'/>
            <xs:enumeration value='subscribed'/>
            <xs:enumeration value='unavailable'/>
            <xs:enumeration value='unsubscribe'/>
            <xs:enumeration value='unsubscribed'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute ref='xml:lang' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='show'>
    <xs:simpleType>
      <xs:restriction base='xs:NMTOKEN'>
        <xs:enumeration value='away'/>
        <xs:enumeration value='chat'/>
        <xs:enumeration value='dnd'/>
        <xs:enumeration value='xa'/>
      </xs:restriction>
    </xs:simpleType>
  </xs:element>

  <xs:element name='status'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='string1024'>
          <xs:attribute ref='xml:lang' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='string1024'>
    <xs:restriction base='xs:string'>
      <xs:minLength value='1'/>
      <xs:maxLength value='1024'/>
    </xs:restriction>
  </xs:simpleType>

  <xs:element name='priority' type='xs:byte'/>

  <xs:element name='iq'>
    <xs:complexType>
      <xs:sequence>
        <xs:any     namespace='##other'
                    minOccurs='0'
                    maxOccurs='1'
                    processContents='lax'/>
        <xs:element ref='error'
                    minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='from'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='id'
                    type='xs:NMTOKEN'
                    use='required'/>
      <xs:attribute name='to'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='type' use='required'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='error'/>
            <xs:enumeration value='get'/>
            <xs:enumeration value='result'/>
            <xs:enumeration value='set'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute ref='xml:lang' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='error'>
    <xs:complexType>
      <xs:sequence xmlns:err='urn:ietf:params:xml:ns:xmpp-stanzas'>
        <xs:group ref='err:stanzaErrorGroup'/>
        <xs:element ref='err:text'
                    minOccurs='0'/>
      </xs:sequence>
      <xs:attribute name='by' 
                    type='xs:string' 
                    use='optional'/>
      <xs:attribute name='type' use='required'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='auth'/>
            <xs:enumeration value='cancel'/>
            <xs:enumeration value='continue'/>
            <xs:enumeration value='modify'/>
            <xs:enumeration value='wait'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/