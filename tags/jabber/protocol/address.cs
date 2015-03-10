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

namespace XMPP.Tags.Jabber.Protocol.Address
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/address";

        public static readonly XName Addresses = XName.Get("addresses", Name);
        public static readonly XName Address = XName.Get("address", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Addresses))]
    public class Addresses : Tag
    {
        public Addresses() : base(Namespace.Addresses)
        {
        }

        public Addresses(XElement other) : base(other)
        {
        }

        public IEnumerable<Address> AddressElements
        {
            get { return Elements<Address>(Namespace.Address); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Address))]
    public class Address : Tag
    {
        public enum TypeEnum
        {
            none,
            bcc,
            cc,
            noreply,
            replyroom,
            replyto,
            to
        }

        public Address() : base(Namespace.Address)
        {
        }

        public Address(XElement other)
            : base(other)
        {
        }

        public string DeliveredAttr
        {
            get { return (string)GetAttributeValue("delivered"); }
            set { SetAttributeValue("delivered", value); }
        }

        public string DescAttr
        {
            get { return (string)GetAttributeValue("desc"); }
            set { SetAttributeValue("desc", value); }
        }

        public string JidAttr
        {
            get { return (string)GetAttributeValue("jid"); }
            set { SetAttributeValue("jid", value); }
        }

        public string NodeAttr
        {
            get { return (string)GetAttributeValue("node"); }
            set { SetAttributeValue("node", value); }
        }

        public TypeEnum TypeAttr
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string UriAttr
        {
            get { return (string)GetAttributeValue("uri"); }
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