using NHibernate;

namespace Groop.DataAccess
{
    public interface IActiveSessionManager
    {

        /// <summary>
        /// Returns the active ISession for the current thread. Throws exception if there's
        /// no active ISession instance
        /// </summary>
        /// <returns></returns>
        ISession GetActiveSession();

        /// <summary>
        /// Sets the active ISession for the current thread. Throws exception if there's
        /// already an active ISession instance
        /// </summary>
        /// <param name="session"></param>
        void SetActiveSession(ISession session);

        /// <summary>
        /// Clears the active ISession for the current thread.
        /// </summary>
        void ClearActiveSession();

    }
}