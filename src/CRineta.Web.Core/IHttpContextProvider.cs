using System.Web;

namespace CRIneta.Web.Core
{
    public interface IHttpContextProvider
    {
        HttpContextBase GetCurrentHttpContext();
        HttpSessionStateBase GetHttpSession();
    }
}