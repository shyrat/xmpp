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

namespace XMPP
{
    [Flags]
    public enum MechanismType
    {
        None,
        Plain = 1 << 0,
        DigestMd5 = 1 << 1,
        External = 1 << 2,
        Scram = 1 << 3,
        Xoauth2 = 1 << 4,
        Default = Scram | DigestMd5
    }
}

namespace XMPP.Сommon
{
    public class Settings
    {
        public MechanismType AuthenticationTypes = MechanismType.Default;

        public string Hostname;

        public Jid Id;

        public int KeepAliveTime = 60;

        public bool OldSSL = false;

        public string Password;

        public int Port = 5222;

        public int QueryCount = 50;
        public bool SSL = false;

        public bool UseKeepAlive = false;
    }
}