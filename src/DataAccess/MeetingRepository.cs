using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate;

namespace CRIneta.DataAccess
{
    public class MeetingRepository : RepositoryBase, IMeetingRepository
    {
        public MeetingRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        public Meeting GetById(int key)
        {
            if (key <= 0) return null;

            using(var session = getSession())
            using(var txn = session.BeginTransaction())
            {
                try
                {
                    var meeting = session.Get<Meeting>(key);
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

        public IList<Meeting> GetAllMeetings()
        {
            using(var session = getSession())
            using(var txn = session.BeginTransaction())
            {
                try
                {
                    var meeting = session.CreateQuery("from Meeting").List<Meeting>();
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

        /// <summary>
        /// Saves or updates the meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <returns></returns>
        public Meeting SaveOrUpdateMeeting(Meeting meeting)
        {
            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(meeting);
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

        public Meeting GetNextMeeting(DateTime time)
        {
            IList<Meeting> meetings = GetUpcomingMeetings(time, 1);
            return meetings.Count == 0 ? null : meetings[0];
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            using(var session = getSession())
            using(var txn = session.BeginTransaction())
            {
                try
                {
                    var meetings = session
                            .CreateQuery("from Meeting m where m.StartTime > :time order by m.StartTime asc")
                            .SetParameter("time", time)
                            .SetMaxResults(maxNumberMeetings)
                            .List<Meeting>();

                    txn.Commit();
                    return meetings;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        public IList<Meeting> GetMeetingsBetween(DateTime beginDate, DateTime endDate)
        {
            using(var session = getSession())
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
                catch(HibernateException)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}