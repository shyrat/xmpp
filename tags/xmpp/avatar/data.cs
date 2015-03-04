// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="data.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Avatar.Data
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:avatar:data";

        public static readonly XName Data = XName.Get("data", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Data))]
    public class Data : Tag
    {
        public Data() : base(Namespace.Data)
        {
        }

        public Data(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:avatar:data'
    xmlns='urn:xmpp:avatar:data'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0084: http://www.xmpp.org/extensions/xep-0084.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='data' type='xs:base64Binary'/>

</xs:schema>

*/