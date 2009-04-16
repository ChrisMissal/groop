using System.Web.Mvc;
using System.Web.Routing;

namespace CRIneta.Website.Routing
{
    public class RouteConfigurator : IRouteConfigurator
    {
        public virtual void RegisterRoutes()
        {
            var routes = RouteTable.Routes;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute("AdminViewMeetings", "{controller}/{action}/{id}",
                            new { controller = "Admin", action = "EditMeeting", id = "" });

        }
    }
}