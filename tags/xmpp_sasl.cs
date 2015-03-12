// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="xmpp_sasl.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.XmppSasl
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:ietf:params:xml:ns:xmpp-sasl";

        public static readonly XName Mechanisms = XName.Get("mechanisms", XmlNamespace);
        public static readonly XName Mechanism = XName.Get("mechanism", XmlNamespace);
        public static readonly XName Abort = XName.Get("abort", XmlNamespace);
        public static readonly XName Auth = XName.Get("auth", XmlNamespace);
        public static readonly XName Challenge = XName.Get("challenge", XmlNamespace);
        public static readonly XName Response = XName.Get("response", XmlNamespace);
        public static readonly XName Success = XName.Get("success", XmlNamespace);
        public static readonly XName Failure = XName.Get("failure", XmlNamespace);
        public static readonly XName Text = XName.Get("text", XmlNamespace);
        public static readonly XName BadProtocol = XName.Get("bad-protocol", XmlNamespace);
        public static readonly XName MalformedRequest = XName.Get("malformed-request", XmlNamespace);
        public static readonly XName Aborted = XName.Get("aborted", XmlNamespace);
        public static readonly XName AccountDisabled = XName.Get("account-disabled", XmlNamespace);
        public static readonly XName CredentialsExpired = XName.Get("credentials-expired", XmlNamespace);
        public static readonly XName EncryptionRequired = XName.Get("encryption-required", XmlNamespace);
        public static readonly XName IncorrectEncoding = XName.Get("incorrect-encoding", XmlNamespace);
        public static readonly XName InvalidAuthzid = XName.Get("invalid-authzid", XmlNamespace);
        public static readonly XName InvalidMechanism = XName.Get("invalid-mechanism", XmlNamespace);
        public static readonly XName MechanismTooWeak = XName.Get("mechanism-too-weak", XmlNamespace);
        public static readonly XName NotAuthorized = XName.Get("not-authorized", XmlNamespace);
        public static readonly XName TemporaryAuthFailure = XName.Get("temporary-auth-failure", XmlNamespace);
        public static readonly XName TransitionNeeded = XName.Get("transition-needed", XmlNamespace);
        public static readonly XName Required = XName.Get("required", XmlNamespace);
        public static readonly XName Optional = XName.Get("optional", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Mechanisms))]
    public class Mechanisms : Tag
    {
        public Mechanisms() : base(Namespace.Mechanisms)
        {
        }

        public Mechanisms(XElement other) : base(other)
        {
        }

        public MechanismType Types
        {
            get { return MechanismElements.Aggregate(MechanismType.None, (current, m) => current | m.Type); }
        }

        public IEnumerable<Mechanism> MechanismElements
        {
            get { return Elements<Mechanism>(Namespace.Mechanism); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Mechanism))]
    public class Mechanism : Tag
    {
        public Mechanism() : base(Namespace.Mechanism)
        {
        }

        public Mechanism(XElement other) : base(other)
        {
        }

        public MechanismType Type
        {
            get { return ToType(InnerElement.Value); }
            set { InnerElement.Value = ToString(value); }
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }

        public static MechanismType ToType(string type)
        {
            switch (type)
            {
                case "PLAIN":
                    return MechanismType.Plain;
                case "DIGEST-MD5":
                    return MechanismType.DigestMd5;
                case "EXTERNAL":
                    return MechanismType.External;
                case "SCRAM-SHA-1":
                    return MechanismType.Scram;
                case "X-OAUTH2":
                    return MechanismType.Xoauth2;
                default:
                    return MechanismType.None;
            }
        }

        public static string ToString(MechanismType type)
        {
            switch (type)
            {
                case MechanismType.Plain:
                    return "PLAIN";
                case MechanismType.External:
                    return "EXTERNAL";
                case MechanismType.DigestMd5:
                    return "DIGEST-MD5";
                case MechanismType.Scram:
                    return "SCRAM-SHA-1";
                case MechanismType.Xoauth2:
                    return "X-OAUTH2";
                default:
                    return string.Empty;
            }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Abort))]
    public class Abort : Tag
    {
        public Abort() : base(Namespace.Abort)
        {
        }

        public Abort(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Auth))]
    public class Auth : Tag
    {
        public Auth() : base(Namespace.Auth)
        {
        }

        public Auth(XElement other) : base(other)
        {
        }

        public MechanismType MechanismAttr
        {
            get { return Mechanism.ToType((string)GetAttributeValue("mechanism")); }
            set { InnerElement.SetAttributeValue("mechanism", Mechanism.ToString(value)); }
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Challenge))]
    public class Challenge : Tag
    {
        public Challenge() : base(Namespace.Challenge)
        {
        }

        public Challenge(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Response))]
    public class Response : Tag
    {
        public Response() : base(Namespace.Response)
        {
        }

        public Response(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Success))]
    public class Success : Tag
    {
        public Success() : base(Namespace.Success)
        {
        }

        public Success(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Failure))]
    public class Failure : Tag
    {
        public enum TypeEnum
        {
            none,
            aborted,
            account_disabled,
            credentials_expired,
            encryption_required,
            incorrect_encoding,
            invalid_authzid,
            invalid_mechanism,
            mechanism_too_weak,
            not_authorized,
            temporary_auth_failure,
            transition_needed
        }

        public Failure() : base(Namespace.Failure)
        {
        }

        public Failure(XElement other) : base(other)
        {
        }

        public TypeEnum Types
        {
            get
            {
                var types = TypeEnum.none;
                if (Aborted != null) types = types | TypeEnum.aborted;
                if (AccountDisabled != null) types = types | TypeEnum.account_disabled;
                if (CredentialsExpired != null) types = types | TypeEnum.credentials_expired;
                if (EncryptionRequired != null) types = types | TypeEnum.encryption_required;
                if (IncorrectEncoding != null) types = types | TypeEnum.incorrect_encoding;
                if (InvalidAuthzid != null) types = types | TypeEnum.invalid_authzid;
                if (InvalidMechanism != null) types = types | TypeEnum.invalid_mechanism;
                if (MechanismTooWeak != null) types = types | TypeEnum.mechanism_too_weak;
                if (NotAuthorized != null) types = types | TypeEnum.not_authorized;
                if (TemporaryAuthFailure != null) types = types | TypeEnum.temporary_auth_failure;
                if (TransitionNeeded != null) types = types | TypeEnum.transition_needed;
                return types;
            }
        }

        public Aborted Aborted
        {
            get { return Element<Aborted>(Namespace.Aborted); }
        }

        public AccountDisabled AccountDisabled
        {
            get { return Element<AccountDisabled>(Namespace.AccountDisabled); }
        }

        public CredentialsExpired CredentialsExpired
        {
            get { return Element<CredentialsExpired>(Namespace.CredentialsExpired); }
        }

        public EncryptionRequired EncryptionRequired
        {
            get { return Element<EncryptionRequired>(Namespace.EncryptionRequired); }
        }

        public IncorrectEncoding IncorrectEncoding
        {
            get { return Element<IncorrectEncoding>(Namespace.IncorrectEncoding); }
        }

        public InvalidAuthzid InvalidAuthzid
        {
            get { return Element<InvalidAuthzid>(Namespace.InvalidAuthzid); }
        }

        public InvalidMechanism InvalidMechanism
        {
            get { return Element<InvalidMechanism>(Namespace.InvalidMechanism); }
        }

        public MechanismTooWeak MechanismTooWeak
        {
            get { return Element<MechanismTooWeak>(Namespace.MechanismTooWeak); }
        }

        public NotAuthorized NotAuthorized
        {
            get { return Element<NotAuthorized>(Namespace.NotAuthorized); }
        }

        public TemporaryAuthFailure TemporaryAuthFailure
        {
            get { return Element<TemporaryAuthFailure>(Namespace.TemporaryAuthFailure); }
        }

        public TransitionNeeded TransitionNeeded
        {
            get { return Element<TransitionNeeded>(Namespace.TransitionNeeded); }
        }

        public IEnumerable<Text> TextElements
        {
            get { return Elements<Text>(Namespace.Text); }
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
            get { return (string)GetAttributeValue(XName.Get("lang", Xml.Namespace.XmlNamespace)); }
            set { InnerElement.SetAttributeValue(XName.Get("lang", Xml.Namespace.XmlNamespace), value); }
        }

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
        }
    }

    [XmppTag(typeof(Namespace), typeof(BadProtocol))]
    public class BadProtocol : Tag
    {
        public BadProtocol() : base(Namespace.BadProtocol)
        {
        }

        public BadProtocol(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(MalformedRequest))]
    public class MalformedRequest : Tag
    {
        public MalformedRequest() : base(Namespace.MalformedRequest)
        {
        }

        public MalformedRequest(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Aborted))]
    public class Aborted : Tag
    {
        public Aborted() : base(Namespace.Aborted)
        {
        }

        public Aborted(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(AccountDisabled))]
    public class AccountDisabled : Tag
    {
        public AccountDisabled() : base(Namespace.AccountDisabled)
        {
        }

        public AccountDisabled(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(CredentialsExpired))]
    public class CredentialsExpired : Tag
    {
        public CredentialsExpired() : base(Namespace.CredentialsExpired)
        {
        }

        public CredentialsExpired(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(EncryptionRequired))]
    public class EncryptionRequired : Tag
    {
        public EncryptionRequired() : base(Namespace.EncryptionRequired)
        {
        }

        public EncryptionRequired(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(IncorrectEncoding))]
    public class IncorrectEncoding : Tag
    {
        public IncorrectEncoding() : base(Namespace.IncorrectEncoding)
        {
        }

        public IncorrectEncoding(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidAuthzid))]
    public class InvalidAuthzid : Tag
    {
        public InvalidAuthzid() : base(Namespace.InvalidAuthzid)
        {
        }

        public InvalidAuthzid(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(InvalidMechanism))]
    public class InvalidMechanism : Tag
    {
        public InvalidMechanism() : base(Namespace.InvalidMechanism)
        {
        }

        public InvalidMechanism(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(MechanismTooWeak))]
    public class MechanismTooWeak : Tag
    {
        public MechanismTooWeak() : base(Namespace.MechanismTooWeak)
        {
        }

        public MechanismTooWeak(XElement other) : base(other)
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

    [XmppTag(typeof(Namespace), typeof(TemporaryAuthFailure))]
    public class TemporaryAuthFailure : Tag
    {
        public TemporaryAuthFailure() : base(Namespace.TemporaryAuthFailure)
        {
        }

        public TemporaryAuthFailure(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(TransitionNeeded))]
    public class TransitionNeeded : Tag
    {
        public TransitionNeeded() : base(Namespace.TransitionNeeded)
        {
        }

        public TransitionNeeded(XElement other) : base(other)
        {
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

    [XmppTag(typeof(Namespace), typeof(Optional))]
    public class Optional : Tag
    {
        public Optional() : base(Namespace.Optional)
        {
        }

        public Optional(XElement other) : base(other)
        {
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:ietf:params:xml:ns:xmpp-sasl'
    xmlns='urn:ietf:params:xml:ns:xmpp-sasl'
    elementFormDefault='qualified'>

  <xs:import namespace='http://www.w3.org/XML/1998/namespace'
             schemaLocation='http://www.w3.org/2001/03/xml.xsd'/>

  <xs:element name='mechanisms'>
    <xs:complexType>
      <xs:sequence>
        <xs:element name='mechanism'
                    minOccurs='1'
                    maxOccurs='unbounded'
                    type='xs:NMTOKEN'/>
        <xs:any namespace='##other'
                minOccurs='0'
                maxOccurs='unbounded'
                processContents='lax'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

  <xs:element name='abort' type='empty'/>

  <xs:element name='auth'>
    <xs:complexType>
      <xs:simpleContent>
        <xs:extension base='xs:string'>
          <xs:attribute name='mechanism'
                        type='xs:NMTOKEN'
                        use='required'/>
        </xs:extension>
      </xs:simpleContent>
    </xs:complexType>
  </xs:element>

  <xs:element name='challenge' type='xs:string'/>

  <xs:element name='response' type='xs:string'/>

  <xs:element name='success' type='xs:string'/>

  <xs:element name='failure'>
    <xs:complexType>
      <xs:sequence>
        <xs:choice minOccurs='0'>
          <xs:element name='aborted' type='empty'/>
          <xs:element name='account-disabled' type='empty'/>
          <xs:element name='credentials-expired' type='empty'/>
          <xs:element name='encryption-required' type='empty'/>
          <xs:element name='incorrect-encoding' type='empty'/>
          <xs:element name='invalid-authzid' type='empty'/>
          <xs:element name='invalid-mechanism' type='empty'/>
          <xs:element name='malformed-request' type='empty'/>
          <xs:element name='mechanism-too-weak' type='empty'/>
          <xs:element name='not-authorized' type='empty'/>
          <xs:element name='temporary-auth-failure' type='empty'/>
          <xs:element name='transition-needed' type='empty'/>
        </xs:choice>
        <xs:element ref='text' minOccurs='0' maxOccurs='1'/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

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