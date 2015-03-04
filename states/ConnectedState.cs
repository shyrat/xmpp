// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ConnectedState.cs">
//   
// </copyright>
// <summary>
//   The connected state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Tags;
using XMPP.Tags.Streams;
using XMPP.Ñommon;
using Namespace = XMPP.Tags.Jabber.Client.Namespace;

namespace XMPP.States
{
    public class ConnectedState : IState
    {
        public ConnectedState(Manager manager) : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            var stream = new Stream();
            stream.Version = "1.0";
            stream.To = Manager.Settings.Id.Server;
            stream.Xmlns = Namespace.Name;
            stream.Lang = "en";
            Manager.Connection.Send("<?xml version='1.0' encoding='UTF-8'?>" + stream.StartTag);
            Manager.State = new ServerFeaturesState(Manager);
        }
    }
}