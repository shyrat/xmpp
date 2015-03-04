// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="IDNAException.cs">
//   
// </copyright>
// <summary>
//   The idna exception.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Gnu.Inet.Encoding
{
    /// <summary>
    /// The idna exception.
    /// </summary>
    public class IDNAException : Exception
    {
        /// <summary>
        /// The contain s_ no n_ ldh.
        /// </summary>
        public static string CONTAINS_NON_LDH = "Contains non-LDH characters.";

        /// <summary>
        /// The contain s_ hyphen.
        /// </summary>
        public static string CONTAINS_HYPHEN = "Leading or trailing hyphen not allowed.";

        /// <summary>
        /// The contain s_ ac e_ prefix.
        /// </summary>
        public static string CONTAINS_ACE_PREFIX = "ACE prefix (xn--) not allowed.";

        /// <summary>
        /// The to o_ long.
        /// </summary>
        public static string TOO_LONG = "String too long.";

        /// <summary>
        /// Initializes a new instance of the <see cref="IDNAException"/> class.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public IDNAException(string m) : base(m)
        {
        }

        // TODO
        /// <summary>
        /// Initializes a new instance of the <see cref="IDNAException"/> class.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        public IDNAException(StringprepException e) : base(string.Empty, e)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IDNAException"/> class.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        public IDNAException(PunycodeException e) : base(string.Empty, e)
        {
        }
    }
}