using Groop.Core;
using NUnit.Framework;

using Rhino.Mocks;
using System.Web.Mvc;

namespace Groop.UnitTests.Website.Controllers
{
    [TestFixture]
    public class AdminControllerMeetingTests : AdminControllerTestBase
    {
        [Test]
        public void If_meeting_is_not_found_for_EditMeeting_then_ViewMeetings_view_is_shown_with_error_Message()
        {
            var controller = GetController();
            meetingRepository.Stub(x => x.GetById(1)).Return(null);

            var result = controller.EditMeeting(1) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("ViewMeetings"));
            userSession.AssertWasCalled(x => 
                                        x.PushUserMessage(FlashMessage.MessageType.Error, "Meeting not found."));
        }

        [Test]
        public void If_ViewMeetings_returns_no_results_then_Index_view_is_shown_with_Error_message()
        {
            var controller = GetController();
            meetingRepository.Stub(x => x.GetAllMeetings()).Return(null);

            var result = controller.ViewMeetings() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
            userSession.AssertWasCalled(x => 
                                        x.PushUserMessage(FlashMessage.MessageType.Error, "No meetings found."));
        }
    }
}