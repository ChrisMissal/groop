using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace CRIneta.DataAccess
{
    public class MeetingRepository : RepositoryBaseUoW<Meeting,int>, IMeetingRepository
    {
        public MeetingRepository(IActiveSessionManager activeSessionManager) : base(activeSessionManager)
        {
        }

        protected override Func<Meeting, int> GetKey
        {
            get { return meeting => meeting.MeetingId; }
        }

        public IList<Meeting> GetAllMeetings()
        {
            var criteria = DetachedCriteria.For<Meeting>();
            return new List<Meeting>(FindAll(criteria));
        }

        public Meeting GetNextMeeting(DateTime time)
        {
            IList<Meeting> meetings = GetUpcomingMeetings(time, 1);
            return meetings.Count == 0 ? null : meetings[0];
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            var criteria = DetachedCriteria.For<Meeting>()
                .Add(Restrictions.Gt("StartTime", time))
                .AddOrder(Order.Asc("StartTime"))
                .SetMaxResults(maxNumberMeetings);
            
            return new List<Meeting>(FindAll(criteria));
        }

        public IList<Meeting> GetMeetingsBetween(DateTime beginDate, DateTime endDate)
        {
            var criteria = DetachedCriteria.For<Meeting>()
                .Add(Restrictions.Between("StartTime", beginDate, endDate))
                .AddOrder(Order.Asc("StartTime"));

            return new List<Meeting>(FindAll(criteria));
        }
    }
}