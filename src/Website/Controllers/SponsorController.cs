using System.Web.Mvc;
using Groop.Core;

namespace Groop.Website.Controllers
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
    }
}