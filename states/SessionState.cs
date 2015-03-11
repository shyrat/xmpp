// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="SessionState.cs">
//   
// </copyright>
// <summary>
//   The session state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Common;
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
                var iq = new Iq
                {
                    IdAttr = Tag.NextId(),
                    FromAttr = Manager.Settings.Id,
                    ToAttr = Manager.Settings.Id.Server,
                    TypeAttr = Iq.TypeEnum.set
                };

                ((XElement)iq).Add(new Session());

                Manager.Connection.Send(iq);
            }
            else
            {
                if (Manager.Transport == Transport.Bosh)
                {
                    (Manager.Connection as Bosh).StartPolling();
                }

                Manager.State = new RunningState(Manager);

                var presence = new Presence();
                Manager.Connection.Send(presence);
            }
        }
    }
}