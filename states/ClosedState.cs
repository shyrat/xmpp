// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ClosedState.cs">
//   
// </copyright>
// <summary>
//   The closed state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class ClosedState : IState
    {
        public ClosedState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Cleaning up");
#endif
            Manager.IsAuthenticated = false;
#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Closing socket (Graceful Shutdown)");
#endif
        }
    }
}