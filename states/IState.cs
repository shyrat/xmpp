// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="IState.cs">
//   
// </copyright>
// <summary>
//   The i state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using XMPP.Tags;
using XMPP.Ñommon;

namespace XMPP.States
{
    public abstract class IState : IDisposable
    {
        private readonly Manager _manager;

        protected IState(Manager manager)
        {
            _manager = manager;
        }

        protected Manager Manager
        {
            get { return _manager; }
        }

        public virtual void Dispose()
        {
        }

        public virtual void Execute(Tag data = null)
        {
        }
    }
}