using System;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Services.Impl;
using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Core.Services
{

    [TestFixture]
    public class MeetingServiceTests
    {
        [Test]
        public void GetUpcomingMeetings_should_initiate_unit_of_work()
        {
            // Arrange
            var stubMeetingRepository = MockRepository.GenerateStub<IMeetingRepository>();
            var mockUnitOfWorkFactory = MockRepository.GenerateStub<IUnitOfWorkFactory>();
            var meetingService = new MeetingService(stubMeetingRepository, mockUnitOfWorkFactory);

            // Act
            meetingService.GetUpcomingMeetings(DateTime.Now, 5);

            // Assert
            mockUnitOfWorkFactory.AssertWasCalled(x=>x.Create());
        }
    }
}
