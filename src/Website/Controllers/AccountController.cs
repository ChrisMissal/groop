using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Components.Validator;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Web.Core.Presentation;
using CRIneta.Web.Core.Security;
using CRIneta.Web.Core.Security.Cryptography;
using CRIneta.Web.Core.Services;
using CRIneta.Website.Impl.UserInput;

namespace CRIneta.Website.Controllers
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
        private readonly IMemberRepository memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userSession">The user session.</param>
        /// <param name="memberRepository">The user repository.</param>
        /// <param name="authenticator">The authenticator.</param>
        /// <param name="cryptographer">The cryptographer.</param>
        /// <param name="authenticationService"></param>
        public AccountController(IUserSession userSession, IMemberRepository memberRepository, IAuthenticator authenticator, ICryptographer cryptographer, IAuthenticationService authenticationService) : base(userSession)
        {
            this.memberRepository = memberRepository;
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string first, string last, string username, string email, string password, string passwordConfirm)
        {
            var registrationData = new RegistrationData(first, last, username, email, password, passwordConfirm);

            var validationRunner = new ValidatorRunner(new CachedValidationRegistry());

            if (!validationRunner.IsValid(registrationData))
            {
                // there were errors, report them back to the user
                PushErrorMessages(validationRunner.GetErrorSummary(registrationData).ErrorMessages, userSession);
                return RedirectToAction("Register");
            }


            Member member = memberRepository.GetByUsername(username);

            if (member != null)
            {
                userSession.PushUserMessage(FlashMessage.MessageType.Error, "A user with that username already exists, please try again");
                return View("Register");
            }

            member = new Member
                         {
                             Username = username,
                             Email = email,
                             PasswordSalt = cryptographer.CreateSalt(),
                             FirstName = first,
                             LastName = last
                         };

            member.Password = cryptographer.Hash(password, member.PasswordSalt);

            memberRepository.AddMember(member);

            authenticator.SignIn(member);

            return RedirectToAction("Index", "Account");
        }

        #endregion

        private void PushErrorMessages(IEnumerable<string> messages, IUserSession session)
        {
            foreach (string s in messages)
            {
                session.PushUserMessage(FlashMessage.MessageType.Error, s);
            }
        }
    }
}