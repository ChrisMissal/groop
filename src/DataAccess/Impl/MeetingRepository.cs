using System.Collections.Generic;
using CRIneta.Model.Domain;
using NHibernate;

namespace CRIneta.DataAccess.Impl
{
    public class MeetingRepository : RepositoryBase, IMeetingRepository
    {
        public MeetingRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        public Meeting GetById(int key)
        {
            if (key <= 0)
                return null;

            ISession session = getSession();
            
            return session.Get<Meeting>(key);
        }

        public IList<Meeting> GetAllMeetings()
        {
            ISession session = getSession();

            return session
                .CreateQuery("from Meeting")
                .List<Meeting>();
        }
    }
}