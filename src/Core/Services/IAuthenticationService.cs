using System;
using System.Web;
using System.Web.Security;
using Groop.Core.Data;
using Groop.Core.Domain;
using Groop.Core.Security;
using Groop.Core.Security.Cryptography;

namespace Groop.Core.Services
{
    public interface IAuthenticationService
    {
        bool VerifyAccount(Member member, string password);
        bool SignIn(string username, string password);
        void SignOut();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICryptographer cryptographer;
        private readonly IMemberRepository memberRepository;

        public AuthenticationService(IMemberRepository memberRepository, ICryptographer cryptographer)
        {
            this.memberRepository = memberRepository;
            this.cryptographer = cryptographer;
        }

        #region Implementation of IAuthenticationService

        public bool VerifyAccount(Member member, string password)
        {
            string passwordHash = cryptographer.Hash(password, member.PasswordSalt);
            return passwordHash == member.Password;
        }

        public bool SignIn(string username, string password)
        {
            var member = memberRepository.GetByUsername(username);

            if (member == null || !VerifyAccount(member, password))
            {
                return false;
            }

            FormsAuthentication.SignOut();

            var identity = new UserIdentity().From(member);

            SetActiveIdentity(identity);

            return true;
        }

        public void SetActiveIdentity(IUserIdentity identity)
        {
            if(!identity.IsAuthenticated)
                return;

            var issued = DateTime.Now;
            var expires = issued.AddMinutes(30);
            
            var ticket = new FormsAuthenticationTicket(1, identity.MemberId.ToString(), issued, expires, false, identity.Serialize());
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                                 {
                                     Expires = ticket.Expiration
                                 };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            HttpContext.Current.User = new UserPrincipal().With(identity);
            
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}