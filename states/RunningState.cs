// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="RunningState.cs">
//   
// </copyright>
// <summary>
//   The running state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Сommon;
using XMPP.Tags;

namespace XMPP.States
{
    public class RunningState : IState
    {
        public RunningState(Manager manager) : base(manager)
        {
            Manager.Events.OnSend += OnSend;
            Manager.Events.Ready(this);
        }

        public override void Dispose()
        {
            Manager.Events.OnSend -= OnSend;
        }

        private void OnSend(object sender, TagEventArgs e)
        {
            Manager.Connection.Send(e.tag);
        }

        public override void Execute(Tag data = null)
        {
            if (data != null)
                Manager.Events.Receive(this, data);
        }
    }
}