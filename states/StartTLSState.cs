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
    public class StartTlsState : IState
    {
        public StartTlsState(Manager manager) : base(manager)
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