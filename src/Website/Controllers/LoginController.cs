using System.Web.Mvc;
using Castle.Components.Validator;
using Groop.Core.Services;
using Groop.Website.Impl.UserInput;
using Groop.Website.Models;

namespace Groop.Website.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var model = new LoginInput();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string username, string password, string redirectUrl)
        {
            var loginData = new LoginData(username, password);

            var validationRunner = new ValidatorRunner(new CachedValidationRegistry());

            if (!validationRunner.IsValid(loginData))
            {
                //AddErrorMessages(validationRunner.GetErrorSummary(loginData).ErrorMessages);
                return RedirectToAction("Login");
            }

            if (!authenticationService.SignIn(username, password))
            {
                //AddErrorMessage("Invalid Login");
                return RedirectToAction("Login");
            }

            if (redirectUrl != null)
                return Redirect(redirectUrl);

            return RedirectToAction("Index", "Account");
        }
        
    }
}