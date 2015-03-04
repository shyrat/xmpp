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
                var bindMsg = new Bind();
                var iqMsg = new Iq { Id = Tag.NextId() };

                if (Manager.Settings.Id.Resource != null)
                {
                    Tag res = new Resource();
                    res.Value = Manager.Settings.Id.Resource;
                    bindMsg.Add(res);
                }

                iqMsg.Type = Iq.TypeEnum.set;
                iqMsg.Add(bindMsg);

                Manager.Connection.Send(iqMsg);
            }
            else
            {
                var iq = data as Iq;
                Bind bind = null;
                if (iq != null)
                {
                    if (iq.Type == Iq.TypeEnum.error)
                    {
                        Error e = iq.ErrorElements.First();
                        if (e != null)
                        {
                            Manager.Events.Error(this, ErrorType.BindingToResourceFailed, ErrorPolicyType.Deactivate, e.Value);
                        }
                    }

                    bind = iq.Element<Bind>(Namespace.Bind);
                }

                if (bind != null)
                {
                    Tags.XmppBind.Jid jid = bind.Jid;
                    if (jid != null)
                        Manager.Settings.Id = jid.JID;
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