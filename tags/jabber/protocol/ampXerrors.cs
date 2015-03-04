// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ampXerrors.cs">
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

namespace XMPP.Tags.Jabber.Protocol.ampXerrors
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public static string Name = "http://jabber.org/protocol/amp#errors";

        /// <summary>
        /// The failed_rules.
        /// </summary>
        public static XName failed_rules = XName.Get("failed-rules", Name);

        /// <summary>
        /// The rule.
        /// </summary>
        public static XName rule = XName.Get("rule", Name);
    }

    /// <summary>
    /// The failed_rules.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(failed_rules))]
    public class failed_rules : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="failed_rules"/> class.
        /// </summary>
        public failed_rules() : base(Namespace.failed_rules)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="failed_rules"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public failed_rules(XElement other) : base(other)
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
    targetNamespace='http://jabber.org/protocol/amp#errors'
    xmlns='http://jabber.org/protocol/amp#errors'
    elementFormDefault='qualified'>
 
  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0079: http://www.xmpp.org/extensions/xep-0079.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='failed-rules'>
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