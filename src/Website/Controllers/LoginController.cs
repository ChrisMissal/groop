using System.Web.Mvc;
using System.Web.Security;
using Castle.Components.Validator;
using Groop.Core;
using Groop.Core.Domain;
using Groop.Core.Security;
using Groop.Core.Services;
using Groop.Website.Helpers.Filters;
using Groop.Website.Impl.UserInput;
using Groop.Website.Models;

namespace Groop.Website.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IFormsAuthenticationGateway formsAuthenticationGateway;
        private readonly IUserSession userSession;

        public LoginController(IAuthenticationService authenticationService, IFormsAuthenticationGateway formsAuthenticationGateway, IUserSession userSession)
        {
            this.authenticationService = authenticationService;
            this.formsAuthenticationGateway = formsAuthenticationGateway;
            this.userSession = userSession;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string username)
        {
            var model = new LoginInput();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateModel(typeof(LoginInput))]
        public ActionResult Index(LoginInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            if (authenticationService.SignIn(input.Username, input.Password))
            {
                formsAuthenticationGateway.RedirectFromLoginPage(input.Username, false);
            }

            ModelState.AddModelError("Login","Invalid Login");

            return View(input);
        }

        public ActionResult LogOut()
        {
            authenticationService.SignOut();
            userSession.PushUserMessage(FlashMessage.MessageType.Message, "You've been sucessfully logged out.");
            return RedirectToAction("Index", "Home");
        }
        
    }
}