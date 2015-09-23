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

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Security.Cryptography;
using XMPP.Tags;
using XMPP.Common;

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