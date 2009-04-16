using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;

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
            ViewData["nextMeeting"] = nextMeeting;

            if (nextMeeting != null)
            {
                var upcomingMeetings = meetingRepository.GetUpcomingMeetings(nextMeeting.EndTime, 3);
                ViewData["upcomingMeetings"] = upcomingMeetings;    
            }
            
            return View("Show");
        }

        public ActionResult RSVP(int id)
        {
            var meeting = meetingRepository.GetById(id);
            if (meeting == null)
                return RedirectToAction("Index");

            var user = userSession.GetLoggedInUser();
            var attendee = new Attendee(user.Name.First, user.Name.Last);
            meeting.AddAttendee(attendee);

            ViewData.Model = meeting;
            return View("Show");
        }
    }
}