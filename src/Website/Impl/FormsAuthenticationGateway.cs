using System;
using System.Web.Security;
using Groop.Core.Security;

namespace Groop.Website.Impl
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

        public void RedirectFromLoginPage(string username, bool createPersistentCookie)
        {
            FormsAuthentication.RedirectFromLoginPage(username, createPersistentCookie);
        }
    }
}