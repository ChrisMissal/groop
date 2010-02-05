using System;
using Groop.Core.Data;
using Groop.Core.Domain;
using Groop.Core.Services.Impl;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Core.Services
{
    [TestFixture]
    public class MeetingServiceTests
    {
        private IMeetingRepository stubMeetingRepository;

        [SetUp]
        public void SetUp()
        {
            stubMeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
        }

        [Test]
        public void GetUpcomingMeetings_should_call_MeetinRepository()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var meetingService = GetService();

            // Act
            meetingService.GetUpcomingMeetings(dateTime, 5);

            // Assert
            stubMeetingRepository.AssertWasCalled(x => x.GetUpcomingMeetings(dateTime, 5));
        }

        [Test]
        public void GetNextMeeting_should_return_UnknownMeeting_if_MeetingRepository_returns_null()
        {
            // Arrange
            var dateTime = Arg<DateTime>.Is.Anything;
            var meetingService = GetService();
            stubMeetingRepository.Stub(x => x.GetNextMeeting(dateTime)).Return(null);

            // Act
            var meeting = meetingService.GetNextMeeting(dateTime);

            // Assert
            Assert.That(meeting, Is.TypeOf(typeof(UnknownMeeting)));
        }

        private MeetingService GetService()
        {
            return new MeetingService(stubMeetingRepository);
        }
    }
}