namespace Groop.Core.Data
{
    public interface IIntermediateRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        TKey Add(TEntity entity);
    }
}