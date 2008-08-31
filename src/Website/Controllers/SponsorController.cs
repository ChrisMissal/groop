using System.Web.Mvc;
using CRIneta.Model;

namespace CRIneta.Website.Controllers
{
    public class SponsorController : Controller
    {
        public SponsorController(IUserSession userSession) : base(userSession)
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
    }
}