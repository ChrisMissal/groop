using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate;

namespace CRIneta.DataAccess
{
    public class FacilityRepository : RepositoryBase, IFacilityRepository
    {
        public FacilityRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        #region IFacilityRepository Members

        public Facility GetById(int key)
        {
            using (var session = getSession())
            using (var txn = session.BeginTransaction())
                try
                {
                    return session.Get<Facility>(key);
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
        }

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