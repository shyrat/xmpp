// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="SASLProcessor.cs">
//   
// </copyright>
// <summary>
//   The sasl processor.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Security.Cryptography;
using XMPP.Ñommon;
using XMPP.Tags;

namespace XMPP.SASL
{
    /// <summary>
    /// The sasl processor.
    /// </summary>
    public abstract class SASLProcessor
    {
        /// <summary>
        /// The manager.
        /// </summary>
        protected readonly Manager Manager;

        /// <summary>
        /// The _directives.
        /// </summary>
        private readonly Dictionary<string, string> _directives = new Dictionary<string, string>();

        /// <summary>
        /// The id.
        /// </summary>
        protected Jid Id;

        /// <summary>
        /// The password.
        /// </summary>
        protected string Password;

        /// <summary>
        /// Initializes a new instance of the <see cref="SASLProcessor"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public SASLProcessor(Manager manager)
        {
            Manager = manager;
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="directive">
        /// The directive.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string this[string directive]
        {
            get
            {
                if (_directives.ContainsKey(directive))
                    return _directives[directive];
                return null;
            }

            set { _directives[directive] = value; }
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
        public abstract Tag Step(Tag tag);

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <returns>
        /// The <see cref="Tag"/>.
        /// </returns>
        public virtual Tag Initialize()
        {
#if DEBUG
			Manager.Events.LogMessage(this, LogType.Debug, "Initializing Base Processor");
#endif

            Id = Manager.Settings.Id;
            Password = Manager.Settings.Password;

            return null;
        }

        /// <summary>
        /// The hex string.
        /// </summary>
        /// <param name="buff">
        /// The buff.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string HexString(byte[] buff)
        {
            var sb = new StringBuilder();
            foreach (byte b in buff)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// The next int 64.
        /// </summary>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        protected static long NextInt64()
        {
            byte[] bytes = CryptographicBuffer.GenerateRandom(sizeof (Int64)).ToArray();
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}