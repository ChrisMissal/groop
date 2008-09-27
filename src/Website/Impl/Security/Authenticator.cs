using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using CRIneta.Model;
using CRIneta.Model.Domain;
using CRIneta.Model.Security;
using CRIneta.Model.Security.Cryptography;
using CRIneta.Website.Impl.Security.Principal;

namespace CRIneta.Website.Impl.Security
{
    public class Authenticator : IAuthenticator
    {
        private readonly IHttpContextProvider httpContextProvider;
        private readonly ICryptographer cryptographer;
        private readonly IFormsAuthenticationGateway formsAuthenticationGateway;

        public Authenticator(IHttpContextProvider httpContextProvider, ICryptographer cryptographer, IFormsAuthenticationGateway formsAuthenticationGateway)
        {
            this.cryptographer = cryptographer;
            this.formsAuthenticationGateway = formsAuthenticationGateway;
            this.httpContextProvider = httpContextProvider;
        }

        public void SignIn(Member member)
        {
            formsAuthenticationGateway.SignOut();

            DateTime issued = DateTime.Now;
            DateTime expires = issued.AddMinutes(30);
            string roles = member.IsAdministrator ? "Administrator" : "Users";

            var ticket = new FormsAuthenticationTicket(1, member.Username, issued, expires, false, roles);
            string encryptedTicket = formsAuthenticationGateway.Encrypt(ticket);
            var authCookie = new HttpCookie(formsAuthenticationGateway.FormsCookieName, encryptedTicket) { Expires = ticket.Expiration };

            httpContextProvider.GetCurrentHttpContext().Response.Cookies.Add(authCookie);
        }

        public IIdentity GetActiveIdentity()
        {
            IIdentity identity = httpContextProvider.GetCurrentHttpContext().User.Identity;
            if (identity.Name == "")
            {
                string name = Guid.NewGuid().ToString();

                identity = new GuestIdentity(name);
            }

            return identity;
        }

        public bool VerifyAccount(Member member, string password)
        {
            string passwordHash = cryptographer.Hash(password, member.PasswordSalt);
            return passwordHash == member.Password;
        }

        public void SignOut()
        {
            formsAuthenticationGateway.SignOut();
        }
    }
}