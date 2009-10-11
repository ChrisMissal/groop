using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Castle.Core;
using Groop.Core.Security;
using Groop.Website.Helpers;
using Groop.Website.Routing;
using MvcContrib.Castle;

namespace Groop.Website
{
    public class GlobalApplication : HttpApplication
    {
        public GlobalApplication()
        {
            AuthenticateRequest += GlobalApplication_AuthenticateRequest;
        }

        void GlobalApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

            var principal = new UserPrincipal();

            if (cookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);

                var userIdentity = new UserIdentity().Deserialize(ticket.UserData);

                principal.With(userIdentity);

            }

            Context.User = principal;
        }

        protected void Application_Start()
        {
            RegisterRoutesAndControllers();

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.GetContainer()));

            setupRoutes();
        }

        public static void RegisterRoutesAndControllers()
        {
            IoC.Register<IRouteConfigurator, RouteConfigurator>("route-configurator");

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof (IController).IsAssignableFrom(type))
                .ForEach(type => IoC.Register(type.Name.ToLower(), type, LifestyleType.Transient));
        }

        private static void setupRoutes()
        {
            var configurator = IoC.Resolve<IRouteConfigurator>();
            configurator.RegisterRoutes();
        }
    }
}