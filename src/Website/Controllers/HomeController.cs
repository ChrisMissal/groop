using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Services;

namespace CRIneta.Website.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IMeetingService meetingService;
        private readonly IMeetingRepository meetingRepository;

        public HomeController(IUserSession userSession, IMeetingService meetingService, IMeetingRepository meetingRepository) : base(userSession)
        {
            this.meetingService = meetingService;
            this.meetingRepository = meetingRepository;
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