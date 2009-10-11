using System;
using System.Collections.Generic;
using Groop.Core.Domain;
using NHibernate;

namespace Groop.Core.Services
{
    public interface IMeetingService
    {
        IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings);
        Meeting GetNextMeeting(DateTime time);
    }
}