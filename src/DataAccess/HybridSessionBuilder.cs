using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace CRIneta.DataAccess
{
    public class HybridSessionBuilder : ISessionBuilder
    {
        private static NHibernate.ISessionFactory sessionFactory;
        private static ISession currentSession;

        public ISession GetSession()
        {
            NHibernate.ISessionFactory factory = getSessionFactory();
            ISession session = getExistingOrNewSession(factory);
            //Log.Debug(this, "Using ISession " + session.GetHashCode());
            return session;
        }

        private NHibernate.ISessionFactory getSessionFactory()
        {
            if (sessionFactory == null)
            {
                Configuration configuration = GetConfiguration();
                sessionFactory = configuration.BuildSessionFactory();
            }

            return sessionFactory;
        }

        public Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
            return configuration;
        }

        private ISession getExistingOrNewSession(NHibernate.ISessionFactory factory)
        {
            if (HttpContext.Current != null)
            {
                ISession session = GetExistingWebSession();
                if (session == null)
                {
                    session = openSessionAndAddToContext(factory);
                }
                else if (!session.IsOpen)
                {
                    session = openSessionAndAddToContext(factory);
                }

                return session;
            }

            if (currentSession == null)
            {
                currentSession = factory.OpenSession();
            }
            else if (!currentSession.IsOpen)
            {
                currentSession = factory.OpenSession();
            }

            return currentSession;
        }

        public ISession GetExistingWebSession()
        {
            return HttpContext.Current.Items[GetType().FullName] as ISession;
        }

        private ISession openSessionAndAddToContext(NHibernate.ISessionFactory factory)
        {
            ISession session = factory.OpenSession();
            HttpContext.Current.Items.Remove(GetType().FullName);
            HttpContext.Current.Items.Add(GetType().FullName, session);
            return session;
        }
    }
}