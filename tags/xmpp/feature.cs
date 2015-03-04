using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Archive
{
    [XmppTag(typeof(Namespace), typeof(Feature))]
    public class Feature : Tag
    {
        public Feature() : base(Namespace.Feature)
        {
        }

        public Feature(XElement other) : base(other)
        {
        }

        public Default Default
        {
            get { return Element<Default>(Namespace.Default); }
        }
    }
}