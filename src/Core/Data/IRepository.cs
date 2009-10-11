namespace Groop.Core.Data
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey key);
    }
}