using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate.Criterion;

namespace CRIneta.DataAccess
{
    public class SponsorRepository : RepositoryBaseUoW<Sponsor,int>, ISponsorRepository
    {
        public SponsorRepository(IActiveSessionManager activeSessionManager) : base(activeSessionManager)
        {
            
        }

        public IList<Sponsor> GetAll()
        {
            var criteria = DetachedCriteria.For<Sponsor>();
            return new List<Sponsor>(FindAll(criteria));
        }

        protected override Func<Sponsor, int> GetKey
        {
            get { return sponsor => sponsor.SponsorId; }
        }
    }
}