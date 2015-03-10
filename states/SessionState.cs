// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="SessionState.cs">
//   
// </copyright>
// <summary>
//   The session state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Tags.Jabber.Client;
using XMPP.Tags.XmppSession;
using XMPP.�ommon;

namespace XMPP.States
{
    public class SessionState : IState
    {
        public SessionState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            if (data == null)
            {
                var iq = new Iq { IdAttr = Tag.NextId() };
                Tag session = new Session();

                iq.FromAttr = Manager.Settings.Id;
                iq.ToAttr = Manager.Settings.Id.Server;
                iq.TypeAttr = Iq.TypeEnum.set;
                iq.Add(session);

                Manager.Connection.Send(iq);
            }
            else
            {
                if (Manager.Transport == Transport.Bosh)
                {
                    (Manager.Connection as BoSH).StartPolling();
                }

                Manager.State = new RunningState(Manager);

                var presence = new Presence();
                Manager.Connection.Send(presence);
            }
        }
    }
}