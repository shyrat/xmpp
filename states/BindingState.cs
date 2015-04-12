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

using System.Linq;
using System.Xml.Linq;
using XMPP.Extensions;
using XMPP.Tags;
using XMPP.Tags.Jabber.Client;
using XMPP.Tags.XmppBind;
using XMPP.Ñommon;
using Namespace = XMPP.Tags.XmppBind.Namespace;

namespace XMPP.States
{
    public class BindingState : IState
    {
        public BindingState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            if (data == null)
            {
                var bind = new Bind();
                var iq = new Iq { IdAttr = Tag.NextId() };

                if (Manager.Settings.Id.Resource != null)
                {
                    Tag res = new Resource();
                    ((XElement)res).Value = Manager.Settings.Id.Resource;
                    bind.Add(res);
                }

                iq.TypeAttr = Iq.TypeEnum.set;
                iq.Add(bind);

                Manager.Connection.Send(iq);
            }
            else
            {
                Bind bind = null;

                var iq = data as Iq;
                if (iq != null)
                {
                    if (iq.TypeAttr == Iq.TypeEnum.error)
                    {
                        Error e = iq.ErrorElements.First();
                        if (e != null)
                        {
                            Manager.Events.Error(this, ErrorType.BindingToResourceFailed, ErrorPolicyType.Deactivate, ((XElement)e).Value);
                        }
                    }

                    bind = iq.Element<Bind>(Namespace.Bind);
                }

                if (bind != null)
                {
                    Tags.XmppBind.Jid jid = bind.Jid;
                    if (jid != null)
                        Manager.Settings.Id = jid.Value;
                }

#if DEBUG
                Manager.Events.LogMessage(this, LogType.Info, "Bind success, JID is now: {0}", Manager.Settings.Id);
#endif
                Manager.Events.Receive(this, data);
                Manager.Events.ResourceBound(this, Manager.Settings.Id.ToString());

                Manager.State = new SessionState(Manager);
                Manager.State.Execute();
            }
        }
    }
}