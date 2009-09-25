using System.Web.Security;

namespace CRIneta.Web.Core.Security
{
    public interface IFormsAuthenticationGateway
    {
        void SignOut();
        string Encrypt(FormsAuthenticationTicket ticket);
        string FormsCookieName { get; }
    }
}