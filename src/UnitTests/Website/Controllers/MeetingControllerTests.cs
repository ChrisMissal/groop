using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Website.Controllers
{
    [TestFixture]
    public class MeetingControllerTests
    {
        [Test]
        public void MeetingController_should_call_meetingRepository_GetUpcomingMeetings_for_List()
        {
            var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

            controller.List();

            fakeMeetingRepository.AssertWasCalled(x => x.GetUpcomingMeetings(Arg<DateTime>.Is.Anything, Arg<int>.Is.Anything));
        }

        [Test]
        public void MeetingController_should_call_meetingRepository_GetNextMeeting_for_Show()
        {
            var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

            controller.Show();

            fakeMeetingRepository.AssertWasCalled(x => x.GetNextMeeting(Arg<DateTime>.Is.Anything));
        }

        [Test]
        public void MeetingController_should_call_meetingRepository_GetById_for_RSVP()
        {
            var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

            controller.RSVP(0);

            fakeMeetingRepository.AssertWasCalled(x => x.GetById(0));
        }

        [Test]
        public void MeetingController_should_return_Meeting_in_ViewData_for_RSVP()
        {
            var fakeMeeting = new Meeting();
            var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
            fakeMeetingRepository.Stub(x => x.GetById(0)).Return(fakeMeeting);

            var fakeUser = new Member { Name = new Name { First = "Chris", Last = "Missal" } };
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            fakeUserSession.Stub(x => x.GetLoggedInUser()).Return(fakeUser);

            var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

            var result = controller.RSVP(0) as ViewResult;

            Assert.That(result.ViewData.Model, Is.TypeOf(typeof(Meeting)));
        }
    }
}