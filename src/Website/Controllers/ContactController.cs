using System;
using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Web.Core.Domain;
using CRIneta.Web.Core.Presentation;
using CRIneta.Web.Core.Services;
using IValidator=CRIneta.Web.Core.Validation.IValidator;

namespace CRIneta.Website.Controllers
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
        public ActionResult Index([Bind(Prefix = "")] ContactMessageData contactMessageData)
        {
            if (contactMessageData == null)
                return View();

            var valid = validator.IsValid(contactMessageData);

            if (valid)
            {
                var contactMessage = new ContactMessage(contactMessageData.Email, contactMessageData.Name, contactMessageData.Subject,
                                                        contactMessageData.Message);
                try
                {
                    emailService.Send(contactMessage);
                    TempData["ContactMessage"] = contactMessage;
                }
                catch (Exception ex)
                {
                    AddErrorMessage(ex.Message);
                    throw;
                }

                return RedirectToAction("Sent");
            }
            return View();
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