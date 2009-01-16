using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;

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
    }
}