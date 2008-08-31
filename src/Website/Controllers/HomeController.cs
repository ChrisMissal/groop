using System.Web.Mvc;
using CRIneta.Model;

namespace CRIneta.Website.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public HomeController(IUserSession userSession) : base(userSession)
        {
            
        }

        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
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