// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="update.cs">
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

namespace XMPP.Tags.VCardTemp.X.Update
{
    public class Namespace
    {
        public const string XmlNamespace = "vcard-temp:x:update";

        public static readonly XName X = XName.Get("x", XmlNamespace);
        public static readonly XName Photo = XName.Get("photo", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public X() : base(Namespace.X)
        {
        }

        public X(XElement other) : base(other)
        {
        }

        public IEnumerable<Photo> PhotoElements
        {
            get { return Elements<Photo>(Namespace.Photo); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Photo))]
    public class Photo : Tag
    {
        public Photo() : base(Namespace.Photo)
        {
        }

        public Photo(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='vcard-temp:x:update'
    xmlns='vcard-temp:x:update'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0153: http://www.xmpp.org/extensions/xep-0153.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='photo' minOccurs='0' type='xs:base64Binary'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>

*/