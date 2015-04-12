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