using System.Data;
using CRIneta.Web.Core.Data;
using NHibernate;

namespace CRIneta.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IActiveSessionManager activeSessionManager;
        private readonly ISession session;

        public UnitOfWork(ISessionFactory sessionFactory, IActiveSessionManager activeSessionManager)
        {
            this.activeSessionManager = activeSessionManager;
            session = sessionFactory.Create();
            activeSessionManager.SetActiveSession(session);
        }

        public void Dispose()
        {
            if (session != null)
            {
                session.Close();
                session.Dispose();
            }
        }

        protected void ClearReferences()
        {
            activeSessionManager.ClearActiveSession();
        }

        public void Flush()
        {
            session.Flush();
        }

        public ITransaction CreateTransaction()
        {
            return CreateTransaction(IsolationLevel.ReadCommitted);
        }

        public ITransaction CreateTransaction(IsolationLevel isolationLevel)
        {
            return session.BeginTransaction(isolationLevel);
        }
    }
}