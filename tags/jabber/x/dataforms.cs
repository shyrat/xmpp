// Copyright © 2006 - 2012 Dieter Lunn
// Modified 2012 Paul Freund ( freund.paul@lvl3.org )
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
// You should have received a copy of the GNU Lesser General Public License along
// with this library; if not, write to the Free Software Foundation, Inc., 59
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.X.Dataforms
{
    public class Namespace
    {
        public const string XmlNamespace = "jabber:x:data";

        public static readonly XName X = XName.Get("x", XmlNamespace);
        public static readonly XName Title = XName.Get("title", XmlNamespace);
        public static readonly XName Item = XName.Get("item", XmlNamespace);
        public static readonly XName Reported = XName.Get("reported", XmlNamespace);
        public static readonly XName Field = XName.Get("field", XmlNamespace);
        public static readonly XName Desc = XName.Get("desc", XmlNamespace);
        public static readonly XName Value = XName.Get("value", XmlNamespace);
        public static readonly XName Option = XName.Get("option", XmlNamespace);
        public static readonly XName Required = XName.Get("required", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(X))]
    public class X : Tag
    {
        public enum TypeEnum
        {
            cancel,
            form,
            result,
            submit
        }

        public X() : base(Namespace.X)
        {
        }

        public X(XElement other) : base(other)
        {
        }

        public IEnumerable<Field> FieldElements
        {
            get { return Elements<Field>(Namespace.Field); }
        }

        public IEnumerable<Item> ItemElements
        {
            get { return Elements<Item>(Namespace.Item); }
        }

        public TypeEnum TypeAttr
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Title))]
    public class Title : Tag
    {
        public Title() : base(Namespace.Title)
        {
        }

        public Title(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Item))]
    public class Item : Tag
    {
        public Item() : base(Namespace.Item)
        {
        }

        public Item(XElement other) : base(other)
        {
        }

        public IEnumerable<Field> FieldElements
        {
            get { return Elements<Field>(Namespace.Field); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Reported))]
    public class Reported : Tag
    {
        public Reported() : base(Namespace.Item)
        {
        }

        public Reported(XElement other) : base(other)
        {
        }

        public IEnumerable<Field> FieldElements
        {
            get { return Elements<Field>(Namespace.Field); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Field))]
    public class Field : Tag
    {
        public enum TypeEnum
        {
            boolean,
            @fixed,
            hidden,
            [EnumMember(Value = "jid-multi")]
            jid_multi,
            [EnumMember(Value = "jid-single")]
            jid_single,
            [EnumMember(Value = "list-multi")]
            list_multi,
            [EnumMember(Value = "list-single")]
            list_single,
            [EnumMember(Value = "text-multi")]
            text_multi,
            [EnumMember(Value = "text-private")]
            text_private,
            [EnumMember(Value = "text-single")]
            text_single
        }

        public Field() : base(Namespace.Field)
        {
        }

        public Field(XElement other) : base(other)
        {
        }

        public Desc Desc
        {
            get { return Element<Desc>(Namespace.Desc); }
        }

        public Required Required
        {
            get { return Element<Required>(Namespace.Required); }
        }

        public IEnumerable<Value> ValueElements
        {
            get { return Elements<Value>(Namespace.Value); }
        }

        public IEnumerable<Option> OptionElements
        {
            get { return Elements<Option>(Namespace.Option); }
        }

        public string LabelAttr
        {
            get { return (string)GetAttributeValue("label"); }
            set { InnerElement.SetAttributeValue("label", value); }
        }

        public TypeEnum TypeAttr
        {
            get { return GetAttributeEnum<TypeEnum>("type"); }
            set { SetAttributeEnum<TypeEnum>("type", value); }
        }

        public string VarAttr
        {
            get { return (string)GetAttributeValue("var"); }
            set { InnerElement.SetAttributeValue("var", value); }
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Desc))]
    public class Desc : Tag
    {
        public Desc() : base(Namespace.Desc)
        {
        }

        public Desc(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Value))]
    public class Value : Tag
    {
        public Value() : base(Namespace.Value)
        {
        }

        public Value(XElement other) : base(other)
        {
        }

        public Value(string value)
            : base(Namespace.Value)
        {
            InnerElement.Value = value;
        }

        public string GetValue()
        {
            return InnerElement.Value;
        }
    }

    [XmppTag(typeof(Namespace), typeof(Option))]
    public class Option : Tag
    {
        public Option() : base(Namespace.Option)
        {
        }

        public Option(XElement other) : base(other)
        {
        }

        public string LabelAttr
        {
            get { return (string)GetAttributeValue("label"); }
            set { InnerElement.SetAttributeValue("label", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Required))]
    public class Required : Tag
    {
        public Required() : base(Namespace.Required)
        {
        }

        public Required(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:x:data'
    xmlns='jabber:x:data'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0004: http://www.xmpp.org/extensions/xep-0004.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='x'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='instructions' 
                    minOccurs='0' 
                    maxOccurs='unbounded' 
                    type='xs:string'/>
        <xs:element name='title' minOccurs='0' type='xs:string'/>
        <xs:element ref='field' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='reported' minOccurs='0' maxOccurs='1'/>
        <xs:element ref='item' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='type' use='required'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='cancel'/>
            <xs:enumeration value='form'/>
            <xs:enumeration value='result'/>
            <xs:enumeration value='submit'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
    </xs:complexType>
  </xs:element>

  <xs:element name='field'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='desc' minOccurs='0' type='xs:string'/>
        <xs:element name='required' minOccurs='0' type='empty'/>
        <xs:element ref='value' minOccurs='0' maxOccurs='unbounded'/>
        <xs:element ref='option' minOccurs='0' maxOccurs='unbounded'/>
      </xs:sequence>
      <xs:attribute name='label' type='xs:string' use='optional'/>
      <xs:attribute name='type' use='optional' default='text-single'>
        <xs:simpleType>
          <xs:restriction base='xs:NCName'>
            <xs:enumeration value='boolean'/>
            <xs:enumeration value='fixed'/>
            <xs:enumeration value='hidden'/>
            <xs:enumeration value='jid-multi'/>
            <xs:enumeration value='jid-single'/>
            <xs:enumeration value='list-multi'/>
            <xs:enumeration value='list-single'/>
            <xs:enumeration value='text-multi'/>
            <xs:enumeration value='text-private'/>
            <xs:enumeration value='text-single'/>
          </xs:restriction>
        </xs:simpleType>
      </xs:attribute>
      <xs:attribute name='var' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='option'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='value'/>
      </xs:sequence>
      <xs:attribute name='label' type='xs:string' use='optional'/>
    </xs:complexType>
  </xs:element>

  <xs:element name='value' type='xs:string'/>

  <xs:element name='reported'>
    <xs:annotation>
      <xs:documentation>
        When contained in a "reported" element, the "field" element
        SHOULD NOT contain a "value" child.
      </xs:documentation>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='field' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='item'>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref='field' maxOccurs='unbounded'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>
*/