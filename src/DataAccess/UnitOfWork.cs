using System;
using System.Data;
using Groop.Core.Data;
using NHibernate;

namespace Groop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IActiveSessionManager activeSessionManager;
        private readonly ISession session;

        public UnitOfWork(ISession session, IActiveSessionManager activeSessionManager)
        {
            this.activeSessionManager = activeSessionManager;
            this.session = session;
            activeSessionManager.SetActiveSession(session);
        }

        public void Dispose()
        {
            if (session != null)
            {
                session.Close();
                session.Dispose();
            }

            ClearReferences();
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

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory sessionFactory;
        private readonly IActiveSessionManager activeSessionManager;

        public UnitOfWorkFactory(ISessionFactory sessionFactory,IActiveSessionManager activeSessionManager)
        {
            this.sessionFactory = sessionFactory;
            this.activeSessionManager = activeSessionManager;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(sessionFactory.Create(),activeSessionManager);
        }
    }
}