using System;
using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Core.Services.Impl
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

        public Meeting GetNextMeeting(DateTime time)
        {
            return GetUpcomingMeetings(time, 1).FirstOrDefault();
        }

        public IList<Meeting> GetPastMeetings(DateTime time)
        {
            using (unitOfWorkFactory.Create())
            {
                var meetings = meetingRepository.GetMeetingsBetween(DateTime.Parse("1/1/1900"), time);
                return meetings;
            }
        }
    }
}