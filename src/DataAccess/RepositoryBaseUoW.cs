using System;
using System.Collections.Generic;
using Groop.Framework;
using NHibernate;
using NHibernate.Criterion;

namespace Groop.DataAccess
{
    public abstract class RepositoryBaseUoW<TEntity,TKey>
    {
        private readonly IActiveSessionManager activeSessionManager;

        protected abstract Func<TEntity, TKey> GetKey
        {
            get;
        }

        protected RepositoryBaseUoW(IActiveSessionManager activeSessionManager)
        {
            this.activeSessionManager = activeSessionManager;
        }

        protected ISession Session
        {
            get { return activeSessionManager.GetActiveSession(); }
        }

        public TEntity GetById(TKey id)
        {
            return Session.Get<TEntity>(id);
        }

        public TKey Add(TEntity entity)
        {
            Session.Save(entity);

            return GetKey(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        public void SaveOrUpdate(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        /// <summary>
        /// Returns each entity that matches the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).List<TEntity>();
        }

        /// <summary>
        /// Returns each entity that maches the given criteria, and orders the results
        /// according to the given Orders
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria, params Order[] orders)
        {
            if (orders != null)
            {
                Array.ForEach(orders, order => criteria.AddOrder(order));
            }

            return FindAll(criteria);
        }

        /// <summary>
        /// Returns each entity that matches the given criteria, with support for paging,
        /// and orders the results according to the given Orders
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="firstResult"></param>
        /// <param name="numberOfResults"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(DetachedCriteria criteria, int firstResult, int numberOfResults, params Order[] orders)
        {
            criteria.SetFirstResult(firstResult).SetMaxResults(numberOfResults);
            return FindAll(criteria, orders);
        }

        /// <summary>
        /// Returns the one entity that matches the given criteria. Throws an exception if
        /// more than one entity matches the criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public TEntity FindOne(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).UniqueResult<TEntity>();
        }

        /// <summary>
        /// Returns the first entity to match the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public TEntity FindFirst(DetachedCriteria criteria)
        {
            var results = criteria
                .SetFirstResult(0)
                .SetMaxResults(1)
                .GetExecutableCriteria(Session).List<TEntity>();

            return results.Count > 0 ? results[0] : default(TEntity);
        }

        /// <summary>
        /// Returns the first entity to match the given criteria, ordered by the given order
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public TEntity FindFirst(DetachedCriteria criteria, Order order)
        {
            return FindFirst(criteria.AddOrder(order));
        }

        /// <summary>
        /// Returns the total number of entities that match the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public long Count(DetachedCriteria criteria)
        {
            return Convert.ToInt64(criteria
                                       .GetExecutableCriteria(Session)
                                       .SetProjection(Projections.RowCountInt64())
                                       .UniqueResult());
        }

        /// <summary>
        /// Returns true if at least one entity exists that matches the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool Exists(DetachedCriteria criteria)
        {
            return Count(criteria) > 0;
        }

        /// <summary>
        /// Deletes the given entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        /// <summary>
        /// Deletes every entity that matches the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        public void Delete(DetachedCriteria criteria)
        {
            // a simple DELETE FROM ... WHERE ... would be much better, but i haven't found
            // a way to do this yet with Criteria. So now it does two roundtrips... one for
            // the query, and one with all the batched delete statements (that is, if you've
            // enabled CUD statement batching
            FindAll(criteria).ForEach(Delete);
        }
    }
}