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

namespace XMPP.Tags.Jabber.Protocol.archive
{
    /// <summary>
    /// The namespace.
    /// </summary>
    public class Namespace
    {
        /// <summary>
        /// The name.
        /// </summary>
        public const string Name = "urn:xmpp:mam:tmp";

        /// <summary>
        /// The query.
        /// </summary>
        public static XName query = XName.Get("query", Name);

        /// <summary>
        /// The with.
        /// </summary>
        public static XName with = XName.Get("with", Name);

        /// <summary>
        /// The start.
        /// </summary>
        public static XName start = XName.Get("start", Name);

        /// <summary>
        /// The end.
        /// </summary>
        public static XName end = XName.Get("end", Name);

        /// <summary>
        /// The result.
        /// </summary>
        public static XName result = XName.Get("result", Name);

        /// <summary>
        /// The prefs.
        /// </summary>
        public static XName prefs = XName.Get("prefs", Name);

        /// <summary>
        /// The always.
        /// </summary>
        public static XName always = XName.Get("always", Name);

        /// <summary>
        /// The never.
        /// </summary>
        public static XName never = XName.Get("never", Name);

        /// <summary>
        /// The jid.
        /// </summary>
        public static XName jid = XName.Get("jid", Name);
    }

    /// <summary>
    /// The query.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(query))]
    public class query : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        public query() : base(Namespace.query)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="query"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public query(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The with.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(with))]
    public class with : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="with"/> class.
        /// </summary>
        public with() : base(Namespace.with)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="with"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public with(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The start.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(start))]
    public class start : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="start"/> class.
        /// </summary>
        public start() : base(Namespace.start)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="start"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public start(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The end.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(end))]
    public class end : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="end"/> class.
        /// </summary>
        public end() : base(Namespace.end)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="end"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public end(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The result.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(result))]
    public class result : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="result"/> class.
        /// </summary>
        public result() : base(Namespace.result)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="result"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public result(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the queryid.
        /// </summary>
        public string queryid
        {
            get { return (string) GetAttributeValue("queryid"); }
            set { SetAttributeValue("queryid", value); }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string id
        {
            get { return (string) GetAttributeValue("id"); }
            set { SetAttributeValue("id", value); }
        }
    }

    /// <summary>
    /// The prefs.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(prefs))]
    public class prefs : Tag
    {
        /// <summary>
        /// The default enum.
        /// </summary>
        public enum defaultEnum
        {
            /// <summary>
            /// The always.
            /// </summary>
            always, 

            /// <summary>
            /// The never.
            /// </summary>
            never, 

            /// <summary>
            /// The roster.
            /// </summary>
            roster
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="prefs"/> class.
        /// </summary>
        public prefs() : base(Namespace.prefs)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="prefs"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public prefs(XElement other) : base(other)
        {
        }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public defaultEnum @default
        {
            get { return GetAttributeEnum<defaultEnum>("default"); }
            set { SetAttributeEnum<defaultEnum>("default", value); }
        }
    }

    /// <summary>
    /// The always.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(always))]
    public class always : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="always"/> class.
        /// </summary>
        public always() : base(Namespace.always)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="always"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public always(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The never.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(never))]
    public class never : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="never"/> class.
        /// </summary>
        public never() : base(Namespace.never)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="never"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public never(XElement other) : base(other)
        {
        }
    }

    /// <summary>
    /// The jid.
    /// </summary>
    [XmppTag(typeof(Namespace), typeof(jid))]
    public class jid : Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="jid"/> class.
        /// </summary>
        public jid() : base(Namespace.jid)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="jid"/> class.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        public jid(XElement other) : base(other)
        {
        }
    }
}