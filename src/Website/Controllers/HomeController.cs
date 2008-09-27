using System;
using System.Web.Mvc;
using CRIneta.Model;
using CRIneta.DataAccess;

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
            var upcomingMeetings = meetingRepository.GetUpcomingMeetings(DateTime.Now, 0);
            ViewData["upcomingMeetings"] = upcomingMeetings;

            return View("Index");
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}