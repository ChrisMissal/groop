using NHibernate;
using NHibernate.Cfg;

namespace CRIneta.DataAccess
{
    public interface ISessionBuilder
    {
        ISession GetSession();
        Configuration GetConfiguration();
    }
}