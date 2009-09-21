using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Domain;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class MeetingRepostoryTests : RepositoryTestBase
    {
        public void GetMyTestDataXmlFile()
        {
            SaveTestDatabase();
        }

        [Test]
        public void Can_get_meeting_by_Id()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);

            // Act
            var meeting = meetingRepository.GetById(1);

            // Assert
            Assert.That(meeting.MeetingId, Is.EqualTo(1));
            Assert.That(meeting.Facility.Name, Is.EqualTo("Baymont Inn"));
            Assert.That(meeting.AttendeeCount, Is.EqualTo(3));
            Assert.That(meeting.Attendees.OfType<GuestAttendee>().Count(), Is.EqualTo(1));
            Assert.That(meeting.Attendees.Count(x=>x.GetType() == typeof(MemberAttendee)), Is.EqualTo(1));
            Assert.That(meeting.Attendees.OfType<PromotedAttendee>().Count(), Is.EqualTo(1));
        }

        [Test]
        public void Can_load_all_meetings()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);

            // Assert
            IList<Meeting> meetings = meetingRepository.GetAllMeetings();

            // Act
            Assert.That(meetings.Count, Is.EqualTo(5));
        }

        [Test]
        public void GetMeetingsBetween_returns_one_meeting()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);
            var startDate = DateTime.Parse("1/1/2008");
            var endDate = DateTime.Parse("1/1/2009");

            // Act
            IList<Meeting> meetings = meetingRepository.GetMeetingsBetween(startDate, endDate);

            // Assert
            Assert.That(meetings.Count, Is.EqualTo(2));
        }

        [Test]
        public void MeetingRepository_can_save_Attendees()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);
            var meeting = meetingRepository.GetById(2);
            meeting.AddGuestAttendee("chris@github.com", "Chris", "Missal");
            meeting.AddGuestAttendee("missal@github.com", "Chris", "Missal");
            
            // Act
            meetingRepository.Save(meeting);

            // Assert
            Assert.That(meeting.AttendeeCount, Is.EqualTo(2));
        }
    }
}