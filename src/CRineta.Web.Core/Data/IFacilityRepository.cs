using System.Collections.Generic;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Data
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
        IList<Facility> GetAll();
    }
}