using XMPP.common;
using XMPP.tags;
using XMPP.tags.jabber.client;
using XMPP.tags.urn.xmpp.receipts;

namespace XMPP.states
{
    //XEP-0184
    internal class AckState : IState
    {
        public AckState(Manager manager) : base(manager) { }

        public override void Dispose() { }

        public override void Execute(Tag data = null)
        {
            if (data != null && data is message)
            {
                var toAck = data as message;

                var ackMessage = new message()
                {
                    to = toAck.from,
                    from = toAck.to
                };

                ackMessage.Add(new received() { id = toAck.id });
                Manager.Connection.Send(ackMessage);
            }

            Manager.State = new RunningState(Manager);
        }
    }
}