using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Iq.Gateway
{
    public class Namespace
    {
        public const string Name = "jabber:iq:gateway";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName Desc = XName.Get("desc", Name);
        public static readonly XName Prompt = XName.Get("prompt", Name);
        public static readonly XName Jid = XName.Get("jid", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query()
            : base(Namespace.Query)
        {
        }

        public Query(XElement other)
            : base(other)
        {
        }

        public jid Jid
        {
            get { return Element<jid>(Namespace.Jid); }
        }

        public IEnumerable<Desc> DescElements
        {
            get { return Elements<Desc>(Namespace.Desc); }
        }

        public IEnumerable<Prompt> PromptElements
        {
            get { return Elements<Prompt>(Namespace.Prompt); }
        }
    }


    [XmppTag(typeof(Namespace), typeof(Desc))]
    public class Desc : Tag
    {
        public Desc()
            : base(Namespace.Desc)
        {
        }

        public Desc(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Prompt))]
    public class Prompt : Tag
    {
        public Prompt()
            : base(Namespace.Prompt)
        {
        }

        public Prompt(XElement other)
            : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(jid))]
    public class jid : Tag
    {
        public jid()
            : base(Namespace.Jid)
        {
        }

        public jid(XElement other)
            : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='jabber:iq:gateway'
    xmlns='jabber:iq:gateway'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0100: http://www.xmpp.org/extensions/xep-0100.html
    </xs:documentation>
  </xs:annotation>

  <xs:element name='query'>
    <xs:complexType>
      <xs:choice>
        <xs:sequence>
          <xs:element name='desc' minOccurs='0' type='xs:string'/>
          <xs:element name='prompt' type='xs:string'/>
        </xs:sequence>
        <xs:element name='jid' type='xs:string'/>
      </xs:choice>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/