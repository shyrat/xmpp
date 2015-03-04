// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="StartTLSState.cs">
//   
// </copyright>
// <summary>
//   The start tls state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class StartTLSState : IState
    {
        public StartTLSState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            if (data != null && data.Name.LocalName != "proceed")
            {
                return;
            }

            Manager.Connection.EnableSSL();
            Manager.State = new ConnectedState(Manager);
            Manager.State.Execute();
        }
    }
}