// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="last.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.iq.last
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:last";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);
    }


    /// <summary>
    /// The query.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(query))]
    public class query : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        public query() : base(Namespace.query)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public query(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        public string seconds
        {
            get { return (string) GetAttributeValue("seconds"); }
            set { SetAttributeValue("seconds", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:last'
    xmlns='jabber:iq:last'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0012: http://www.xmpp.org/extensions/xep-0012.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='seconds' type='xs:unsignedLong' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/