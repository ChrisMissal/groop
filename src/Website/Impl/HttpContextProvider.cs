using System.Web;
using Groop.Core;

namespace Groop.Website.Impl
{
    public class HttpContextProvider : IHttpContextProvider
    {
        #region IHttpContextProvider Members

        public HttpContextBase GetCurrentHttpContext()
        {
            return new HttpContextWrapper(HttpContext.Current);
        }

        public HttpSessionStateBase GetHttpSession()
        {
            return GetCurrentHttpContext().Session;
        }

        #endregion
    }
}