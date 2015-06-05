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

using System.Xml.Linq;
using XMPP.Registries;

namespace XMPP.Tags.Jabber.Protocol.Archive
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:mam:tmp";

        public static readonly XName Query = XName.Get("query", XmlNamespace);
        public static readonly XName With = XName.Get("with", XmlNamespace);
        public static readonly XName Start = XName.Get("start", XmlNamespace);
        public static readonly XName End = XName.Get("end", XmlNamespace);
        public static readonly XName Result = XName.Get("result", XmlNamespace);
        public static readonly XName Prefs = XName.Get("prefs", XmlNamespace);
        public static readonly XName Always = XName.Get("always", XmlNamespace);
        public static readonly XName Never = XName.Get("never", XmlNamespace);
        public static readonly XName Jid = XName.Get("jid", XmlNamespace);
        public static readonly XName Fin = XName.Get("fin", XmlNamespace);
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

        public string Value
        {
            get { return InnerElement.Value; }
            set { InnerElement.Value = value; }
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

    [XmppTag(typeof(Namespace), typeof(Fin))]
    public class Fin : Tag
    {
        public Fin()
            : base(Namespace.Fin)
        {
        }

        public Fin(XElement other)
            : base(other)
        {
        }

        public bool? CompleteAttr
        {
            get { return GetAttributeValueAsBool("complete"); }
            set { InnerElement.SetAttributeValue("complete", value); }
        }
    }
}