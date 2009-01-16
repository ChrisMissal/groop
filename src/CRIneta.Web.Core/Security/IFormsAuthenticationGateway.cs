using System.Web.Security;

namespace CRIneta.Model.Security
{
    public interface IFormsAuthenticationGateway
    {
        void SignOut();
        string Encrypt(FormsAuthenticationTicket ticket);
        string FormsCookieName { get; }
    }
}