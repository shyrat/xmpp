// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="address.cs">
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

namespace XMPP.Tags.Jabber.Protocol.address
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "http://jabber.org/protocol/address";

        /// <summary>
        /// The addresses.
        /// </summary>
        public static XName addresses = XName.Get("addresses", Name);

        /// <summary>
        /// The address.
        /// </summary>
        public static XName address = XName.Get("address", Name);
    }

    /// <summary>
    /// The addresses.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(addresses))]
    public class addresses : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="addresses"/> class.
        /// </summary>
        public addresses() : base(Namespace.addresses)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="addresses"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public addresses(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the address elements.
        /// </summary>
        public IEnumerable<address> addressElements
        {
            get { return Elements<address>(Namespace.address); }
        }
    }

    /// <summary>
    /// The address.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(address))]
    public class address : Tag
    {
        /// <summary>
        /// The type enum.
        /// </summary>
        public enum typeEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            none, 

            /// <summary>
            /// The bcc.
            /// </summary>
            bcc, 

            /// <summary>
            /// The cc.
            /// </summary>
            cc, 

            /// <summary>
            /// The noreply.
            /// </summary>
            noreply, 

            /// <summary>
            /// The replyroom.
            /// </summary>
            replyroom, 

            /// <summary>
            /// The replyto.
            /// </summary>
            replyto, 

            /// <summary>
            /// The to.
            /// </summary>
            to
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="address"/> class.
        /// </summary>
        public address() : base(Namespace.address)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="address"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public address(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the delivered.
        /// </summary>
        public string delivered
        {
            get { return (string) GetAttributeValue("delivered"); }
            set { SetAttributeValue("delivered", value); }
        }

        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        public string desc
        {
            get { return (string) GetAttributeValue("desc"); }
            set { SetAttributeValue("desc", value); }
        }

        /// <summary>
        /// Gets or sets the jid.
        /// </summary>
        public string jid
        {
            get { return (string) GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        public string node
        {
            get { return (string) GetAttributeValue("node"); }
            set { SetAttributeValue("node", value); }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public typeEnum type
        {
            get { return GetAttributeEnum<typeEnum>("type"); }
            set { SetAttributeEnum<typeEnum>("type", value); }
        }

        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        public string uri
        {
            get { return (string) GetAttributeValue("uri"); }
            set { SetAttributeValue("uri", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/address'
    xmlns='http://jabber.org/protocol/address'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0033: http://www.xmpp.org/extensions/xep-0033.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='addresses'>
     <xs:complexType>
        <xs:sequence>
           <xs:element ref='address'
                       minOccurs='1'
                       maxOccurs='unbounded'/>
        </xs:sequence>
     </xs:complexType>
  </xs:element>

  <xs:element name='address'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='delivered' use='optional' fixed='true'/>
          <xs:attribute name='desc' use='optional' type='xs:string'/>
          <xs:attribute name='jid' use='optional' type='xs:string'/>
          <xs:attribute name='node' use='optional' type='xs:string'/>
          <xs:attribute name='type' use='required'>
            <xs:simpleType>
              <xs:restriction base='xs:NCName'>
                <xs:enumeration value='bcc'/>
                <xs:enumeration value='cc'/>
                <xs:enumeration value='noreply'/>
                <xs:enumeration value='replyroom'/>
                <xs:enumeration value='replyto'/>
                <xs:enumeration value='to'/>
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
          <xs:attribute name='uri' use='optional' type='xs:string'/>
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