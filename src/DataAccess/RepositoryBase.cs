using NHibernate;

namespace CRIneta.DataAccess
{
    public class RepositoryBase
    {
        protected readonly ISessionBuilder sessionBuilder;

        public RepositoryBase(ISessionBuilder sessionFactory)
        {
            sessionBuilder = sessionFactory;
        }

        protected ISession getSession()
        {
            ISession session = sessionBuilder.GetSession();
            return session;
        }

        public void Flush()
        {
            getSession().Flush();
        }
    }
}