// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="metadata.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Avatar.Metadata
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:avatar:metadata";

        public static readonly XName Metadata = XName.Get("metadata", Name);
        public static readonly XName Info = XName.Get("info", Name);
        public static readonly XName Pointer = XName.Get("pointer", Name);
        public static readonly XName Stop = XName.Get("stop", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Metadata))]
    public class Metadata : Tag
    {
        public Metadata() : base(Namespace.Metadata)
        {
        }

        public Metadata(XElement other)
            : base(other)
        {
        }

        public Info Info
        {
            get { return Element<Info>(Namespace.Info); }
        }

        public Pointer Pointer
        {
            get { return Element<Pointer>(Namespace.Pointer); }
        }

        public Stop Stop
        {
            get { return Element<Stop>(Namespace.Stop); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Info))]
    public class Info : Tag
    {
        public Info() : base(Namespace.Info)
        {
        }

        public Info(XElement other) : base(other)
        {
        }

        public string BytesAttr
        {
            get { return (string)GetAttributeValue("bytes"); }
            set { SetAttributeValue("bytes", value); }
        }

        public string HeightAttr
        {
            get { return (string)GetAttributeValue("height"); }
            set { SetAttributeValue("height", value); }
        }

        public string IdAttr
        {
            get { return (string)GetAttributeValue("id"); }
            set { SetAttributeValue("id", value); }
        }

        public string TypeAttr
        {
            get { return (string)GetAttributeValue("type"); }
            set { SetAttributeValue("type", value); }
        }

        public string UrlAttr
        {
            get { return (string)GetAttributeValue("url"); }
            set { SetAttributeValue("url", value); }
        }

        public string WidthAttr
        {
            get { return (string)GetAttributeValue("width"); }
            set { SetAttributeValue("width", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Pointer))]
    public class Pointer : Tag
    {
        public Pointer() : base(Namespace.Pointer)
        {
        }

        public Pointer(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Stop))]
    public class Stop : Tag
    {
        public Stop() : base(Namespace.Stop)
        {
        }

        public Stop(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:avatar:metadata'
    xmlns='urn:xmpp:avatar:metadata'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0084: http://www.xmpp.org/extensions/xep-0084.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='metadata'>
    <xs:complexType>
      <xs:choice>
        <xs:sequence minOccurs='0' maxOccurs='1'>
          <xs:element ref='info' minOccurs='1' maxOccurs='unbounded'/>
          <xs:element ref='pointer' minOccurs='0' maxOccurs='unbounded'/>
        </xs:sequence>
        <xs:element name='stop' type='empty'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

  <xs:element name='info'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='bytes' type='xs:unsignedShort' use='required'/>
          <xs:attribute name='height' type='xs:unsignedByte' use='optional'/>
          <xs:attribute name='id' type='xs:string' use='required'/>
          <xs:attribute name='type' type='xs:string' use='required'/>
          <xs:attribute name='url' type='xs:anyURI' use='optional'/>
          <xs:attribute name='width' type='xs:unsignedByte' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='pointer'>
    <xs:complexType>
      <xs:sequence>
        <xs:any namespace='##other'/>
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