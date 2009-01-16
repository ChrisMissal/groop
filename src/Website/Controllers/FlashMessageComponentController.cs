using System.Web.Mvc;
using CRIneta.Web.Core;

namespace CRIneta.Website.Controllers
{
    public class FlashMessageComponentController : Controller
    {
        private readonly IUserSession session;

        public FlashMessageComponentController(IUserSession session) : base(session)
        {
            this.session = session;
        }

        public ActionResult GetMessages()
        {
            FlashMessage[] flashMessages = session.PopUserMessages();
            return View("FlashMessageList", flashMessages);
        }
    }
}