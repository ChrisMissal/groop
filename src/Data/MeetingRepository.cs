using System;
using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Data
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly IXmlRepository xmlRepository;
        private IEnumerable<Meeting> allMeetings;

        public MeetingRepository(IXmlRepository xmlRepository)
        {
            this.xmlRepository = xmlRepository;
            this.xmlRepository.DataChangedEventHandler += (o, e) => allMeetings = null;
        }

        protected IEnumerable<Meeting> AllMeetings
        {
            get
            {
                if (allMeetings == null)
                    allMeetings = xmlRepository.GetAll<Meeting>();

                return allMeetings;
            }
        }

        public Meeting GetById(int key)
        {
            return xmlRepository.Get<Meeting>(key);
        }

        public Meeting GetNextMeeting(DateTime time)
        {
            return AllMeetings
                .OrderByDescending(x => x.StartTime)
                .FirstOrDefault(x => x.StartTime > time);
        }

        public IList<Meeting> GetUpcomingMeetings(DateTime time, int maxNumberMeetings)
        {
            return AllMeetings
                .Where(x => x.StartTime > time)
                .OrderByDescending(x => x.StartTime)
                .Take(maxNumberMeetings).ToList();
        }

        public IList<Meeting> GetAllMeetings()
        {
            return AllMeetings.ToList();
        }

        public IList<Meeting> GetMeetingsBetween(DateTime beginDate, DateTime endDate)
        {
            return AllMeetings
                .Where(x => x.StartTime > beginDate && x.EndTime < endDate)
                .OrderByDescending(x => x.StartTime).ToList();
        }

        public int Add(Meeting meeting)
        {
            xmlRepository.Add(meeting, (x, id) => x.MeetingId = id);

            return meeting.MeetingId;
        }

        public void Update(Meeting meeting)
        {
            var savedMeeting = AllMeetings.FirstOrDefault(x => x.MeetingId == meeting.MeetingId);

            if(meeting.Attendees.SequenceEqual(savedMeeting.Attendees))
            {
                xmlRepository.Update(meeting, meeting.MeetingId);
                return;
            }

            var attendees = meeting.Attendees;

            var uniques = attendees
                .Union(savedMeeting.Attendees)
                .GroupBy(x => x.Email)
                .ToDictionary(x => x.Key, x => x.First());

            meeting.Attendees = uniques.Values.ToList();

            xmlRepository.Update(meeting, meeting.MeetingId);
        }
    }
}