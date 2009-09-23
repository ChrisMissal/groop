using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Data
{
    public interface IMeetingRepository : IRepository<Meeting, int>
    {
        Meeting GetNextMeeting(DateTime time);
        IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings);
        IList<Meeting> GetAllMeetings();
        IList<Meeting> GetMeetingsBetween(DateTime beginDate, DateTime endDate);
        int Add(Meeting meeting);
        void Update(Meeting meeting);
    }
}