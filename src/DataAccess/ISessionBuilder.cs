using NHibernate;
using NHibernate.Cfg;

namespace Groop.DataAccess
{
    public interface ISessionBuilder
    {
        ISession GetSession();
        Configuration GetConfiguration();
    }
}