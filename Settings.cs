// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Settings.cs">
//   
// </copyright>
// <summary>
//   The mechanism type.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

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