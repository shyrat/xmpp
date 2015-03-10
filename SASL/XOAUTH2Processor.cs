// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="XOAUTH2Processor.cs">
//   
// </copyright>
// <summary>
//   The xoaut h 2 processor.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Xml.Linq;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Ñommon;

namespace XMPP.SASL
{
    public class XOAuth2Processor : SaslProcessor
    {
        public XOAuth2Processor(Manager manager)
            : base(manager)
        {
        }

        public override Tag Step(Tag tag)
        {
            if (tag.Name.LocalName == "success")
            {
#if DEBUG
                Manager.Events.LogMessage(this, LogType.Debug, "Plan login successful");
#endif
            }

            return tag;
        }

        public override Tag Initialize()
        {
#if DEBUG
			Manager.Events.LogMessage(this, LogType.Debug, "Initializing XOAUTH2 Processor");
			Manager.Events.LogMessage(this, LogType.Debug, "ID User: {0}", Manager.Settings.Id);
#endif

            string token = string.Empty;

            var authtag = new Auth();

            authtag.MechanismAttr = MechanismType.Xoauth2;

            XNamespace auth = "http://www.google.com/talk/protocol/auth";
            authtag.Add(new XAttribute(XNamespace.Xmlns + "auth", "http://www.google.com/talk/protocol/auth"));
            authtag.Add(new XAttribute(auth + "service", "oauth2"));

            var sb = new StringBuilder();

            sb.Append((char) 0);
            sb.Append(Manager.Settings.Id);
            sb.Append((char) 0);
            sb.Append(token);

            authtag.Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));

            return authtag;
        }
    }
}