using System.Web.Routing;

namespace CRIneta.Website.Routing
{
    /// <summary>
    /// Creates
    /// </summary>
    public class LowercaseRoute : Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        /// <summary>
        /// Gets the virtual path as a lowered string if it exists
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var path = base.GetVirtualPath(requestContext, values);

            if (path != null)
                path.VirtualPath = path.VirtualPath.ToLowerInvariant();

            return path;
        }
    }
}