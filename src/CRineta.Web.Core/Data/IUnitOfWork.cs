using System;
using System.Data;
using NHibernate;

namespace CRIneta.Web.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Flushes any changes that haven't been executed yet
        /// </summary>
        void Flush();

        /// <summary>
        /// Creates an ITransaction instance with the ReadCommitted isolation level
        /// </summary>
        /// <returns></returns>
        ITransaction CreateTransaction();

        /// <summary>
        /// Creates an ITransaction instance with the given isolation level
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        ITransaction CreateTransaction(IsolationLevel isolationLevel);
    }
}