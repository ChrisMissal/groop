using System.Web.Mvc;
using System.Web.Routing;

namespace CRIneta.Website.Routing
{
    public class RouteConfigurator : IRouteConfigurator
    {
        public virtual void RegisterRoutes()
        {
            var routes = RouteTable.Routes;

            routes.Clear();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            // Default/fallback route
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = "" });

            routes.MapRoute("AdminViewMeetings", "{controller}/{action}/{id}",
                            new { controller = "Admin", action = "EditMeeting", id = "" });

        }
    }
}