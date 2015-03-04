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

        public string End
        {
            get { return (string)GetAttributeValue("end"); }
            set { SetAttributeValue("end", value); }
        }

        public string Exactmatch
        {
            get { return (string)GetAttributeValue("exactmatch"); }
            set { SetAttributeValue("exactmatch", value); }
        }

        public string Start
        {
            get { return (string)GetAttributeValue("start"); }
            set { SetAttributeValue("start", value); }
        }

        public string With
        {
            get { return (string)GetAttributeValue("with"); }
            set { SetAttributeValue("with", value); }
        }

        public IEnumerable<Chat> ChatElements
        {
            get { return Elements<Chat>(Namespace.Chat); }
        }
    }
}