// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="privacy.cs">
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

namespace XMPP.Tags.Jabber.iq.privacy
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "jabber:iq:privacy";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The active.
        /// </summary>
        public static XName active = XName.Get("active", Name);

        /// <summary>
        /// The default_.
        /// </summary>
        public static XName default_ = XName.Get("default", Name);

        /// <summary>
        /// The list.
        /// </summary>
        public static XName list = XName.Get("list", Name);

        /// <summary>
        /// The item.
        /// </summary>
        public static XName item = XName.Get("item", Name);

        /// <summary>
        /// The iq.
        /// </summary>
        public static XName iq = XName.Get("iq", Name);

        /// <summary>
        /// The message.
        /// </summary>
        public static XName message = XName.Get("message", Name);

        /// <summary>
        /// The presence_in.
        /// </summary>
        public static XName presence_in = XName.Get("presence-in", Name);

        /// <summary>
        /// The presence_out.
        /// </summary>
        public static XName presence_out = XName.Get("presence-out", Name);
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
        /// Gets the active elements.
        /// </summary>
        public IEnumerable<active> activeElements
        {
            get { return Elements<active>(Namespace.active); }
        }

        /// <summary>
        /// Gets the default elements.
        /// </summary>
        public IEnumerable<default_> defaultElements
        {
            get { return Elements<default_>(Namespace.default_); }
        }

        /// <summary>
        /// Gets the list elements.
        /// </summary>
        public IEnumerable<list> listElements
        {
            get { return Elements<list>(Namespace.list); }
        }
    }

    /// <summary>
    /// The active.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(active))]
    public class active : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="active"/> class.
        /// </summary>
        public active() : base(Namespace.active)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="active"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public active(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name
        {
            get { return (string) GetAttributeValue("name"); }
            set { SetAttributeValue("name", value); }
        }
    }


    /// <summary>
    /// The default_.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(default_))]
    public class default_ : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="default_"/> class.
        /// </summary>
        public default_() : base(Namespace.default_)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="default_"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public default_(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name
        {
            get { return (string) GetAttributeValue("name"); }
            set { SetAttributeValue("name", value); }
        }
    }

    /// <summary>
    /// The list.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(list))]
    public class list : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="list"/> class.
        /// </summary>
        public list() : base(Namespace.list)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="list"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public list(XElement other) : base(other)
        {
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
        /// The action enum.
        /// </summary>
        public enum actionEnum
        {
            /// <summary>
            /// The none.
            /// </summary>
            none, 

            /// <summary>
            /// The allow.
            /// </summary>
            allow, 

            /// <summary>
            /// The deny.
            /// </summary>
            deny
        }

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
            /// The group.
            /// </summary>
            group, 

            /// <summary>
            /// The jid.
            /// </summary>
            jid, 

            /// <summary>
            /// The subscription.
            /// </summary>
            subscription
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
        /// Gets or sets the seconds.
        /// </summary>
        public actionEnum seconds
        {
            get { return GetAttributeEnum<actionEnum>("action"); }
            set { SetAttributeEnum<actionEnum>("action", value); }
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public string order
        {
            get { return (string) GetAttributeValue("order"); }
            set { SetAttributeValue("order", value); }
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
        /// Gets or sets the value.
        /// </summary>
        public string value
        {
            get { return (string) GetAttributeValue("value"); }
            set { SetAttributeValue("value", value); }
        }


        /// <summary>
        /// Gets the iq elements.
        /// </summary>
        public IEnumerable<iq> iqElements
        {
            get { return Elements<iq>(Namespace.iq); }
        }

        /// <summary>
        /// Gets the message elements.
        /// </summary>
        public IEnumerable<message> messageElements
        {
            get { return Elements<message>(Namespace.message); }
        }

        /// <summary>
        /// Gets the presence_in elements.
        /// </summary>
        public IEnumerable<presence_in> presence_inElements
        {
            get { return Elements<presence_in>(Namespace.presence_in); }
        }

        /// <summary>
        /// Gets the presence_out elements.
        /// </summary>
        public IEnumerable<presence_out> presence_outElements
        {
            get { return Elements<presence_out>(Namespace.presence_out); }
        }
    }


    /// <summary>
    /// The iq.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(iq))]
    public class iq : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="iq"/> class.
        /// </summary>
        public iq() : base(Namespace.iq)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="iq"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public iq(XElement other) : base(other)
        {
        }
    }


    /// <summary>
    /// The message.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(message))]
    public class message : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="message"/> class.
        /// </summary>
        public message() : base(Namespace.message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="message"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public message(XElement other) : base(other)
        {
        }
    }


    /// <summary>
    /// The presence_in.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(presence_in))]
    public class presence_in : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="presence_in"/> class.
        /// </summary>
        public presence_in() : base(Namespace.presence_in)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="presence_in"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public presence_in(XElement other) : base(other)
        {
        }
    }


    /// <summary>
    /// The presence_out.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(presence_out))]
    public class presence_out : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="presence_out"/> class.
        /// </summary>
        public presence_out() : base(Namespace.presence_out)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="presence_out"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public presence_out(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
  xmlns:xs='http://www.w3.org/2001/XMLSchema'
  targetNamespace='jabber:iq:privacy'
  xmlns='jabber:iq:privacy'
  elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0016: http://www.xmpp.org/extensions/xep-0016.html
    </xs:documentation>
  </xs:annotation>

<xs:element name='query'>
  <xs:complexType>
    <xs:sequence>
      <xs:element ref='active'
                  minOccurs='0'/>
      <xs:element ref='default'
                  minOccurs='0'/>
      <xs:element ref='list'
                  minOccurs='0'
                  maxOccurs='unbounded'/>
    </xs:sequence>
  </xs:complexType>
</xs:element>

<xs:element name='active'>
  <xs:complexType>
    <xs:simpleContent>
      <xs:extension base='xs:NMTOKEN'>
        <xs:attribute name='name'
                      type='xs:string'
                      use='optional'/>
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType>
</xs:element>

<xs:element name='default'>
  <xs:complexType>
    <xs:simpleContent>
      <xs:extension base='xs:NMTOKEN'>
        <xs:attribute name='name'
                      type='xs:string'
                      use='optional'/>
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType>
</xs:element>

<xs:element name='list'>
  <xs:complexType>
    <xs:sequence>
      <xs:element ref='item'
                  minOccurs='0'
                  maxOccurs='unbounded'/>
    </xs:sequence>
    <xs:attribute name='name'
                  type='xs:string'
                  use='required'/>
  </xs:complexType>
</xs:element>

<xs:element name='item'>
  <xs:complexType>
    <xs:sequence>
      <xs:element name='iq'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='message'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='presence-in'
                  minOccurs='0'
                  type='empty'/>
      <xs:element name='presence-out'
                  minOccurs='0'
                  type='empty'/>
    </xs:sequence>
    <xs:attribute name='action' use='required'>
      <xs:simpleType>
        <xs:restriction base='xs:NCName'>
          <xs:enumeration value='allow'/>
          <xs:enumeration value='deny'/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name='order'
                  type='xs:unsignedInt'
                  use='required'/>
    <xs:attribute name='type' use='optional'>
      <xs:simpleType>
        <xs:restriction base='xs:NCName'>
          <xs:enumeration value='group'/>
          <xs:enumeration value='jid'/>
          <xs:enumeration value='subscription'/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name='value'
                  type='xs:string'
                  use='optional'/>
  </xs:complexType>
</xs:element>

<xs:simpleType name='empty'>
  <xs:restriction base='xs:string'>
    <xs:enumeration value=''/>
  </xs:restriction>
</xs:simpleType>

</xs:schema>

*/