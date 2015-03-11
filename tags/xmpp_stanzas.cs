// Copyright 2004 John Reilly
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// Linking this library statically or dynamically with other modules is
// making a combined work based on this library.  Thus, the terms and
// conditions of the GNU General Public License cover the whole
// combination.

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.XmppStanzas
{
    public class Namespace
    {
        public const string Name = "urn:ietf:params:xml:ns:xmpp-stanzas";

        public static readonly XName BadRequest = XName.Get("bad-request", Name);
        public static readonly XName Conflict = XName.Get("conflict", Name);
        public static readonly XName FeatureNotImplemented = XName.Get("feature-not-implemented", Name);
        public static readonly XName Forbidden = XName.Get("forbidden", Name);
        public static readonly XName Gone = XName.Get("gone", Name);
        public static readonly XName InternalServerError = XName.Get("internal-server-error", Name);
        public static readonly XName ItemNotFound = XName.Get("item-not-found", Name);
        public static readonly XName JidMalformed = XName.Get("jid-malformed", Name);
        public static readonly XName NotAcceptable = XName.Get("not-acceptable", Name);
        public static readonly XName NotAuthorized = XName.Get("not-authorized", Name);
        public static readonly XName NotAllowed = XName.Get("not-allowed", Name);
        public static readonly XName PaymentRequired = XName.Get("payment-required", Name);
        public static readonly XName PolicyViolation = XName.Get("policy-violation", Name);
        public static readonly XName RecipientUnavailable = XName.Get("recipient-unavailable", Name);
        public static readonly XName Redirect = XName.Get("redirect", Name);
        public static readonly XName RegistrationRequired = XName.Get("registration-required", Name);
        public static readonly XName RemoteServerNotFound = XName.Get("remote-server-not-found", Name);
        public static readonly XName RemoteServerTimeout = XName.Get("remote-server-timeout", Name);
        public static readonly XName ResourceConstraint = XName.Get("resource-constraint", Name);
        public static readonly XName ServiceUnavailable = XName.Get("service-unavailable", Name);
        public static readonly XName SubscriptionRequired = XName.Get("subscription-required", Name);
        public static readonly XName UndefinedCondition = XName.Get("undefined-condition", Name);
        public static readonly XName UnexpectedRequest = XName.Get("unexpected-request", Name);
        public static readonly XName Text = XName.Get("text", Name);
    }


    [XmppTag(typeof(Namespace), typeof(BadRequest))]
    public class BadRequest : Tag
    {
        public BadRequest() : base(Namespace.BadRequest)
        {
        }

        public BadRequest(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Conflict))]
    public class Conflict : Tag
    {
        public Conflict() : base(Namespace.Conflict)
        {
        }

        public Conflict(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(FeatureNotImplemented))]
    public class FeatureNotImplemented : Tag
    {
        public FeatureNotImplemented() : base(Namespace.FeatureNotImplemented)
        {
        }

        public FeatureNotImplemented(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Forbidden))]
    public class Forbidden : Tag
    {
        public Forbidden() : base(Namespace.Forbidden)
        {
        }

        public Forbidden(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Gone))]
    public class Gone : Tag
    {
        public Gone() : base(Namespace.Gone)
        {
        }

        public Gone(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InternalServerError))]
    public class InternalServerError : Tag
    {
        public InternalServerError() : base(Namespace.InternalServerError)
        {
        }

        public InternalServerError(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ItemNotFound))]
    public class ItemNotFound : Tag
    {
        public ItemNotFound() : base(Namespace.ItemNotFound)
        {
        }

        public ItemNotFound(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(JidMalformed))]
    public class JidMalformed : Tag
    {
        public JidMalformed() : base(Namespace.JidMalformed)
        {
        }

        public JidMalformed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(NotAcceptable))]
    public class NotAcceptable : Tag
    {
        public NotAcceptable() : base(Namespace.NotAcceptable)
        {
        }

        public NotAcceptable(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(NotAuthorized))]
    public class NotAuthorized : Tag
    {
        public NotAuthorized() : base(Namespace.NotAuthorized)
        {
        }

        public NotAuthorized(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(NotAllowed))]
    public class NotAllowed : Tag
    {
        public NotAllowed() : base(Namespace.NotAllowed)
        {
        }

        public NotAllowed(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PaymentRequired))]
    public class PaymentRequired : Tag
    {
        public PaymentRequired() : base(Namespace.PaymentRequired)
        {
        }

        public PaymentRequired(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(PolicyViolation))]
    public class PolicyViolation : Tag
    {
        public PolicyViolation() : base(Namespace.PolicyViolation)
        {
        }

        public PolicyViolation(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RecipientUnavailable))]
    public class RecipientUnavailable : Tag
    {
        public RecipientUnavailable() : base(Namespace.RecipientUnavailable)
        {
        }

        public RecipientUnavailable(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Redirect))]
    public class Redirect : Tag
    {
        public Redirect() : base(Namespace.Redirect)
        {
        }

        public Redirect(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RegistrationRequired))]
    public class RegistrationRequired : Tag
    {
        public RegistrationRequired() : base(Namespace.RegistrationRequired)
        {
        }

        public RegistrationRequired(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RemoteServerNotFound))]
    public class RemoteServerNotFound : Tag
    {
        public RemoteServerNotFound() : base(Namespace.RemoteServerNotFound)
        {
        }

        public RemoteServerNotFound(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(RemoteServerTimeout))]
    public class RemoteServerTimeout : Tag
    {
        public RemoteServerTimeout() : base(Namespace.RemoteServerTimeout)
        {
        }

        public RemoteServerTimeout(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ResourceConstraint))]
    public class ResourceConstraint : Tag
    {
        public ResourceConstraint() : base(Namespace.ResourceConstraint)
        {
        }

        public ResourceConstraint(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(ServiceUnavailable))]
    public class ServiceUnavailable : Tag
    {
        public ServiceUnavailable() : base(Namespace.ServiceUnavailable)
        {
        }

        public ServiceUnavailable(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(SubscriptionRequired))]
    public class SubscriptionRequired : Tag
    {
        public SubscriptionRequired() : base(Namespace.SubscriptionRequired)
        {
        }

        public SubscriptionRequired(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UndefinedCondition))]
    public class UndefinedCondition : Tag
    {
        public UndefinedCondition() : base(Namespace.UndefinedCondition)
        {
        }

        public UndefinedCondition(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(UnexpectedRequest))]
    public class UnexpectedRequest : Tag
    {
        public UnexpectedRequest() : base(Namespace.UnexpectedRequest)
        {
        }

        public UnexpectedRequest(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Text))]
    public class Text : Tag
    {
        public Text() : base(Namespace.Text)
        {
        }

        public Text(XElement other) : base(other)
        {
        }

        public string LangAttr
        {
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.Name)); }
            set { InnerElement.SetAttributeValue(XName.Get("lang", Xml.Namespace.Name), value); }
        }

        public string Value
        {
            get { return InnerElement.Value; }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:ietf:params:xml:ns:xmpp-stanzas'
    xmlns='urn:ietf:params:xml:ns:xmpp-stanzas'
    elementFormDefault='qualified'>

  <xs:import namespace='http://www.w3.org/XML/1998/namespace'
             schemaLocation='http://www.w3.org/2001/03/xml.xsd'/>

  <xs:element name='bad-request' type='empty'/>
  <xs:element name='conflict' type='empty'/>
  <xs:element name='feature-not-implemented' type='empty'/>
  <xs:element name='forbidden' type='empty'/>
  <xs:element name='gone' type='xs:string'/>
  <xs:element name='internal-server-error' type='empty'/>
  <xs:element name='item-not-found' type='empty'/>
  <xs:element name='jid-malformed' type='empty'/>
  <xs:element name='not-acceptable' type='empty'/>
  <xs:element name='not-allowed' type='empty'/>
  <xs:element name='not-authorized' type='empty'/>
  <xs:element name='payment-required' type='empty'/>
  <xs:element name='policy-violation' type='empty'/>
  <xs:element name='recipient-unavailable' type='empty'/>
  <xs:element name='redirect' type='xs:string'/>
  <xs:element name='registration-required' type='empty'/>
  <xs:element name='remote-server-not-found' type='empty'/>
  <xs:element name='remote-server-timeout' type='empty'/>
  <xs:element name='resource-constraint' type='empty'/>
  <xs:element name='service-unavailable' type='empty'/>
  <xs:element name='subscription-required' type='empty'/>
  <xs:element name='undefined-condition' type='empty'/>
  <xs:element name='unexpected-request' type='empty'/>

  <xs:group name='stanzaErrorGroup'>
    <xs:choice>
      <xs:element ref='bad-request'/>
      <xs:element ref='conflict'/>
      <xs:element ref='feature-not-implemented'/>
      <xs:element ref='forbidden'/>
      <xs:element ref='gone'/>
      <xs:element ref='internal-server-error'/>
      <xs:element ref='item-not-found'/>
      <xs:element ref='jid-malformed'/>
      <xs:element ref='not-acceptable'/>
      <xs:element ref='not-authorized'/>
      <xs:element ref='not-allowed'/>
      <xs:element ref='payment-required'/>
      <xs:element ref='policy-violation'/>
      <xs:element ref='recipient-unavailable'/>
      <xs:element ref='redirect'/>
      <xs:element ref='registration-required'/>
      <xs:element ref='remote-server-not-found'/>
      <xs:element ref='remote-server-timeout'/>
      <xs:element ref='resource-constraint'/>
      <xs:element ref='service-unavailable'/>
      <xs:element ref='subscription-required'/>
      <xs:element ref='undefined-condition'/>
      <xs:element ref='unexpected-request'/>
    </xs:choice>
  </xs:group>

  <xs:element name='text'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute ref='xml:lang' use='optional'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:simpleType name='empty'>
    <xs:restriction base='xs:string'>
      <xs:enumeration value=''/>
    </xs:restriction>
  </xs:simpleType>

</xs:schema>

*/