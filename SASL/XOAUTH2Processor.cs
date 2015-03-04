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
using XMPP.Ñommon;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;

namespace XMPP.SASL
{
    /// <summary>
    /// The xoaut h 2 processor.
    /// </summary>
    public class XOAUTH2Processor : SASLProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XOAUTH2Processor"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public XOAUTH2Processor(Manager manager) : base(manager)
        {
        }

        /// <summary>
        /// The step.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <returns>
        /// The <see cref="Tag"/>.
        /// </returns>
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

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <returns>
        /// The <see cref="Tag"/>.
        /// </returns>
        public override Tag Initialize()
        {
#if DEBUG
			Manager.Events.LogMessage(this, LogType.Debug, "Initializing XOAUTH2 Processor");
			Manager.Events.LogMessage(this, LogType.Debug, "ID User: {0}", Manager.Settings.Id);
#endif

            string token = string.Empty;

            var authtag = new Auth();

            authtag.Mechanism = MechanismType.Xoauth2;

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