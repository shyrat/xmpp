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

using System.Xml.Linq;
using XMPP.Registries;
using XMPP.Tags.Jabber.Client;

namespace XMPP.Tags.Jabber.Protocol.Forwarded
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:forward:0";

        public static readonly XName Forwarded = XName.Get("forwarded", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Forwarded))]
    public class Forwarded : Tag
    {
        public Forwarded() : base(Namespace.Forwarded)
        {
        }

        public Forwarded(XElement other) : base(other)
        {
        }

        public Message MessageElement
        {
            get { return Element<Message>(Client.Namespace.Message); }
        }

        public Presence PresenceElement
        {
            get { return Element<Presence>(Client.Namespace.Presence); }
        }

        public Client.Iq IqElement
        {
            get { return Element<Client.Iq>(Client.Namespace.Iq); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:forward:0'
    xmlns='urn:xmpp:forward:0'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0297: http://www.xmpp.org/extensions/xep-0297.html
    </xs:documentation>
  </xs:annotation>

  <xs:import namespace='jabber:client'
             schemaLocation='http://xmpp.org/schemas/jabber-client.xsd'/>
  <xs:import namespace='jabber:server'
             schemaLocation='http://xmpp.org/schemas/jabber-server.xsd'/>
  <xs:import namespace='urn:xmpp:delay'
             schemaLocation='http://xmpp.org/schemas/delay.xsd'/>

  <xs:element name='forwarded'>
    <xs:complexType>
      <xs:sequence xmlns:delay='urn:xmpp:delay'
                   xmlns:client='jabber:client'
                   xmlns:server='jabber:server'>
        <xs:element ref='delay:delay' minOccurs='0' maxOccurs='1' />
        <xs:choice minOccurs='0' maxOccurs='1'>
          <xs:choice>
            <xs:element ref='client:message'/>
            <xs:element ref='client:presence'/>
            <xs:element ref='client:iq'/>
          </xs:choice>
          <xs:choice>
            <xs:element ref='server:message'/>
            <xs:element ref='server:presence'/>
            <xs:element ref='server:iq'/>
          </xs:choice>
        </xs:choice>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/