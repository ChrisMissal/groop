using System.Web.Mvc;
using CRIneta.Model;

namespace CRIneta.Website.Controllers
{
    public class MeetingController : Controller
    {
        public MeetingController(IUserSession userSession) : base(userSession)
        {
            
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
            return View();
        }
    }
}