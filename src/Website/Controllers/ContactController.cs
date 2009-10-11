using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Domain;
using Groop.Core.Presentation;
using Groop.Core.Services;
using IValidator=Groop.Core.Validation.IValidator;

namespace Groop.Website.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IValidator validator;

        public ContactController(IUserSession userSession, IEmailService emailService, IValidator validator)
            : base(userSession)
        {
            this.emailService = emailService;
            this.validator = validator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(ContactMessageData contactMessageData)
        {
            if (contactMessageData == null)
                return View();

            if (!validator.IsValid(contactMessageData))
            {
                AddErrorMessage("Please fill in all fields correctly, thanks!");
                return View();
            }

            var contactMessage = new ContactMessage(contactMessageData.Email, contactMessageData.Name, contactMessageData.Subject, contactMessageData.Message);
            try
            {
                emailService.Send(contactMessage);
                TempData["ContactMessage"] = contactMessage;
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }

            return RedirectToAction("Sent");
        }

        public ActionResult Sent()
        {
            var message = TempData["ContactMessage"];
            if (message == null)
                return RedirectToAction("Index");

            ViewData["ContactMessage"] = message;
            return View();
        }
    }
}