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

namespace XMPP.Tags.Jabber.Protocol.Amp
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/amp";

        public static readonly XName Amp = XName.Get("amp", Name);
        public static readonly XName InvalidRules = XName.Get("invalid-rules", Name);
        public static readonly XName UnsupportedActions = XName.Get("unsupported-actions", Name);
        public static readonly XName UnsupportedConditions = XName.Get("unsupported-conditions", Name);
        public static readonly XName Rule = XName.Get("rule", Name);
    }

    [XmppTag(typeof(Namespace), typeof(amp))]
    public class amp : Tag
    {
        public amp() : base(Namespace.Amp)
        {
        }

        public amp(XElement other) : base(other)
        {
        }

        public IEnumerable<Rule> RuleElements
        {
            get { return Elements<Rule>(Namespace.Rule); }
        }

        public string FromAttr
        {
            get { return (string)GetAttributeValue("from"); }
            set { SetAttributeValue("from", value); }
        }

        public string PerHopAttr
        {
            get { return (string)GetAttributeValue("per_hop"); }
            set { SetAttributeValue("per_hop", value); }
        }

        public string StatusAttr
        {
            get { return (string)GetAttributeValue("status"); }
            set { SetAttributeValue("status", value); }
        }

        public string ToAttr
        {
            get { return (string)GetAttributeValue("to"); }
            set { SetAttributeValue("to", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidRules))]
    public class InvalidRules : Tag
    {
        public InvalidRules() : base(Namespace.InvalidRules)
        {
        }

        public InvalidRules(XElement other) : base(other)
        {
        }

        public IEnumerable<Rule> RuleElements
        {
            get { return Elements<Rule>(Namespace.Rule); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedActions))]
    public class UnsupportedActions : Tag
    {
        public UnsupportedActions() : base(Namespace.UnsupportedActions)
        {
        }

        public UnsupportedActions(XElement other) : base(other)
        {
        }

        public IEnumerable<Rule> RuleElements
        {
            get { return Elements<Rule>(Namespace.Rule); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnsupportedConditions))]
    public class UnsupportedConditions : Tag
    {
        public UnsupportedConditions() : base(Namespace.UnsupportedConditions)
        {
        }

        public UnsupportedConditions(XElement other) : base(other)
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
            set { SetAttributeValue("action", value); }
        }

        public string Condition
        {
            get { return (string)GetAttributeValue("condition"); }
            set { SetAttributeValue("condition", value); }
        }

        public string ValueAttr
        {
            get { return (string)GetAttributeValue("value"); }
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