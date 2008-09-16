using System;
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

        public Meeting GetNextMeeting(DateTime time)
        {
            return GetUpcomingMeetings(time, 1)[0];
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            ISession session = getSession();

            return session
                .CreateQuery("from Meeting where StartsAt > :time order by StartsAt asc")
                .SetParameter("time", time)
                .SetMaxResults(maxNumberMeetings)
                .List<Meeting>();
        }
    }
}