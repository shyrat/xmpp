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

namespace XMPP.Tags.Jabber.Protocol.AmpXerrors
{
    public class Namespace
    {
        public const string XmlNamespace = "http://jabber.org/protocol/amp#errors";

        public static readonly XName FailedRules = XName.Get("failed-rules", XmlNamespace);
        public static readonly XName Rule = XName.Get("rule", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(FailedRules))]
    public class FailedRules : Tag
    {
        public FailedRules() : base(Namespace.FailedRules)
        {
        }

        public FailedRules(XElement other) : base(other)
        {
        }

        public IEnumerable<Rule> RuleElements
        {
            get { return Elements<Rule>(Namespace.Rule); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Rule))]
    public class Rule : Tag
    {
        public Rule() : base(Namespace.Rule)
        {
        }

        public Rule(XElement other) : base(other)
        {
        }

        public string ActionAttr
        {
            get { return (string)GetAttributeValue("action"); }
            set { InnerElement.SetAttributeValue("action", value); }
        }

        public string ConditionAttr
        {
            get { return (string)GetAttributeValue("condition"); }
            set { InnerElement.SetAttributeValue("condition", value); }
        }

        public string ValueAttr
        {
            get { return (string)GetAttributeValue("value"); }
            set { InnerElement.SetAttributeValue("value", value); }
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