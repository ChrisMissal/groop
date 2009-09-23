using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Domain;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class MeetingRepositoryTests : RepositoryTestBase
    {
        [Test]
        public void Can_get_meeting_by_Id()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(activeSessionManager);

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
            var meetingRepository = new MeetingRepository(activeSessionManager);

            // Assert
            IList<Meeting> meetings = meetingRepository.GetAllMeetings();

            // Act
            Assert.That(meetings.Count, Is.EqualTo(5));
        }

        [Test]
        public void GetMeetingsBetween_returns_one_meeting()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(activeSessionManager);
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
            var meetingRepository = new MeetingRepository(activeSessionManager);
            var meeting = meetingRepository.GetById(2);
            meeting.AddGuestAttendee("chris@github.com", "Chris", "Missal");
            meeting.AddGuestAttendee("missal@github.com", "Chris", "Missal");
            
            // Act
            meetingRepository.Update(meeting);

            // Assert
            Assert.That(meeting.AttendeeCount, Is.EqualTo(2));
        }

        [Test]
        public void Add_can_add_a_new_meeting()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(activeSessionManager);
            var meeting = new Meeting()
                              {
                                  Title = "Test Meeting",
                                  Description = "Sample Description",
                                  StartTime = DateTime.Parse("1/1/2009"),
                                  EndTime = DateTime.Parse("1/1/2009"),
                                  Presenter = "Tim Barcz",
                                  Facility = new Facility() { 
                                      Address = new Address()
                                                    {
                                                        Street = "123 Oak Street",
                                                        City="Cedar Rapids",
                                                        Region = "Iowa",
                                                        ZipCode = "52402"
                                                    },
                                      Description = "Sample Facility",
                                      Name = "Test Facility",
                                      ImageUrl = "http://www.google.com"
                                  }
                              };
            // Act
            meetingRepository.Add(meeting);

            // Assert
            Assert.That(meeting.MeetingId, Is.GreaterThan(0));
        }

        [Test]
        public void GetNextMeeting_should_return_the_next_meeting_after_the_date_specified()
        { 
            // Arrange
            var meetingRepository = new MeetingRepository(activeSessionManager);

            // Act
            var meeting = meetingRepository.GetNextMeeting(DateTime.Parse("2008-07-04"));

            // Assert
            Assert.That(meeting.MeetingId, Is.EqualTo(1));
            Assert.That(meeting.Description, Is.EqualTo("This is the description"));
            Assert.That(meeting.Title, Is.EqualTo("Test Meeting"));
            Assert.That(meeting.Presenter, Is.EqualTo("Tim Barcz"));
            Assert.That(meeting.Facility.FacilityId, Is.EqualTo(1));
        }

        [Test]
        public void GetUpcomingMeetings_should_return_two_results()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(activeSessionManager);

            // Act
            var meetings = meetingRepository.GetUpcomingMeetings(DateTime.Parse("2008-07-04"),2);

            // Assert
            Assert.That(meetings.Count, Is.EqualTo(2));
            Assert.That(meetings[0].MeetingId, Is.EqualTo(1), "Meeting id does not match expected value");
            Assert.That(meetings[1].MeetingId, Is.EqualTo(4), "Meeting id does not match expected value");
        }
    }
}