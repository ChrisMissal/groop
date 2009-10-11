using NHibernate;
using NHibernate.Cfg;

namespace Groop.DataAccess
{
    public class SessionFactory : ISessionFactory
    {
        private readonly NHibernate.ISessionFactory sessionFactory;

        public Configuration GetConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            return configuration;
        }

        public SessionFactory()
        {
            var configuration = GetConfiguration();
            sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession Create()
        {
            return sessionFactory.OpenSession();
        }
    }
}