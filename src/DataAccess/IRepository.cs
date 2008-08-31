namespace CRIneta.DataAccess
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey key);
    }
}