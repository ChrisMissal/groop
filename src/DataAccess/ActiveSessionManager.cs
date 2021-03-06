using System;
using NHibernate;

namespace Groop.DataAccess
{
    public class ActiveSessionManager : IActiveSessionManager
    {
        private ISession Current;

        public ISession GetActiveSession()
        {
            if (Current == null)
            {
                throw new InvalidOperationException("There is no active ISession instance for this thread");
            }

            return Current;
        }

        public void SetActiveSession(ISession session)
        {
            if (Current != null)
            {
                throw new InvalidOperationException("There is already an active ISession instance for this thread");
            }

            Current = session;
        }

        public void ClearActiveSession()
        {
            Current = null;
        }
    }
}