using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Services;
using Groop.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Website.Controllers
{
    [TestFixture]
    public class MeetingControllerTests
    {

        [Test]
        public void MeetingController_should_call_meetingRepository_GetNextMeeting_for_Show()
        {
            var fakeMeetingService = MockRepository.GenerateMock<IMeetingService>();
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new MeetingController(fakeUserSession, fakeMeetingService);

            controller.Show();

            fakeMeetingService.AssertWasCalled(x => x.GetNextMeeting(Arg<DateTime>.Is.Anything));
        }

        //[Test]
        //public void MeetingController_should_call_meetingRepository_GetById_for_RSVP()
        //{
        //    var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingService>();
        //    var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
        //    var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

        //    controller.RSVP(0);

        //    fakeMeetingRepository.AssertWasCalled(x => x.GetById(0));
        //}

        //[Test]
        //public void MeetingController_should_return_Meeting_in_ViewData_for_RSVP()
        //{
        //    var fakeMeeting = new Meeting();
        //    var fakeMeetingRepository = MockRepository.GenerateMock<IMeetingService>();
        //    fakeMeetingRepository.Stub(x => x.GetById(0)).Return(fakeMeeting);

        //    var fakeUser = new Member { FirstName = "Chris", LastName = "Missal" };
        //    var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
        //    fakeUserSession.Stub(x => x.GetLoggedInUser()).Return(fakeUser);

        //    var controller = new MeetingController(fakeUserSession, fakeMeetingRepository);

        //    var result = controller.RSVP(0) as ViewResult;

        //    Assert.That(result.ViewData.Model, Is.TypeOf(typeof(Meeting)));
        //}

        //[Test]
        //public void MeetingController_should_return_EmptyResult_if_NextMeeting_is_null()
        //{
        //    // Arrange
        //    var meetingRepository = MockRepository.GenerateStub<IMeetingService>();
        //    meetingRepository.Stub(x => x.GetNextMeeting(DateTime.Now)).IgnoreArguments().Return(null);

        //    var controller = new MeetingController(null, meetingRepository);

        //    // Act
        //    var result = controller.RSVP() as EmptyResult;

        //    // Assert
        //    Assert.That(result, Is.TypeOf(typeof(EmptyResult)));
        //}

        //[Test]
        //public void MeetingController_should_return_View_with_RsvpData_as_Model_if_NextMeeting_isnt_null()
        //{
        //    // Arrange
        //    var fakeUser = MockRepository.GenerateStub<Member>();
        //    var userSession = MockRepository.GenerateStub<IUserSession>();
        //    userSession.Stub(x => x.GetLoggedInUser()).Return(fakeUser);
        //    var meetingRepository = MockRepository.GenerateStub<IMeetingService>();
        //    var fakeMeeting = MockRepository.GenerateStub<Meeting>();
        //    fakeMeeting.MeetingId = 12;
        //    fakeMeeting.Stub(x => x.ContainsAttendee(null)).Return(true);
        //    meetingRepository.Stub(x => x.GetNextMeeting(DateTime.Now)).IgnoreArguments().Return(fakeMeeting);


        //    var controller = new MeetingController(userSession, meetingRepository);

        //    // Act
        //    var result = controller.RSVP() as ViewResult;

        //    // Assert
        //    Assert.That(result.ViewData.Model, Is.TypeOf(typeof(RsvpData)));
        //    Assert.That((result.ViewData.Model as RsvpData).MeetingId, Is.EqualTo(12));
        //}
    }
}