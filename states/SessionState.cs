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
using XMPP.Ñommon;

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
                var iq = new Iq {Id = Tag.NextId()};
                Tag session = new Session();

                iq.From = Manager.Settings.Id;
                iq.To = Manager.Settings.Id.Server;
                iq.Type = Iq.TypeEnum.set;
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