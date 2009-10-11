using System;
using Groop.Core.Domain;
using Groop.Website.Models;
using NUnit.Framework;

namespace Groop.UnitTests.Website.Models
{
    [TestFixture]
    public class ModelExtensionTests
    {
        private readonly DateTime endTime = DateTime.Parse("2009-08-16");
        private readonly DateTime startTime = DateTime.Parse("2009-08-17");
        private readonly Facility facility = new Facility {FacilityId = 10211982};

        [Test]
        public void MeetingData_can_be_created_from_Meeting()
        {
            var meeting = new Meeting
                              {
                                  Description = "description",
                                  EndTime = endTime,
                                  Facility = facility,
                                  MeetingId = 1234567,
                                  Presenter = "presenter",
                                  StartTime = startTime,
                                  Title = "title"
                              };

            var meetingData = meeting.ToMeetingData();

            Assert.That(meeting.Description, Is.EqualTo(meetingData.Description));
            Assert.That(meeting.MeetingId, Is.EqualTo(meetingData.MeetingId));
            Assert.That(meeting.Presenter, Is.EqualTo(meetingData.Presenter));
            Assert.That(meeting.Title, Is.EqualTo(meetingData.Title));
            Assert.That(meeting.Facility.FacilityId, Is.EqualTo(meetingData.FacilityId));
            Assert.That(meeting.EndTime, Is.EqualTo(meetingData.EndTime));
            Assert.That(meeting.StartTime, Is.EqualTo(meetingData.StartTime));
        }
    }
}