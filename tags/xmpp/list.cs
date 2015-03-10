using System.Collections.Generic;
using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Xmpp.Archive
{
    [XmppTag(typeof(Namespace), typeof(List))]
    public class List : Tag
    {
        public List() : base(Namespace.List)
        {
        }

        public List(XElement other)
            : base(other)
        {
        }

        public string EndAttr
        {
            get { return (string)GetAttributeValue("end"); }
            set { InnerElement.SetAttributeValue("end", value); }
        }

        public string ExactmatchAttr
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { InnerElement.SetAttributeValue("exactmatch", value); }
        }

        public string StartAttr
        {
            get { return (string)GetAttributeValue("start"); }
            set { InnerElement.SetAttributeValue("start", value); }
        }

        public string WithAttr
        {
            get { return (string)GetAttributeValue("with"); }
            set { InnerElement.SetAttributeValue("with", value); }
        }

        public IEnumerable<Chat> ChatElements
        {
            get { return Elements<Chat>(Namespace.Chat); }
        }
    }
}