using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Services;
using Groop.Website.Models;

namespace Groop.Website.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingService meetingService;

        public MeetingController(IUserSession userSession, IMeetingService meetingService) : base(userSession)
        {
            this.meetingService = meetingService;
        }

        public ActionResult List()
        {
            var allMeetings = meetingService.GetUpcomingMeetings(DateTime.Now, 10);
            ViewData["allMeetings"] = allMeetings;

            return View("List");
        }

        public ActionResult Show()
        {
            var nextMeeting = meetingService.GetNextMeeting(DateTime.Now);
            
            return View("Show", nextMeeting);
        }

        public ContentResult Detail(int id)
        {
            return new ContentResult()
                       {
                           Content = id.ToString()
                       };
        }

        [Authorize(Roles = "Users")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RSVP()
        {
            var nextMeeting = meetingService.GetNextMeeting(DateTime.Now);
            if (nextMeeting == null)
                return new EmptyResult();

            var email = userSession.GetLoggedInUser().Email;
            var hasRsvpd = nextMeeting.ContainsAttendee(email);
            var model = new RsvpData(hasRsvpd, nextMeeting.MeetingId);
            return View("RSVP", model);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult RSVP(int id)
        //{
        //    var meeting = meetingRepository.GetById(id);
        //    if (meeting == null)
        //        return RedirectToAction("Index");

        //    var user = userSession.GetLoggedInUser();
        //    meeting.AddAttendee(user);
        //    meetingRepository.Update(meeting);

        //    ViewData.Model = meeting;
        //    return View("Show");
        //}

        public ActionResult UpcomingMeetings()
        {
            var upcomingMeetings = meetingService.GetUpcomingMeetings(DateTime.Now, 5);
            return View(upcomingMeetings);
        }
    }
}