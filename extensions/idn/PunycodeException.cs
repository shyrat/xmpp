// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="PunycodeException.cs">
//   
// </copyright>
// <summary>
//   The punycode exception.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Gnu.Inet.Encoding
{
    /// <summary>
    /// The punycode exception.
    /// </summary>
    public class PunycodeException : Exception
    {
        /// <summary>
        /// The overflow.
        /// </summary>
        public static string OVERFLOW = "Overflow.";

        /// <summary>
        /// The ba d_ input.
        /// </summary>
        public static string BAD_INPUT = "Bad input.";

        /// <summary>
        /// Initializes a new instance of the <see cref="PunycodeException"/> class. 
        /// Creates a new PunycodeException.
        /// </summary>
        /// <param name="message">
        /// message
        /// </param>
        public PunycodeException(string message) : base(message)
        {
        }
    }
}