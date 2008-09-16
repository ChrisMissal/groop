using System;
using System.Collections.Generic;
using CRIneta.Model.Domain;

namespace CRIneta.DataAccess
{
    public interface IMeetingRepository : IRepository<Meeting, int>
    {
        Meeting GetNextMeeting(DateTime time);
        IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings);
    }
}