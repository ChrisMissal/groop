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
            if (key <= 0) return null;

            var session = getSession();
            
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
            IList<Meeting> meetings = GetUpcomingMeetings(time, 1);
            return meetings.Count == 0 ? null : meetings[0];
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            ISession session = getSession();

            return session
                .CreateQuery("from Meeting m where m.StartTime > :time order by m.StartTime asc")
                .SetParameter("time", time)
                .SetMaxResults(maxNumberMeetings)
                .List<Meeting>();
        }

        public IList<Meeting> GetMeetingsBetween(DateTime beginDate, DateTime endDate)
        {
            ISession session = getSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var meetings = session
                        .CreateQuery("from Meeting m where m.StartTime >= :begin and m.StartTime < :end order by m.StartTime asc")
                        .SetParameter("begin", beginDate)
                        .SetParameter("end", endDate)
                        .List<Meeting>();

                    tx.Commit();
                    return meetings;
                }
                catch(HibernateException ex)
                {
                    tx.Rollback();
                    throw;
                }
                
            }
        }
    }
}