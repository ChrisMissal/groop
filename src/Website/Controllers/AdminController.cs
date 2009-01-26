using System.Web.Mvc;
using CRIneta.Web.Core;

namespace CRIneta.Website.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public AdminController(IUserSession userSession) : base (userSession)
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}