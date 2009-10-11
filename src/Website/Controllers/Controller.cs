using System.Web.Mvc;
using Groop.Core;
using MvcContrib;

namespace Groop.Website.Controllers
{
    public abstract class Controller : ControllerBase
    {
        protected readonly IUserSession userSession;
        private bool hasLoaded;

        protected Controller(IUserSession userSession)
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
            if (hasLoaded)
                return;

            var user = userSession.GetLoggedInUser();
            var userData = new UserData(user);

            ViewData.Add(userData);

            hasLoaded = true;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}