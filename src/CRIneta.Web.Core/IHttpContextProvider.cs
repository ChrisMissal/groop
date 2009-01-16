using System.Web;

namespace CRIneta.Model
{
    public interface IHttpContextProvider
    {
        HttpContextBase GetCurrentHttpContext();
        HttpSessionStateBase GetHttpSession();
    }
}