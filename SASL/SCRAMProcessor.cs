// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="SCRAMProcessor.cs">
//   
// </copyright>
// <summary>
//   The scram processor.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;
using Gnu.Inet.Encoding;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using XMPP.Tags;
using XMPP.Tags.XmppSasl;
using XMPP.Сommon;

namespace XMPP.SASL
{
    public class ScramProcessor : SaslProcessor
    {
        private readonly Encoding _utf = Encoding.UTF8;

        private string _clientFinal;
        private string _clientFirst;
        private string _clientProof;
        private int _i;
        private string _nonce;

        private byte[] _salt;
        private byte[] _serverFirst;
        private byte[] _serverSignature;

        private string _snonce;

        public ScramProcessor(Manager manager) : base(manager)
        {
        }

        public override Tag Initialize()
        {
            base.Initialize();
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Initializing SCRAM Processor");
            Manager.Events.LogMessage(this, LogType.Debug, "Generating nonce");
#endif
            _nonce = NextInt64().ToString();
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Nonce: {0}", _nonce);
            Manager.Events.LogMessage(this, LogType.Debug, "Building Initial Message");
#endif
            var msg = new StringBuilder();
            msg.Append("n,,n=");
            msg.Append(Id.User);
            msg.Append(",r=");
            msg.Append(_nonce);

#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Message: {0}", msg.ToString());
#endif

            _clientFirst = msg.ToString().Substring(3);

            var tag = new Auth();
            tag.MechanismAttr = MechanismType.Scram;
            tag.Bytes = _utf.GetBytes(msg.ToString());
            return tag;
        }

        public override Tag Step(Tag tag)
        {
            switch (((XElement)tag).Name.LocalName)
            {
                case "challenge":
                {
                    _serverFirst = tag.Bytes;
                    string response = _utf.GetString(tag.Bytes, 0, tag.Bytes.Length);

#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Challenge: {0}", response);
#endif

                    // Split challenge into pieces
                    string[] tokens = response.Split(',');

                    _snonce = tokens[0].Substring(2);

                    // Ensure that the first length of nonce is the same nonce we sent.
                    string r = _snonce.Substring(0, _nonce.Length);
                    if (0 != string.Compare(r, _nonce))
                    {
#if DEBUG
                        Manager.Events.LogMessage(this, LogType.Debug, "{0} does not match {1}", r, _nonce);
#endif
                    }

#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Getting Salt");
#endif
                    string a = tokens[1].Substring(2);
                    _salt = Convert.FromBase64String(a);
#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Getting Iterations");
#endif
                    string i = tokens[2].Substring(2);
                    _i = int.Parse(i);
#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Iterations: {0}", _i);
#endif

                    var final = new StringBuilder();
                    final.Append("c=biws,r=");
                    final.Append(_snonce);

                    _clientFinal = final.ToString();

                    CalculateProofs();

                    final.Append(",p=");
                    final.Append(_clientProof);

#if DEBUG
                    Manager.Events.LogMessage(this, LogType.Debug, "Final Message: {0}", final.ToString());
#endif

                    Tag resp = new Response();
                    resp.Bytes = _utf.GetBytes(final.ToString());

                    return resp;
                }

                case "success":
                {
                    string response = _utf.GetString(tag.Bytes, 0, tag.Bytes.Length);
                    byte[] signature = Convert.FromBase64String(response.Substring(2));
                    return _utf.GetString(signature, 0, signature.Length) ==
                           _utf.GetString(_serverSignature, 0, _serverSignature.Length)
                        ? tag
                        : null;
                }

                case "failure":
                    return tag;
            }

            return null;
        }

        private void CalculateProofs()
        {
            MacAlgorithmProvider hmac = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            HashAlgorithmProvider hash = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);

            byte[] saltedPassword = Hi();
            CryptographicKey hmacKey = hmac.CreateKey(saltedPassword.AsBuffer());

            // Calculate Client Key
            byte[] clientKey = CryptographicEngine.Sign(hmacKey, _utf.GetBytes("Client Key").AsBuffer()).ToArray();

            // Calculate Server Key
            byte[] serverKey = CryptographicEngine.Sign(hmacKey, _utf.GetBytes("Server Key").AsBuffer()).ToArray();

            // Calculate Stored Key
            byte[] storedKey = hash.HashData(clientKey.AsBuffer()).ToArray();

            var a = new StringBuilder();
            a.Append(_clientFirst);
            a.Append(",");
            a.Append(_utf.GetString(_serverFirst, 0, _serverFirst.Length));
            a.Append(",");
            a.Append(_clientFinal);

            byte[] auth = _utf.GetBytes(a.ToString());

            // Calculate Client Signature
            CryptographicKey storedKeyhmacKey = hmac.CreateKey(storedKey.AsBuffer());
            byte[] signature = CryptographicEngine.Sign(storedKeyhmacKey, auth.AsBuffer()).ToArray();

            // Calculate Server Signature
            CryptographicKey serverKeyhmacKey = hmac.CreateKey(serverKey.AsBuffer());
            _serverSignature = CryptographicEngine.Sign(serverKeyhmacKey, auth.AsBuffer()).ToArray();

            // Calculate Client Proof
            var proof = new byte[20];
            for (int i = 0; i < signature.Length; ++i)
            {
                proof[i] = (byte)(clientKey[i] ^ signature[i]);
            }

            _clientProof = Convert.ToBase64String(proof);
        }

        private byte[] Hi()
        {
            var prev = new byte[20];

            // Add 1 to the end of salt with most significat octet first
            var key = new byte[_salt.Length + 4];

            Array.Copy(_salt, key, _salt.Length);
            byte[] g = { 0, 0, 0, 1 };
            Array.Copy(g, 0, key, _salt.Length, 4);

            // Compute initial hash
            MacAlgorithmProvider hmac = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");

            // Create Key 
            IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(
                Stringprep.SASLPrep(Password),
                BinaryStringEncoding.Utf8);
            CryptographicKey hmacKey = hmac.CreateKey(passwordBuffer);

            byte[] result = CryptographicEngine.Sign(hmacKey, key.AsBuffer()).ToArray();

            Array.Copy(result, prev, result.Length);

            for (int i = 1; i < _i; ++i)
            {
                byte[] temp = CryptographicEngine.Sign(hmacKey, prev.AsBuffer()).ToArray();
                for (int j = 0; j < temp.Length; ++j)
                {
                    result[j] ^= temp[j];
                }

                Array.Copy(temp, prev, temp.Length);
            }

            return result;
        }
    }
}