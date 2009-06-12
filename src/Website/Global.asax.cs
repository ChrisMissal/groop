using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Castle.Core;
using CRIneta.Web.Core.Security;
using CRIneta.Website.Helpers;
using CRIneta.Website.Routing;
using MvcContrib.Castle;

namespace CRIneta.Website
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
            //ControllerBuilder.Current.DefaultNamespaces.Add("CRI");

            setupRoutes();
        }

        public static void RegisterRoutesAndControllers()
        {
            IoC.Register<IRouteConfigurator, RouteConfigurator>("route-configurator");

            //add all controllers
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(IController).IsAssignableFrom(type))
                {
                    IoC.Register(type.Name.ToLower(), type, LifestyleType.Transient);
                }
            }
        }

        private static void setupRoutes()
        {
            var configurator = IoC.Resolve<IRouteConfigurator>();
            configurator.RegisterRoutes();
        }

        public void Session_Start()
        {
            Console.WriteLine("here");
        }
    }
}