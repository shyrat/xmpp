// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="DisconnectState.cs">
//   
// </copyright>
// <summary>
//   The disconnect state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class DisconnectState : IState
    {
        public DisconnectState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            Manager.Connection.Disconnect();
            Manager.Parser.Clear();

            Manager.State = new ClosedState(Manager);
            Manager.State.Execute();
        }
    }
}