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
using XMPP.Ñommon;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;

namespace XMPP.SASL
{
    /// <summary>
    /// The plain processor.
    /// </summary>
    public class PlainProcessor : SASLProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlainProcessor"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public PlainProcessor(Manager manager) : base(manager)
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
			Manager.Events.LogMessage(this, LogType.Debug, "Initializing Plain Processor");
			Manager.Events.LogMessage(this, LogType.Debug, "ID User: {0}", Manager.Settings.Id.User);
#endif
            var sb = new StringBuilder();

            sb.Append((char) 0);
            sb.Append(Manager.Settings.Id.User);
            sb.Append((char) 0);
            sb.Append(Manager.Settings.Password);

            var auth = new Auth();

            auth.Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));
            auth.Mechanism = MechanismType.Plain;

            return auth;
        }
    }
}