using System.Web.Mvc;
using Groop.Core;

namespace Groop.Website.Controllers
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