// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="amp.cs">
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

namespace XMPP.Tags.Jabber.Protocol.amp
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "http://jabber.org/protocol/amp";

        /// <summary>
        /// The amp.
        /// </summary>
        public static XName amp = XName.Get("amp", Name);

        /// <summary>
        /// The invalid_rules.
        /// </summary>
        public static XName invalid_rules = XName.Get("invalid-rules", Name);

        /// <summary>
        /// The unsupported_actions.
        /// </summary>
        public static XName unsupported_actions = XName.Get("unsupported-actions", Name);

        /// <summary>
        /// The unsupported_conditions.
        /// </summary>
        public static XName unsupported_conditions = XName.Get("unsupported-conditions", Name);

        /// <summary>
        /// The rule.
        /// </summary>
        public static XName rule = XName.Get("rule", Name);
    }

    /// <summary>
    /// The amp.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(amp))]
    public class amp : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="amp"/> class.
        /// </summary>
        public amp() : base(Namespace.amp)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="amp"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public amp(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the rule elements.
        /// </summary>
        public IEnumerable<rule> ruleElements
        {
            get { return Elements<rule>(Namespace.rule); }
        }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public string from
        {
            get { return (string) GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        /// <summary>
        /// Gets or sets the per_hop.
        /// </summary>
        public string per_hop
        {
            get { return (string) GetAttributeValue("per_hop"); }
            set { SetAttributeValue("per_hop", value); }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string status
        {
            get { return (string) GetAttributeValue("status"); }
            set { SetAttributeValue("status", value); }
        }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        public string to
        {
            get { return (string) GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }
    }


    /// <summary>
    /// The invalid_rules.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(invalid_rules))]
    public class invalid_rules : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="invalid_rules"/> class.
        /// </summary>
        public invalid_rules() : base(Namespace.invalid_rules)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="invalid_rules"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public invalid_rules(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the rule elements.
        /// </summary>
        public IEnumerable<rule> ruleElements
        {
            get { return Elements<rule>(Namespace.rule); }
        }
    }

    /// <summary>
    /// The unsupported_actions.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(unsupported_actions))]
    public class unsupported_actions : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="unsupported_actions"/> class.
        /// </summary>
        public unsupported_actions() : base(Namespace.unsupported_actions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="unsupported_actions"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public unsupported_actions(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the rule elements.
        /// </summary>
        public IEnumerable<rule> ruleElements
        {
            get { return Elements<rule>(Namespace.rule); }
        }
    }

    /// <summary>
    /// The unsupported_conditions.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(unsupported_conditions))]
    public class unsupported_conditions : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="unsupported_conditions"/> class.
        /// </summary>
        public unsupported_conditions() : base(Namespace.unsupported_conditions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="unsupported_conditions"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public unsupported_conditions(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets the rule elements.
        /// </summary>
        public IEnumerable<rule> ruleElements
        {
            get { return Elements<rule>(Namespace.rule); }
        }
    }

    /// <summary>
    /// The rule.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(rule))]
    public class rule : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="rule"/> class.
        /// </summary>
        public rule() : base(Namespace.rule)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="rule"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public rule(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string action
        {
            get { return (string) GetAttributeValue("action"); }
            set { SetAttributeValue("action", value); }
        }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public string condition
        {
            get { return (string) GetAttributeValue("condition"); }
            set { SetAttributeValue("condition", value); }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string value
        {
            get { return (string) GetAttributeValue("value"); }
            set { SetAttributeValue("value", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/amp'
    xmlns='http://jabber.org/protocol/amp'
    elementFormDefault='qualified'>
 
  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0079: http://www.xmpp.org/extensions/xep-0079.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='amp'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='rule' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='from' use='optional' type='xs:string'/>
      <xs:attribute name='per-hop' use='optional' type='xs:boolean' default='false'/>
      <xs:attribute name='status' use='optional' type='xs:NCName'/>
      <xs:attribute name='to' use='optional' type='xs:string'/>
    </xs:complexType>
  </xs:element>
 
  <xs:element name='invalid-rules'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='rule' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='unsupported-actions'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='rule' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='unsupported-conditions'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='rule' minOccurs='1' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='rule'>
    <xs:complexType>
      <xs:attribute name='action' use='required' type='xs:NCName'/>
      <xs:attribute name='condition' use='required' type='xs:NCName'/>
      <xs:attribute name='value' use='required' type='xs:string'/>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/