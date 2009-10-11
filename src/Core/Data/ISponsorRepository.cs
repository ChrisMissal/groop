using System.Collections.Generic;
using Groop.Core.Domain;

namespace Groop.Core.Data
{
    public interface ISponsorRepository : IIntermediateRepository<Sponsor, int>
    {
        IList<Sponsor> GetAll();
    }
}