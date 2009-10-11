using System.Web;

namespace Groop.Core
{
    public interface IHttpContextProvider
    {
        HttpContextBase GetCurrentHttpContext();
        HttpSessionStateBase GetHttpSession();
    }
}