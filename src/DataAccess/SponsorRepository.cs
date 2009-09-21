using System.Collections.Generic;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate.Criterion;

namespace IntegrationTests.DataAccess
{
    public class SponsorRepository : RepositoryBaseUoW<Sponsor,int>, ISponsorRepository
    {
        public SponsorRepository(IActiveSessionManager activeSessionManager) : base(activeSessionManager)
        {
            
        }

        public int Add(Sponsor entity)
        {
            SaveOrUpdate(entity);

            return entity.SponsorId;
        }

        public IEnumerable<Sponsor> GetAll()
        {
            var criteria = DetachedCriteria.For<Sponsor>();
            return FindAll(criteria);
        }
    }
}