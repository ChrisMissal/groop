using System;
using System.Web.Mvc;
using System.Web.Routing;
using Groop.Framework;

namespace Groop.Website.Routing
{
    public static class RouteCollectionExtensions
    {
        public static void MapRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            MapRoute(routes, name, url, defaults,null);
        }

        public static void MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            Validate.IsNotNull(()=>routes, routes);
            Validate.IsNotNull(()=>url, url);
            
            var route = new LowercaseRoute(url, new MvcRouteHandler())
                            {
                                Defaults = new RouteValueDictionary(defaults),
                                Constraints = new RouteValueDictionary(constraints)
                            };

            if (String.IsNullOrEmpty(name))
                routes.Add(route);
            else
                routes.Add(name, route);
        }
    }
}