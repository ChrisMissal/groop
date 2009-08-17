using System.Web.Mvc;
using CRIneta.Web.Core;

namespace CRIneta.Website.Controllers
{
    public class SponsorController : Controller
    {
        public SponsorController(IUserSession userSession) : base(userSession)
        {
            
        }
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult List()
        {
            return View("List");
        }
    }
}