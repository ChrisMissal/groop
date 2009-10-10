using System.Collections.Generic;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Data
{
    public interface ISponsorRepository : IIntermediateRepository<Sponsor, int>
    {
        IList<Sponsor> GetAll();
    }
}