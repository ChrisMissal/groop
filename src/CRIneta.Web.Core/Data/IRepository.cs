namespace CRIneta.Web.Core.Data
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey key);
    }
}