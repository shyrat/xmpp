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
using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.SASL
{
    /// <summary>
    /// The sasl processor.
    /// </summary>
    public abstract class SaslProcessor
    {
        protected readonly Manager Manager;

        private readonly Dictionary<string, string> _directives = new Dictionary<string, string>();

        protected Jid Id;

        protected string Password;

        protected SaslProcessor(Manager manager)
        {
            Manager = manager;
        }

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

        public abstract Tag Step(Tag tag);

        public virtual Tag Initialize()
        {
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Initializing Base Processor");
#endif

            Id = Manager.Settings.Id;
            Password = Manager.Settings.Password;

            return null;
        }

        protected string HexString(byte[] buff)
        {
            var sb = new StringBuilder();
            foreach (byte b in buff)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        protected static long NextInt64()
        {
            byte[] bytes = CryptographicBuffer.GenerateRandom(sizeof(Int64)).ToArray();
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}