// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ConnectingState.cs">
//   
// </copyright>
// <summary>
//   The connecting state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class ConnectingState : IState
    {
        public ConnectingState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            Manager.Parser.Clear();
            Manager.Connection.Connect();
        }
    }
}