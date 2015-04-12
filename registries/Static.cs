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

using System.Xml;
using XMPP.Tags.Jabber.Client;

namespace XMPP.Registries
{
    public class Static
    {
        public static readonly TagRegistry TagRegistry = new TagRegistry();

        public static readonly CompressionRegistry CompressionRegistry = new CompressionRegistry();

        public static readonly XmlReaderSettings Settings = new XmlReaderSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment, 
            IgnoreWhitespace = true
        };

        private static XmlNamespaceManager _nsManager;

        private static XmlParserContext _context;

        public static XmlParserContext Context
        {
            get { return _context ?? (_context = new XmlParserContext(null, NsManager, null, XmlSpace.None)); }
        }

        public static XmlNamespaceManager NsManager
        {
            get
            {
                if (_nsManager == null)
                {
                    _nsManager = new XmlNamespaceManager(new NameTable());
                    _nsManager.AddNamespace(string.Empty, Namespace.XmlNamespace);
                    _nsManager.AddNamespace("stream", Tags.Streams.Namespace.XmlNamespace);
                }

                return _nsManager;
            }
        }
    }
}