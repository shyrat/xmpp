// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="nick.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Nick
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/nick";

        public static readonly XName Nick = XName.Get("nick", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Nick))]
    public class Nick : Tag
    {
        public Nick() : base(Namespace.Nick)
        {
        }

        public Nick(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/nick'
    xmlns='http://jabber.org/protocol/nick'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0172: http://www.xmpp.org/extensions/xep-0172.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='nick' type='xs:string'/>

</xs:schema>

*/