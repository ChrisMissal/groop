using System.Web.Security;
using CRIneta.Model.Security;

namespace CRIneta.Website.Impl
{
    public class FormsAuthenticationGateway : IFormsAuthenticationGateway
    {
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public string Encrypt(FormsAuthenticationTicket ticket)
        {
            return FormsAuthentication.Encrypt(ticket);
        }

        public string FormsCookieName
        {
            get { return FormsAuthentication.FormsCookieName; }
        }
    }
}