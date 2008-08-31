using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Castle.Components.Validator;
using CRIneta.DataAccess;
using CRIneta.Model;
using CRIneta.Model.Domain;
using CRIneta.Model.Security;
using CRIneta.Model.Security.Cryptography;
using CRIneta.Website.Impl.UserInput;
using CRIneta.Website.Services.Email;
using MvcContrib.Filters;

namespace CRIneta.Website.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [HandleError]
    public class AccountController : Controller
    {
        private const string salt = "#rstpsswrd$";
        private readonly IAuthenticator authenticator;
        private readonly ICryptographer cryptographer;
        private readonly IEmailService emailService;
        private readonly IMemberRepository memberRepository;
        private readonly IUserSession userSession;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userSession">The user session.</param>
        /// <param name="memberRepository">The user repository.</param>
        /// <param name="authenticator">The authenticator.</param>
        /// <param name="cryptographer">The cryptographer.</param>
        /// <param name="emailService"></param>
        public AccountController (IUserSession userSession, IMemberRepository memberRepository, IAuthenticator authenticator, ICryptographer cryptographer, IEmailService emailService) : base(userSession)
        {
            this.userSession = userSession;
            this.memberRepository = memberRepository;
            this.authenticator = authenticator;
            this.cryptographer = cryptographer;
            this.emailService = emailService;
        }

        #region Index Actions

        [Authorize(Roles="Users")]
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
        
        [PostOnly]
        public ActionResult ProcessChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            ViewData["Title"] = "Change Password";
    
            return View();
        }

        #endregion

        #region Login Actions

        public ActionResult Login()
        {
            ViewData["Title"] = "Login";

            return View("Login");
        }

        public ActionResult ProcessLogin(string username, string password, string redirectUrl)
        {
            var loginData = new LoginData(username, password);

            var validationRunner = new ValidatorRunner(new CachedValidationRegistry());

            if (!validationRunner.IsValid(loginData))
            {
                base.AddErrorMessages(validationRunner.GetErrorSummary(loginData).ErrorMessages);
                return RedirectToAction("Login");
            }

            Member user = memberRepository.GetByUsername(username);

            if (user != null && authenticator.VerifyAccount(user, password))
            {
                authenticator.SignIn(user);

                if (redirectUrl != null)
                    return Redirect(redirectUrl);

                return RedirectToAction("Index", "Account");
            }

            //login failed
            base.AddErrorMessage("Invalid Login");
            return RedirectToAction("Login");
        }

        #endregion

        #region LogOut Actions

        public ActionResult LogOut()
        {
            authenticator.SignOut();
            userSession.PushUserMessage(FlashMessage.MessageType.Message, "You've been sucessfully logged out.");
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Register Actions

        public ActionResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        public ActionResult ProcessRegister(string username, string email, string password, string confirmPassword)
        {
            ViewData["Title"] = "Register";
            
            return View();
        }

        #endregion
    }
}