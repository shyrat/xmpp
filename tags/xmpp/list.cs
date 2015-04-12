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