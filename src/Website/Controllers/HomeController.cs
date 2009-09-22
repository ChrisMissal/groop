using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;

namespace CRIneta.Website.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IMeetingRepository meetingRepository;

        public HomeController(IUserSession userSession, IMeetingRepository meetingRepository) : base(userSession)
        {
            this.meetingRepository = meetingRepository;
        }

        public ActionResult Index()
        {
            var upcomingMeetings = meetingRepository.GetUpcomingMeetings(DateTime.Now, 5);
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