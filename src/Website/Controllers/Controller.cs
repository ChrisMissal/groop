using System.Web.Mvc;

namespace CRIneta.Website.Controllers
{
    public abstract class Controller : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}