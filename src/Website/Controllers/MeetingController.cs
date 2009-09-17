using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Website.Models;

namespace CRIneta.Website.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingController(IUserSession userSession, IMeetingRepository meetingRepository) : base(userSession)
        {
            this.meetingRepository = meetingRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var allMeetings = meetingRepository.GetUpcomingMeetings(DateTime.Now, 10);
            ViewData["allMeetings"] = allMeetings;

            return View("List");
        }

        public ActionResult Show()
        {
            var nextMeeting = meetingRepository.GetNextMeeting(DateTime.Now);
            
            return View("Show", nextMeeting);
        }

        [Authorize(Roles = "Users")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RSVP()
        {
            var nextMeeting = meetingRepository.GetNextMeeting(DateTime.Now);
            if (nextMeeting == null)
                return new EmptyResult();

            var email = userSession.GetLoggedInUser().Email;
            var hasRsvpd = nextMeeting.ContainsAttendee(email);
            var model = new RsvpData(hasRsvpd, nextMeeting.MeetingId);
            return View("RSVP", model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RSVP(int id)
        {
            var meeting = meetingRepository.GetById(id);
            if (meeting == null)
                return RedirectToAction("Index");

            var user = userSession.GetLoggedInUser();
            meeting.AddAttendee(user);
            meetingRepository.SaveOrUpdateMeeting(meeting);

            ViewData.Model = meeting;
            return View("Show");
        }
    }
}