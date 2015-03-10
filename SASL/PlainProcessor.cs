// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="PlainProcessor.cs">
//   
// </copyright>
// <summary>
//   The plain processor.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Ñommon;

namespace XMPP.SASL
{
    public class PlainProcessor : SaslProcessor
    {
        public PlainProcessor(Manager manager) : base(manager)
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
            Manager.Events.LogMessage(this, LogType.Debug, "Initializing Plain Processor");
            Manager.Events.LogMessage(this, LogType.Debug, "ID User: {0}", Manager.Settings.Id.User);
#endif
            var sb = new StringBuilder();

            sb.Append((char)0);
            sb.Append(Manager.Settings.Id.User);
            sb.Append((char)0);
            sb.Append(Manager.Settings.Password);

            var auth = new Auth
            {
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString())),
                MechanismAttr = MechanismType.Plain
            };

            return auth;
        }
    }
}