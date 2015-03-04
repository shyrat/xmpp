// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="StringprepException.cs">
//   
// </copyright>
// <summary>
//   The stringprep exception.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace
namespace Gnu.Inet.Encoding
{
    /// <summary>
    /// The stringprep exception.
    /// </summary>
    public class StringprepException : Exception
    {
        /// <summary>
        /// The contain s_ unassigned.
        /// </summary>
        public const string ContainsUnassigned = "Contains unassigned code points.";

        /// <summary>
        /// The contain s_ prohibited.
        /// </summary>
        public const string ContainsProhibited = "Contains prohibited code points.";

        /// <summary>
        /// The bid i_ bothral.
        /// </summary>
        public const string BidiBothral = "Contains both R and AL code points.";

        /// <summary>
        /// The bid i_ ltral.
        /// </summary>
        public const string BidiLtral = "Leading and trailing code points not both R or AL.";

        /// <summary>
        /// Initializes a new instance of the <see cref="StringprepException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public StringprepException(string message) : base(message)
        {
        }
    }
}