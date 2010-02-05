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

        public MeetingService(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            return meetingRepository.GetUpcomingMeetings(time, maxNumberMeetings);
        }

        public Meeting GetNextMeeting(DateTime time)
        {
            return meetingRepository.GetNextMeeting(time) ?? new UnknownMeeting();
        }

        public IList<Meeting> GetPastMeetings(DateTime time)
        {
            return meetingRepository.GetMeetingsBetween(DateTime.Parse("1/1/1900"), time);
        }

        public Meeting GetById(int id)
        {
            return meetingRepository.GetById(id);
        }
    }
}