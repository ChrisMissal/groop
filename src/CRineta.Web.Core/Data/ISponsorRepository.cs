using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Data
{
    public interface ISponsorRepository : IIntermediateRepository<Sponsor, int>
    {

    }

    public interface IIntermediateRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        TKey Add(TEntity entity);
    }
}