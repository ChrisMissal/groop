using System.Web;
using CRIneta.Model;

namespace CRIneta.Website.Impl
{
    public class HttpContextProvider : IHttpContextProvider
    {
        #region IHttpContextProvider Members

        public HttpContextBase GetCurrentHttpContext()
        {
            return new HttpContextWrapper2(HttpContext.Current);
        }

        public HttpSessionStateBase GetHttpSession()
        {
            return GetCurrentHttpContext().Session;
        }

        #endregion
    }
}