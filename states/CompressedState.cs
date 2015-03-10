// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="CompressedState.cs">
//   
// </copyright>
// <summary>
//   The compressed state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public class CompressedState : IState
    {
        public CompressedState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            if (data != null && ((XElement)data).Name.LocalName != "compressed")
                return;

#if DEBUG
            Manager.Events.LogMessage(this, LogType.Debug, "Starting compression of the socket");
#endif
            Manager.Connection.EnableCompression(Manager.CompressionAlgorithm);
            Manager.IsCompressed = true;
            Manager.State = new ConnectedState(Manager);
            Manager.State.Execute();
        }
    }
}