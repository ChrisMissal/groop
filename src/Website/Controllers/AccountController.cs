using System.Web.Mvc;
using Castle.Components.Validator;
using Groop.Core;
using Groop.Core.Domain;
using Groop.Core.Presentation;
using Groop.Core.Security;
using Groop.Core.Security.Cryptography;
using Groop.Core.Services;
using Groop.Website.Impl.UserInput;
using MvcContrib;

namespace Groop.Website.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [HandleError]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IAuthenticator authenticator;
        private readonly ICryptographer cryptographer;
        private readonly IMemberService memberService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userSession">The user session.</param>
        /// <param name="memberService">The user repository.</param>
        /// <param name="authenticator">The authenticator.</param>
        /// <param name="cryptographer">The cryptographer.</param>
        /// <param name="authenticationService"></param>
        public AccountController(IUserSession userSession, IMemberService memberService, IAuthenticator authenticator, ICryptographer cryptographer, IAuthenticationService authenticationService) : base(userSession)
        {
            this.memberService = memberService;
            this.authenticator = authenticator;
            this.cryptographer = cryptographer;
            this.authenticationService = authenticationService;
        }

        #region Index Actions

        [Authorize()]
        public ActionResult Index()
        {
            ViewData["Title"] = "My Account";
            return View();
        }

        #endregion

        #region Change Password Actions

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["Title"] = "Change Password";

            return View();
        }

        public ActionResult ChangePasswordSuccess()
        {
            ViewData["Title"] = "Change Password";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            ViewData["Title"] = "Change Password";

            return View();
        }

        #endregion

        #region Login Actions

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            ViewData["Title"] = "Login";

            return View("Login");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password, string redirectUrl)
        {
            var loginData = new LoginData(username, password);

            var validationRunner = new ValidatorRunner(new CachedValidationRegistry());

            if (!validationRunner.IsValid(loginData))
            {
                AddErrorMessages(validationRunner.GetErrorSummary(loginData).ErrorMessages);
                return RedirectToAction("Login");
            }

            if (!authenticationService.SignIn(username, password))
            {
                AddErrorMessage("Invalid Login");
                return RedirectToAction("Login");
            }

            if (redirectUrl != null)
                return Redirect(redirectUrl);

            return RedirectToAction("Index", "Account");
        }

        #endregion

        #region LogOut Actions

        public ActionResult LogOut()
        {
            authenticationService.SignOut();
            userSession.PushUserMessage(FlashMessage.MessageType.Message, "You've been sucessfully logged out.");
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Register Actions

        [AcceptVerbs(HttpVerbs.Get), RebindTempData(typeof(RegistrationData))]
        public ActionResult Register()
        {
            var model = ViewData.Model as RegistrationData ?? new RegistrationData();

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(RegistrationData registrationData)
        {
            var validationRunner = new ValidatorRunner(new CachedValidationRegistry());

            if (!validationRunner.IsValid(registrationData))
            {
                // there were errors, report them back to the user
                foreach (var errorMessage in validationRunner.GetErrorSummary(registrationData).ErrorMessages)
                    AddErrorMessage(errorMessage);

                TempData.Add(registrationData);
                return RedirectToAction("Register");
            }

            Member member = memberService.GetByUsername(registrationData.UserName);

            if (member != null)
            {
                userSession.PushUserMessage(FlashMessage.MessageType.Error, "A user with that username already exists, please try again");
                TempData.Add(registrationData);
                return RedirectToAction("Register");
            }

            member = new Member
                         {
                             Username = registrationData.UserName,
                             Email = registrationData.Email,
                             PasswordSalt = cryptographer.CreateSalt(),
                             FirstName = registrationData.FirstName,
                             LastName = registrationData.LastName
                         };

            member.Password = cryptographer.Hash(registrationData.Password, member.PasswordSalt);
            
            memberService.Add(member);

            authenticator.SignIn(member);

            return RedirectToAction("Index");
        }

        #endregion
    }
}