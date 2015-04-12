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
// Temple Place, Suite 330, Boston, MA 02111-1307 USA-

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