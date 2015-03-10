// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="archive.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Archive
{
    public class Namespace
    {
        public const string Name = "urn:xmpp:mam:tmp";

        public static readonly XName Query = XName.Get("query", Name);
        public static readonly XName With = XName.Get("with", Name);
        public static readonly XName Start = XName.Get("start", Name);
        public static readonly XName End = XName.Get("end", Name);
        public static readonly XName Result = XName.Get("result", Name);
        public static readonly XName Prefs = XName.Get("prefs", Name);
        public static readonly XName Always = XName.Get("always", Name);
        public static readonly XName Never = XName.Get("never", Name);
        public static readonly XName Jid = XName.Get("jid", Name);
    }

    [XmppTag(typeof(Namespace), typeof(Query))]
    public class Query : Tag
    {
        public Query() : base(Namespace.Query)
        {
        }

        public Query(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(With))]
    public class With : Tag
    {
        public With() : base(Namespace.With)
        {
        }

        public With(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Start))]
    public class Start : Tag
    {
        public Start() : base(Namespace.Start)
        {
        }

        public Start(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(End))]
    public class End : Tag
    {
        public End() : base(Namespace.End)
        {
        }

        public End(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Result))]
    public class Result : Tag
    {
        public Result() : base(Namespace.Result)
        {
        }

        public Result(XElement other) : base(other)
        {
        }

        public string QueryidAttr
        {
            get { return (string)GetAttributeValue("queryid"); }
            set { InnerElement.SetAttributeValue("queryid", value); }
        }

        public string IdAttr
        {
            get { return (string)GetAttributeValue("id"); }
            set { InnerElement.SetAttributeValue("id", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Prefs))]
    public class Prefs : Tag
    {
        public enum DefaultEnum
        {
            always, 
            never, 
            roster
        }

        public Prefs() : base(Namespace.Prefs)
        {
        }

        public Prefs(XElement other) : base(other)
        {
        }

        public DefaultEnum DefaultAttr
        {
            get { return GetAttributeEnum<DefaultEnum>("default"); }
            set { SetAttributeEnum<DefaultEnum>("default", value); }
        }
    }

    [XmppTag(typeof(Namespace), typeof(Always))]
    public class Always : Tag
    {
        public Always() : base(Namespace.Always)
        {
        }

        public Always(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Never))]
    public class Never : Tag
    {
        public Never() : base(Namespace.Never)
        {
        }

        public Never(XElement other) : base(other)
        {
        }
    }

    [XmppTag(typeof(Namespace), typeof(Jid))]
    public class Jid : Tag
    {
        public Jid()
            : base(Namespace.Jid)
        {
        }

        public Jid(XElement other)
            : base(other)
        {
        }
    }
}