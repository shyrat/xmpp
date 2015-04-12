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
using System.Text;

namespace Gnu.Inet.Encoding
{
    /// <summary>
    /// The stringprep.
    /// </summary>
    public class Stringprep
    {
        /// <summary>
        /// The rf c 3920_ nodepre p_ prohibit.
        /// </summary>
        private static readonly char[] RFC3920_NODEPREP_PROHIBIT =
        {
            '\u0022', '\u0026', '\'', '\u002F', 
            '\u003A', '\u003C', '\u003E', '\u0040'
        };

        /// <summary>
        /// The saslpre p_ spac e_ map.
        /// </summary>
        public static string[] SASLPREP_SPACE_MAP =
        {
            "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", 
            "\u0020", "\u0020", "\u0020", "\u0020", "\u0020", "\u0020"
        };

        /// <summary>
        /// Preps a name according to the Stringprep profile defined in
        ///     RFC3491. Unassigned code points are not allowed.
        ///     *
        /// </summary>
        /// <param name="input">
        /// the name to prep.
        /// </param>
        /// <returns>
        /// the prepped name.
        ///     @throws StringprepException If the name cannot be prepped with
        ///     this profile.
        ///     @throws NullPointerException If the name is null.
        /// </returns>
        public static string NamePrep(string input)
        {
            return NamePrep(input, false);
        }

        /// <summary>
        /// Preps a name according to the Stringprep profile defined in
        ///     RFC3491.
        ///     *
        /// </summary>
        /// <param name="input">
        /// the name to prep.
        /// </param>
        /// <param name="allowUnassigned">
        /// true if the name may contain unassigned
        ///     code points.
        /// </param>
        /// <returns>
        /// the prepped name.
        ///     @throws StringprepException If the name cannot be prepped with
        ///     this profile.
        ///     @throws NullPointerException If the name is null.
        /// </returns>
        public static string NamePrep(string input, bool allowUnassigned)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }

            var s = new StringBuilder(input);

            if (!allowUnassigned && Contains(s, RFC3454.A1))
            {
                throw new StringprepException(StringprepException.ContainsUnassigned);
            }

            Filter(s, RFC3454.B1);
            Map(s, RFC3454.B2search, RFC3454.B2replace);

            s = new StringBuilder(NFKC.NormalizeNFKC(s.ToString()));

// B.3 is only needed if NFKC is not used, right?
            // map(s, RFC3454.B3search, RFC3454.B3replace);
            if (Contains(s, RFC3454.C12) || Contains(s, RFC3454.C22) || Contains(s, RFC3454.C3) ||
                Contains(s, RFC3454.C4) || Contains(s, RFC3454.C5) || Contains(s, RFC3454.C6) || Contains(s, RFC3454.C7) ||
                Contains(s, RFC3454.C8))
            {
                // Table C.9 only contains code points > 0xFFFF which Java
                // doesn't handle
                throw new StringprepException(StringprepException.ContainsProhibited);
            }

            // Bidi handling
            bool r = Contains(s, RFC3454.D1);
            bool l = Contains(s, RFC3454.D2);

            // RFC 3454, section 6, requirement 1: already handled above (table C.8)

            // RFC 3454, section 6, requirement 2
            if (r && l)
            {
                throw new StringprepException(StringprepException.BidiBothral);
            }

            // RFC 3454, section 6, requirement 3
            if (r)
            {
                if (!Contains(s[0], RFC3454.D1) || !Contains(s[s.Length - 1], RFC3454.D1))
                {
                    throw new StringprepException(StringprepException.BidiLtral);
                }
            }

            return s.ToString();
        }

        /**
		* Characters prohibited by RFC3920 nodeprep that aren't defined as
		* part of the RFC3454 tables.
		*/

        /// <summary>
        /// Preps a node name according to the Stringprep profile defined in
        ///     RFC3920. Unassigned code points are not allowed.
        ///     *
        /// </summary>
        /// <param name="input">
        /// the node name to prep.
        /// </param>
        /// <returns>
        /// the prepped node name.
        ///     @throws StringprepException If the node name cannot be prepped
        ///     with this profile.
        ///     @throws NullPointerException If the node name is null.
        /// </returns>
        public static string NodePrep(string input)
        {
            return NodePrep(input, false);
        }

        /// <summary>
        /// Preps a node name according to the Stringprep profile defined in RFC3920.
        /// </summary>
        /// <param name="input">
        /// the node name to prep.
        /// </param>
        /// <param name="allowUnassigned">
        /// true if the node name may contain
        ///     unassigned code points.
        /// </param>
        /// <returns>
        /// the prepped node name.
        ///     @throws StringprepException If the node name cannot be prepped
        ///     with this profile.
        ///     @throws NullPointerException If the node name is null.
        /// </returns>
        public static string NodePrep(string input, bool allowUnassigned)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }

            var s = new StringBuilder(input);

            if (!allowUnassigned && Contains(s, RFC3454.A1))
            {
                throw new StringprepException(StringprepException.ContainsUnassigned);
            }

            Filter(s, RFC3454.B1);
            Map(s, RFC3454.B2search, RFC3454.B2replace);

            s = new StringBuilder(NFKC.NormalizeNFKC(s.ToString()));

            if (Contains(s, RFC3454.C11) || Contains(s, RFC3454.C12) || Contains(s, RFC3454.C21) ||
                Contains(s, RFC3454.C22) || Contains(s, RFC3454.C3) || Contains(s, RFC3454.C4) ||
                Contains(s, RFC3454.C5) || Contains(s, RFC3454.C6) || Contains(s, RFC3454.C7) || Contains(s, RFC3454.C8) ||
                Contains(s, RFC3920_NODEPREP_PROHIBIT))
            {
                // Table C.9 only contains code points > 0xFFFF which Java
                // doesn't handle
                throw new StringprepException(StringprepException.ContainsProhibited);
            }

            // Bidi handling
            bool r = Contains(s, RFC3454.D1);
            bool l = Contains(s, RFC3454.D2);

            // RFC 3454, section 6, requirement 1: already handled above (table C.8)

            // RFC 3454, section 6, requirement 2
            if (r && l)
            {
                throw new StringprepException(StringprepException.BidiBothral);
            }

            // RFC 3454, section 6, requirement 3
            if (r)
            {
                if (!Contains(s[0], RFC3454.D1) || !Contains(s[s.Length - 1], RFC3454.D1))
                {
                    throw new StringprepException(StringprepException.BidiLtral);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// Preps a resource name according to the Stringprep profile defined
        ///     in RFC3920. Unassigned code points are not allowed.
        /// </summary>
        /// <param name="input">
        /// the resource name to prep.
        /// </param>
        /// <returns>
        /// the prepped node name.
        ///     @throws StringprepException If the resource name cannot be prepped
        ///     with this profile.
        ///     @throws NullPointerException If the resource name is null.
        /// </returns>
        public static string ResourcePrep(string input)
        {
            return ResourcePrep(input, false);
        }

        /// <summary>
        /// Preps a resource name according to the Stringprep profile defined
        ///     in RFC3920.
        /// </summary>
        /// <param name="input">
        /// the resource name to prep.
        /// </param>
        /// <param name="allowUnassigned">
        /// true if the resource name may contain
        ///     unassigned code points.
        /// </param>
        /// <returns>
        /// the prepped node name.
        ///     @throws StringprepException If the resource name cannot be prepped
        ///     with this profile.
        ///     @throws NullPointerException If the resource name is null.
        /// </returns>
        public static string ResourcePrep(string input, bool allowUnassigned)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }

            var s = new StringBuilder(input);

            if (!allowUnassigned && Contains(s, RFC3454.A1))
            {
                throw new StringprepException(StringprepException.ContainsUnassigned);
            }

            Filter(s, RFC3454.B1);

            s = new StringBuilder(NFKC.NormalizeNFKC(s.ToString()));

            if (Contains(s, RFC3454.C12) || Contains(s, RFC3454.C21) || Contains(s, RFC3454.C22) ||
                Contains(s, RFC3454.C3) || Contains(s, RFC3454.C4) || Contains(s, RFC3454.C5) || Contains(s, RFC3454.C6) ||
                Contains(s, RFC3454.C7) || Contains(s, RFC3454.C8))
            {
                // Table C.9 only contains code points > 0xFFFF which Java
                // doesn't handle
                throw new StringprepException(StringprepException.ContainsProhibited);
            }

            // Bidi handling
            bool r = Contains(s, RFC3454.D1);
            bool l = Contains(s, RFC3454.D2);

            // RFC 3454, section 6, requirement 1: already handled above (table C.8)

            // RFC 3454, section 6, requirement 2
            if (r && l)
            {
                throw new StringprepException(StringprepException.BidiBothral);
            }

            // RFC 3454, section 6, requirement 3
            if (r)
            {
                if (!Contains(s[0], RFC3454.D1) || !Contains(s[s.Length - 1], RFC3454.D1))
                {
                    throw new StringprepException(StringprepException.BidiLtral);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// The sasl prep.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="allowUnsigned">
        /// The allow unsigned.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="StringprepException">
        /// </exception>
        public static string SASLPrep(string input, bool allowUnsigned = false)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            var s = new StringBuilder(input);

            if (!allowUnsigned && Contains(s, RFC3454.A1))
            {
                throw new StringprepException(StringprepException.ContainsUnassigned);
            }

            Filter(s, RFC3454.B1);
            Map(s, RFC3454.C12, SASLPREP_SPACE_MAP);

            s = new StringBuilder(NFKC.NormalizeNFKC(s.ToString()));

            if (Contains(s, RFC3454.C12) || Contains(s, RFC3454.C21) || Contains(s, RFC3454.C22) ||
                Contains(s, RFC3454.C3) || Contains(s, RFC3454.C4) || Contains(s, RFC3454.C5) || Contains(s, RFC3454.C6) ||
                Contains(s, RFC3454.C7) || Contains(s, RFC3454.C8))
            {
                throw new StringprepException(StringprepException.ContainsProhibited);
            }

            bool r = Contains(s, RFC3454.D1);
            bool l = Contains(s, RFC3454.D2);

            if (r && l)
            {
                throw new StringprepException(StringprepException.BidiBothral);
            }

            if (r)
            {
                if (!Contains(s[0], RFC3454.D1) || !Contains(s[s.Length - 1], RFC3454.D1))
                {
                    throw new StringprepException(StringprepException.BidiLtral);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        internal static bool Contains(StringBuilder s, char[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                char c = p[i];
                for (int j = 0; j < s.Length; j++)
                {
                    if (c == s[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        internal static bool Contains(StringBuilder s, char[][] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                char[] r = p[i];
                if (1 == r.Length)
                {
                    char c = r[0];
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (c == s[j])
                        {
                            return true;
                        }
                    }
                }
                else if (2 == r.Length)
                {
                    char f = r[0];
                    char t = r[1];
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (f <= s[j] && t >= s[j])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        internal static bool Contains(char c, char[][] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                char[] r = p[i];
                if (1 == r.Length)
                {
                    if (c == r[0])
                    {
                        return true;
                    }
                }
                else if (2 == r.Length)
                {
                    char f = r[0];
                    char t = r[1];
                    if (f <= c && t >= c)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The filter.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="f">
        /// The f.
        /// </param>
        internal static void Filter(StringBuilder s, char[] f)
        {
            for (int i = 0; i < f.Length; i++)
            {
                char c = f[i];

                int j = 0;
                while (j < s.Length)
                {
                    if (c == s[j])
                    {
                        // s.deleteCharAt(j);
                        s.Remove(j, 1);
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        /// <summary>
        /// The filter.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="f">
        /// The f.
        /// </param>
        internal static void Filter(StringBuilder s, char[][] f)
        {
            for (int i = 0; i < f.Length; i++)
            {
                char[] r = f[i];

                if (1 == r.Length)
                {
                    char c = r[0];

                    int j = 0;
                    while (j < s.Length)
                    {
                        if (c == s[j])
                        {
                            // s.deleteCharAt(j);
                            s.Remove(j, 1);
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
                else if (2 == r.Length)
                {
                    char from = r[0];
                    char to = r[1];

                    int j = 0;
                    while (j < s.Length)
                    {
                        if (from <= s[j] && to >= s[j])
                        {
                            // s.deleteCharAt(j);
                            s.Remove(j, 1);
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="search">
        /// The search.
        /// </param>
        /// <param name="replace">
        /// The replace.
        /// </param>
        internal static void Map(StringBuilder s, char[] search, string[] replace)
        {
            for (int i = 0; i < search.Length; i++)
            {
                char c = search[i];

                int j = 0;
                while (j < s.Length)
                {
                    if (c == s[j])
                    {
                        // s.deleteCharAt(j);
                        s.Remove(j, 1);
                        if (null != replace[i])
                        {
                            s.Insert(j, replace[i]);
                            j += replace[i].Length - 1;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }
    }
}