using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Services;

namespace Groop.Website.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IMeetingService meetingService;

        public HomeController(IUserSession userSession, IMeetingService meetingService) : base(userSession)
        {
            this.meetingService = meetingService;
        }

        public ActionResult Index()
        {
            var upcomingMeetings = meetingService.GetUpcomingMeetings(DateTime.Now, 5);
            ViewData["upcomingMeetings"] = upcomingMeetings;

            return View("Index");
        }

        public ActionResult Officers()
        {
            return View("Officers");
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }
    }
}