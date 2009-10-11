using System;
using System.Collections.Generic;
using Groop.Core.Data;
using Groop.Core.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Groop.DataAccess
{
    public class FacilityRepository : RepositoryBaseUoW<Facility,int>, IFacilityRepository
    {
        public FacilityRepository(IActiveSessionManager activeSessionManager) : base(activeSessionManager)
        {
        }

        protected override Func<Facility, int> GetKey
        {
            get { return facility => facility.FacilityId; }
        }

        #region IFacilityRepository Members

        public IList<Facility> GetAll()
        {
            var criteria = DetachedCriteria.For<Facility>();
            return new List<Facility>(FindAll(criteria));
        }

        #endregion
    }
}