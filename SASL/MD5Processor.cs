// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="MD5Processor.cs">
//   
// </copyright>
// <summary>
//   The m d 5 processor.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Windows.Security.Cryptography.Core;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Ñommon;

namespace XMPP.SASL
{
    public class Md5Processor : SaslProcessor
    {
        private readonly Regex _csv = new Regex(
            @"(?<tag>[^=]+)=(?:(?<data>[^,""]+)|(?:""(?<data>[^""]*)"")),?",
            RegexOptions.ExplicitCapture);

        private readonly Encoding _enc = Encoding.UTF8;

        private readonly HashAlgorithmProvider _md5 = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);

        private string _cnonce;

        private string _digestUri;

        private int _nc;

        private string _ncString;

        private string _responseHash;

        public Md5Processor(Manager manager) : base(manager)
        {
            _nc = 0;
        }

        public override Tag Initialize()
        {
            base.Initialize();

            return new Auth { MechanismAttr = MechanismType.DigestMd5 };
        }

        public override Tag Step(Tag tag)
        {
            if (((XElement)tag).Name.LocalName == "success")
            {
                Tag succ = tag;
                PopulateDirectives(succ);
#if DEBUG
                Manager.Events.LogMessage(this, LogType.Debug, "rspauth = {0}", this["rspauth"]);
#endif
                return succ;
            }

            if (((XElement)tag).Name.LocalName == "failure")
                return tag;

            Tag chall = tag;
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, _enc.GetString(tag.Bytes, 0, tag.Bytes.Length));
#endif
            PopulateDirectives(chall);
            Tag res = new Response();
            if (this["rspauth"] == null)
            {
                GenerateResponseHash();
                res.Bytes = GenerateResponse();
            }

            return res;
        }

        private void PopulateDirectives(Tag tag)
        {
            MatchCollection col = _csv.Matches(_enc.GetString(tag.Bytes, 0, tag.Bytes.Length));
            foreach (Match m in col)
            {
                this[m.Groups["tag"].Value] = m.Groups["data"].Value;
            }

            if (this["realm"] != null)
                _digestUri = "xmpp/" + this["realm"];
            else
                _digestUri = "xmpp/" + Id.Server;
        }

        private byte[] GenerateResponse()
        {
            var sb = new StringBuilder();
            sb.Append("username=\"");
            sb.Append(Id.User);
            sb.Append("\",");
            sb.Append("realm=\"");
            sb.Append(this["realm"]);
            sb.Append("\",");
            sb.Append("nonce=\"");
            sb.Append(this["nonce"]);
            sb.Append("\",");
            sb.Append("cnonce=\"");
            sb.Append(_cnonce);
            sb.Append("\",");
            sb.Append("nc=");
            sb.Append(_ncString);
            sb.Append(",");
            sb.Append("qop=");
            sb.Append(this["qop"]);
            sb.Append(",");
            sb.Append("digest-uri=\"");
            sb.Append(_digestUri);
            sb.Append("\",");
            sb.Append("response=");
            sb.Append(_responseHash);
            sb.Append(",");
            sb.Append("charset=");
            sb.Append(this["charset"]);
            string temp = sb.ToString();
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, temp);
#endif
            return _enc.GetBytes(temp);
        }

        private void GenerateResponseHash()
        {
            var ae = new UTF8Encoding();

            long v = NextInt64();

            // Create cnonce value using a random number, username and password
            var sb = new StringBuilder();
            sb.Append(v.ToString());
            sb.Append(":");
            sb.Append(Id.User);
            sb.Append(":");
            sb.Append(Password);

            _cnonce = HexString(ae.GetBytes(sb.ToString())).ToLower();

            // Create the nonce count which states how many times we have sent this packet.
            _nc++;
            _ncString = _nc.ToString().PadLeft(8, '0');

            // Create H1.  This value is the username/password portion of A1 according to the SASL DIGEST-MD5 RFC.
            sb.Remove(0, sb.Length);
            sb.Append(Id.User);
            sb.Append(":");
            sb.Append(this["realm"]);
            sb.Append(":");
            sb.Append(Password);
            byte[] h1 = _md5.HashData(ae.GetBytes(sb.ToString()).AsBuffer()).ToArray();

            // Create the rest of A1 as stated in the RFC.
            sb.Remove(0, sb.Length);
            sb.Append(":");
            sb.Append(this["nonce"]);
            sb.Append(":");
            sb.Append(_cnonce);

            if (this["authzid"] != null)
            {
                sb.Append(":");
                sb.Append(this["authzid"]);
            }

            string a1 = sb.ToString();

            // Combine H1 and A1 into final A1
            var ms = new MemoryStream();
            ms.Write(h1, 0, 16);
            byte[] temp = ae.GetBytes(a1);
            ms.Write(temp, 0, temp.Length);
            ms.Seek(0, SeekOrigin.Begin);
            h1 = _md5.HashData(ms.GetWindowsRuntimeBuffer()).ToArray();

            // Create A2
            sb.Remove(0, sb.Length);
            sb.Append("AUTHENTICATE:");
            sb.Append(_digestUri);
            if (this["qop"].CompareTo("auth") != 0)
            {
                sb.Append(":00000000000000000000000000000000");
            }

            string a2 = sb.ToString();
            byte[] h2 = _md5.HashData(ae.GetBytes(a2).AsBuffer()).ToArray();

            // Make A1 and A2 hex strings
            string p1 = HexString(h1).ToLower();
            string p2 = HexString(h2).ToLower();

            // Combine all portions into the final response hex string
            sb.Remove(0, sb.Length);
            sb.Append(p1);
            sb.Append(":");
            sb.Append(this["nonce"]);
            sb.Append(":");
            sb.Append(_ncString);
            sb.Append(":");
            sb.Append(_cnonce);
            sb.Append(":");
            sb.Append(this["qop"]);
            sb.Append(":");
            sb.Append(p2);

            string a3 = sb.ToString();
            byte[] h3 = _md5.HashData(ae.GetBytes(a3).AsBuffer()).ToArray();
            _responseHash = HexString(h3).ToLower();
        }
    }
}