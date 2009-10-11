using System.Collections.Generic;
using Groop.Core.Domain;

namespace Groop.Core.Data
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
        IList<Facility> GetAll();
    }
}