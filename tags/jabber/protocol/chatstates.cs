// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="chatstates.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Chatstates
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/chatstates";

        public static readonly XName Active = XName.Get("active", XmlNamespace);
        public static readonly XName Composing = XName.Get("composing", XmlNamespace);
        public static readonly XName Gone = XName.Get("gone", XmlNamespace);
        public static readonly XName Inactive = XName.Get("inactive", XmlNamespace);
        public static readonly XName Paused = XName.Get("paused", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Active))]
    public class Active : Tag
    {
        public Active() : base(Namespace.Active)
        {
        }

        public Active(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Composing))]
    public class Composing : Tag
    {
        public Composing() : base(Namespace.Composing)
        {
        }

        public Composing(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Gone))]
    public class Gone : Tag
    {
        public Gone() : base(Namespace.Gone)
        {
        }

        public Gone(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Inactive))]
    public class Inactive : Tag
    {
        public Inactive() : base(Namespace.Inactive)
        {
        }

        public Inactive(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Paused))]
    public class Paused : Tag
    {
        public Paused() : base(Namespace.Paused)
        {
        }

        public Paused(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/chatstates'
    xmlns='http://jabber.org/protocol/chatstates'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0085: http://www.xmpp.org/extensions/xep-0085.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='active' type='empty'/>
  <xs:element name='composing' type='empty'/>
  <xs:element name='gone' type='empty'/>
  <xs:element name='inactive' type='empty'/>
  <xs:element name='paused' type='empty'/>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/