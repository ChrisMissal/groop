namespace CRIneta.Web.Core.Data
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates an <see cref="IUnitOfWork" />
        /// </summary>
        /// <returns></returns>
        IUnitOfWork Create();
    }
}