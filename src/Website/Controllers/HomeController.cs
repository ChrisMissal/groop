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
            var upcomingMeeting = meetingService.GetNextMeeting(DateTime.Now);
            return View("Index", upcomingMeeting);
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