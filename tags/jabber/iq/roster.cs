// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="roster.cs">
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

namespace XMPP.Tags.Jabber.iq.roster
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:roster";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The item.
        /// </summary>
        public static XName item = XName.Get("item", Name);

        /// <summary>
        /// The group.
        /// </summary>
        public static XName group = XName.Get("group", Name);
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
        /// Gets or sets the ver.
        /// </summary>
        public string ver
        {
            get { return (string) GetAttributeValue("ver"); }
            set { SetAttributeValue("ver", value); }
        }

        /// <summary>
        /// Gets the item elements.
        /// </summary>
        public IEnumerable<item> itemElements
        {
            get { return Elements<item>(Namespace.item); }
        }
    }

    /// <summary>
    /// The item.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(item))]
    public class item : Tag
    {
        /// <summary>
        /// The ask enum.
        /// </summary>
        public enum askEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            none, 

            /// <summary>
            /// The subscribe.
            /// </summary>
            subscribe
        }

        /// <summary>
        /// The subscription enum.
        /// </summary>
        public enum subscriptionEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            none, 

            /// <summary>
            /// The both.
            /// </summary>
            both, 

            /// <summary>
            /// The from.
            /// </summary>
            from, 

            /// <summary>
            /// The remove.
            /// </summary>
            remove, 

            /// <summary>
            /// The to.
            /// </summary>
            to
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="item"/> class.
        /// </summary>
        public item() : base(Namespace.item)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="item"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public item(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the approved.
        /// </summary>
        public string approved
        {
            get { return (string) GetAttributeValue("approved"); }
            set { SetAttributeValue("approved", value); }
        }

        /// <summary>
        /// Gets or sets the ask.
        /// </summary>
        public askEnum ask
        {
            get { return GetAttributeEnum<askEnum>("ask"); }
            set { SetAttributeEnum<askEnum>("ask", value); }
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
        /// Gets or sets the name.
        /// </summary>
        public string name
        {
            get { return (string) GetAttributeValue("name"); }
            set { SetAttributeValue("name", value); }
        }

        /// <summary>
        /// Gets or sets the subscription.
        /// </summary>
        public subscriptionEnum subscription
        {
            get { return GetAttributeEnum<subscriptionEnum>("subscription"); }
            set { SetAttributeEnum<subscriptionEnum>("subscription", value); }
        }

        /// <summary>
        /// Gets the group elements.
        /// </summary>
        public IEnumerable<@group> groupElements
        {
            get { return Elements<@group>(Namespace.group); }
        }
    }


    /// <summary>
    /// The group.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(group))]
    public class group : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="group"/> class.
        /// </summary>
        public group() : base(Namespace.group)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="group"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public group(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:roster'
    xmlns='jabber:iq:roster'
    elementFormDefault='qualified'>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='item'
                    minOccurs='0'
                    maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='ver'
                    type='xs:string'
                    use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='group'
                    minOccurs='0'
                    maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='approved'
                    type='xs:boolean'
                    use='optional'/>
      <xs:attribute name='ask' 
                    use='optional'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='subscribe'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='jid'
                    type='xs:string'
                    use='required'/>
      <xs:attribute name='name'
                    type='xs:string'
                    use='optional'/>
      <xs:attribute name='subscription' 
                    use='optional'
                    default='none'>
        <xs:simpleType>
          <xs:restriction base='xs:NMTOKEN'>
            <xs:enumeration value='both'/>
            <xs:enumeration value='from'/>
            <xs:enumeration value='none'/>
            <xs:enumeration value='remove'/>
            <xs:enumeration value='to'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='group' type='xs:string'/>

</xs:schema>

*/