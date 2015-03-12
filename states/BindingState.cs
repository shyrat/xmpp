// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="BindingState.cs">
//   
// </copyright>
// <summary>
//   The binding state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

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