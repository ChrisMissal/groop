using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate;

namespace CRIneta.DataAccess
{
    public class FacilityRepository : RepositoryBase<Facility>, IFacilityRepository
    {
        public FacilityRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        #region IFacilityRepository Members

        public IEnumerable<Facility> GetFacilities()
        {
            using (var session = getSession())
            using (var txn = session.BeginTransaction())
                try
                {
                    return session
                        .CreateQuery("from Facility")
                        .List<Facility>();
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
        }

        #endregion
    }
}