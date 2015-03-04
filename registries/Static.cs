// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Static.cs">
//   
// </copyright>
// <summary>
//   The static.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

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
                    _nsManager.AddNamespace(string.Empty, Namespace.Name);
                    _nsManager.AddNamespace("stream", Tags.Streams.Namespace.Name);
                }

                return _nsManager;
            }
        }
    }
}