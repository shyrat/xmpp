// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The byte extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace XMPP.Extensions
{
    public static class ByteExtensions
    {
        public static byte[] TrimNull(this IList<byte> message)
        {
            if (message.Count > 1)
            {
                int c = message.Count - 1;
                while (message[c] == 0x00)
                {
                    c--;
                }

                var r = new byte[(c + 1)];
                for (int i = 0; i < (c + 1); i++)
                {
                    r[i] = message[i];
                }

                return r;
            }

            if (message[0] == 0x00)
                return null;

            var rsingle = new byte[1];
            rsingle[0] = message[0];
            return rsingle;
        }

        public static void Clear(this byte[] data)
        {
            Array.Clear(data, 0, data.Length);
        }
    }
}