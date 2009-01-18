using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.Core;
using CRIneta.Website.Helpers;
using CRIneta.Website.Routing;
using MvcContrib.Castle;

namespace CRIneta.Website
{
    public class GlobalApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutesAndControllers();

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.GetContainer()));
            ControllerBuilder.Current.DefaultNamespaces.Add("CRI");

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
    }
}