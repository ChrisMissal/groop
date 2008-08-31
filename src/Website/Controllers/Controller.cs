using System.Web.Mvc;
using CRIneta.Model;
using CRIneta.Model.Domain;
using MvcContrib;

namespace CRIneta.Website.Controllers
{
    public abstract class Controller : System.Web.Mvc.Controller
    {
        private readonly IUserSession userSession;
        private bool hasLoaded;

        public Controller(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        protected virtual void AddErrorMessage(string message)
        {
            userSession.PushUserMessage(FlashMessage.MessageType.Error, message);
        }
        
        protected virtual void AddErrorMessages(string[] messages)
        {
            foreach (var s in messages)
            {
                AddErrorMessage(s);
            }
        }

        protected virtual void AddInformationalMessage(string message)
        {
            userSession.PushUserMessage(FlashMessage.MessageType.Message, message);
        }

        protected virtual void AddInformationalMessage(string[] messages)
        {
            foreach (var s in messages)
            {
                AddInformationalMessage(s);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!hasLoaded)
            {
                Member user = userSession.GetLoggedInUser();

                UserData userData = new UserData(user);

                ViewData.Add(userData);

                hasLoaded = true;
            }

        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        
    }
}