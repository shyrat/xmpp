// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="discoXinfo.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.DiscoXinfo
{
    public class Namespace
    {
        public const string Name = "http://jabber.org/protocol/disco#info";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName Identity = XName.Get("identity", Name);
        public static readonly XName Feature = XName.Get("feature", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query() : base(Namespace.Query)
        {
        }

        public Query(XElement other) : base(other)
        {
        }

        public string Node
        {
            get { return (string)GetAttributeValue("node"); }
            set { SetAttributeValue("node", value); }
        }

        public IEnumerable<Identity> IdentityElements
        {
            get { return Elements<Identity>(Namespace.Identity); }
        }

        public IEnumerable<Feature> FeatureElements
        {
            get { return Elements<Feature>(Namespace.Feature); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Identity))]
    public class Identity : Tag
    {
        public Identity() : base(Namespace.Identity)
        {
        }

        public Identity(XElement other) : base(other)
        {
        }

        public string Category
        {
            get { return (string)GetAttributeValue("category"); }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Text out of range");
                }

                SetAttributeValue("category", value);
            }
        }

        public string Name
        {
            get { return (string)GetAttributeValue("name"); }
            set { SetAttributeValue("name", value); }
        }

        public string Type
        {
            get { return (string) GetAttributeValue("type"); }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Text out of range");
                }

                SetAttributeValue("type", value);
            }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Feature))]
    public class Feature : Tag
    {
        public Feature() : base(Namespace.Feature)
        {
        }

        public Feature(XElement other) : base(other)
        {
        }

        public string Var
        {
            get { return (string)GetAttributeValue("var"); }
            set { SetAttributeValue("var", value); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8' ?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='http://jabber.org/protocol/disco#info'
    xmlns='http://jabber.org/protocol/disco#info'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0030: http://www.xmpp.org/extensions/xep-0030.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:sequence minOccurs='0'>
        <xs:element ref='identity' maxOccurs='unbounded'/>
        <xs:element ref='feature' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='node' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='identity'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='category' type='nonEmptyString' use='required'/>
          <xs:attribute name='name' type='xs:string' use='optional'/>
          <xs:attribute name='type' type='nonEmptyString' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='feature'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='empty'>
          <xs:attribute name='var' type='xs:string' use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='nonEmptyString'>
    <xs:restriction base='xs:string'>
      <xs:minLength value='1'/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/