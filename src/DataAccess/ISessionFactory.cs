using NHibernate;

namespace CRIneta.DataAccess
{
    public interface ISessionFactory
    {
        /// <summary>
        /// Creates a new ISession instance
        /// </summary>
        /// <returns></returns>
        ISession Create();
    }
}