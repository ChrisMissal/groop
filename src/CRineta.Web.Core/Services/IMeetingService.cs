using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Domain;
using NHibernate;

namespace CRIneta.Web.Core.Services
{
    public interface IMeetingService
    {
        IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings);
    }
}