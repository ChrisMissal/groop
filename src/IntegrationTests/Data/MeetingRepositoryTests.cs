using System;
using System.Linq;
using Groop.Core.Domain;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    public class MeetingRepositoryTests : XmlRepositoryTesterBase
    {
        [Test]
        public void Add_can_insert_a_Meeting_with_a_Facility()
        {
            var repository = GetMeetingRepository();

            var meeting = new Meeting
                              {
                                  Description = "no",
                                  Facility = new Facility
                                                 {
                                                     Description = "ok",
                                                     Address = new Address
                                                                   {
                                                                       City = "Cedar Rapids"
                                                                   }
                                                 }
                              };

            repository.Add(meeting);

            Assert.That(meeting.Facility.Address.City, Is.EqualTo("Cedar Rapids"));
        }

        [Test]
        public void GetAllMeetings()
        {
            var repository = GetMeetingRepository();

            var meeting = new Meeting { Description = "a meeting", Title = "The Title" };

            repository.Add(meeting);
            repository.Add(meeting);
            repository.Add(meeting);

            var meetings = repository.GetAllMeetings();

            Assert.True(meetings.Count >= 3);
        }
        
        [Test]
        public void GetMeetingsBetween()
        {
            var repository = GetMeetingRepository();

            var meeting1 = new Meeting { Title = "1", StartTime = DateTime.Now.AddDays(-32), EndTime = DateTime.Now.AddDays(-32).AddHours(2) };
            var meeting2 = new Meeting { Title = "2", StartTime = DateTime.Now.AddDays(-12), EndTime = DateTime.Now.AddDays(-12).AddHours(2) };
            var meeting3 = new Meeting { Title = "3", StartTime = DateTime.Now.AddDays(12), EndTime = DateTime.Now.AddDays(12).AddHours(2) };
            var meeting4 = new Meeting { Title = "4", StartTime = DateTime.Now.AddDays(32), EndTime = DateTime.Now.AddDays(32).AddHours(2) };

            repository.Add(meeting1);
            repository.Add(meeting2);
            repository.Add(meeting3);
            repository.Add(meeting4);

            var upcomingMeetings = repository.GetMeetingsBetween(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(20));

            Assert.False(upcomingMeetings.Any(x => x.Title == "1"));
            Assert.True(upcomingMeetings.Any(x => x.Title == "2"));
            Assert.True(upcomingMeetings.Any(x => x.Title == "3"));
            Assert.False(upcomingMeetings.Any(x => x.Title == "4"));
        }

        [Test]
        public void GetUpcomingMeetings()
        {
            var repository = GetMeetingRepository();

            var meeting1 = new Meeting { StartTime = DateTime.Now.AddDays(-32), Description = "past meeting", Title = "Some Title" };
            var meeting2 = new Meeting { StartTime = DateTime.Now.AddDays(-2), Description = "past meeting", Title = "Some Title" };
            var meeting3 = new Meeting { StartTime = DateTime.Now.AddDays(2), Description = "future meeting", Title = "Some Title" };
            var meeting4 = new Meeting { StartTime = DateTime.Now.AddDays(32), Description = "future meeting", Title = "Some Title" };

            repository.Add(meeting1);
            repository.Add(meeting2);
            repository.Add(meeting3);
            repository.Add(meeting4);

            var upcomingMeetings = repository.GetUpcomingMeetings(DateTime.Now, 2);

            Assert.That(upcomingMeetings.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetNextMeeting()
        {
            var repository = GetMeetingRepository();

            var meeting1 = new Meeting { StartTime = DateTime.Now.AddDays(-2), Description = "past meeting", Title = "Some Title" };
            var meeting2 = new Meeting { StartTime = DateTime.Now.AddSeconds(1), Description = "future meeting", Title = "Some Title" };

            repository.Add(meeting1);
            repository.Add(meeting2);

            var foundMeeting = repository.GetNextMeeting(DateTime.Now);
            Assert.That(meeting2.Title, Is.EqualTo(foundMeeting.Title));
        }

        [Test]
        public void Update_on_Meeting_with_no_Attendee_change_should_keep_same_Attendees()
        {
            var repository = GetMeetingRepository();

            var meeting = new Meeting();

            meeting.AddAttendee(new Member{Email = "chris@chrismissal.com"});
            meeting.AddGuestAttendee("email", "first", "last");

            var id = repository.Add(meeting);

            Assert.That(meeting.AttendeeCount, Is.EqualTo(2));

            repository.Update(meeting);

            var savedMeeting = repository.GetById(id);
            savedMeeting.EndTime = DateTime.Now.AddHours(2);
            savedMeeting.Description = savedMeeting.Description += " NOTE: Updated times!";

            repository.Update(meeting);

            Assert.That(savedMeeting.AttendeeCount, Is.EqualTo(2));
            Assert.That(DateTime.Now.AddHours(2), Is.LessThanOrEqualTo(savedMeeting.EndTime));
        }

        [Test]
        public void Update_on_Meeting_should_not_overwrite_attendees()
        {
            var repository = GetMeetingRepository();

            var meeting = new Meeting {Description = "next meeting", Title = "Title"};

            meeting.AddSponsor(new Sponsor {Description = "sweet", Name = "J&P Cycles"});
            meeting.AddAttendee(new Member{Email = "chris.missal@gmail.com"});

            var meetingId = repository.Add(meeting);

            var savedMeeting = repository.GetById(meetingId);

            meeting.AddGuestAttendee("cmissal@jpcycles.com", "chris", "missal");

            repository.Update(meeting);

            var countBeforeUpdate = meeting.AttendeeCount;

            repository.Update(savedMeeting);

            Assert.That(savedMeeting.AttendeeCount, Is.EqualTo(countBeforeUpdate));
        }

        [Test]
        public void GetById_returns_null_if_Meeting_not_found()
        {
            var repository = GetMeetingRepository();

            var meeting = repository.GetById(9999);

            Assert.Null(meeting);
        }

        private MeetingRepository GetMeetingRepository()
        {
            return new MeetingRepository(TestXmlRepository);
        }
    }
}