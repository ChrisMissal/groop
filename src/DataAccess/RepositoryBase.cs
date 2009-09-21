using System;
using System.Collections.Generic;
using CRIneta.Framework;
using CRIneta.Web.Core.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace CRIneta.DataAccess
{
    public class RepositoryBase<TEntity>
    {
        protected readonly ISessionBuilder sessionBuilder;

        public RepositoryBase(ISessionBuilder sessionFactory)
        {
            sessionBuilder = sessionFactory;
        }

        protected ISession getSession()
        {
            ISession session = sessionBuilder.GetSession();
            return session;
        }

        public void Flush()
        {
            getSession().Flush();
        }

        public TEntity GetById(int key)
        {
            if (key <= 0) return default(TEntity);

            using(var session = getSession())
            using(var txn = session.BeginTransaction())
            {
                try
                {
                    var meeting = session.Get<TEntity>(key);
                    txn.Commit();
                    return meeting;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        public IList<TEntity> Get(int? page, int? pageSize)
        {
            if (!page.HasValue)
            {
                page = 1;
            }

            if (!pageSize.HasValue)
            {
                pageSize = Int32.MaxValue;
            }

            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    var entityList = session.CreateQuery("from {0}".FormatWith(typeof(TEntity).Name))
                        .List<TEntity>();

                    txn.Commit();
                    return entityList;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Saves or updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Save(TEntity entity)
        {
            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    txn.Commit();
                    return entity;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        
    }
}