using System;
using System.Web.Mvc;
using CRIneta.Model;
using CRIneta.DataAccess;

namespace CRIneta.Website.Controllers
{
    public class MeetingController : Controller
    {
        private IMeetingRepository meetingRepository;

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
            return View();
        }

        public ActionResult Show()
        {
            var nextMeeting = meetingRepository.GetNextMeeting(DateTime.Now);
            ViewData["nextMeeting"] = nextMeeting;

            var upcomingMeetings = meetingRepository.GetUpcomingMeetings(nextMeeting.EndTime, 3);
            ViewData["upcomingMeetings"] = upcomingMeetings;

            return View("Show");
        }
    }
}