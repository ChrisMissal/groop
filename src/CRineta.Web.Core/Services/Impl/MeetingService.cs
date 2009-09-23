using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Services.Impl
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository meetingRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public MeetingService(IMeetingRepository meetingRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.meetingRepository = meetingRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            using (unitOfWorkFactory.Create())
            {
                var meetings = meetingRepository.GetUpcomingMeetings(time, maxNumberMeetings);
                return meetings;
            }
        }
    }
}