using System.Web.Security;

namespace Groop.Core.Security
{
    public interface IFormsAuthenticationGateway
    {
        void SignOut();
        string Encrypt(FormsAuthenticationTicket ticket);
        string FormsCookieName { get; }
    }
}