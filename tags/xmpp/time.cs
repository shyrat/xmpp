// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="time.cs">
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

namespace XMPP.Tags.Xmpp.Time
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:time";

        public static readonly XName Time = XName.Get("time", Name);
        public static readonly XName Tzo = XName.Get("tzo", Name);
        public static readonly XName Utc = XName.Get("utc", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Time))]
    public class Time : Tag
    {
        public Time() : base(Namespace.Time)
        {
        }

        public Time(XElement other) : base(other)
        {
        }

        public IEnumerable<Tzo> TzoElements
        {
            get { return Elements<Tzo>(Namespace.Tzo); }
        }

        public IEnumerable<Utc> UtcElements
        {
            get { return Elements<Utc>(Namespace.Utc); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Tzo))]
    public class Tzo : Tag
    {
        public Tzo() : base(Namespace.Tzo)
        {
        }

        public Tzo(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Utc))]
    public class Utc : Tag
    {
        public Utc() : base(Namespace.Utc)
        {
        }

        public Utc(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:time'
    xmlns='urn:xmpp:time'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0202: http://www.xmpp.org/extensions/xep-0202.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='time'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element name='tzo' type='xs:string'/>
        <xs:element name='utc' type='xs:string'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/