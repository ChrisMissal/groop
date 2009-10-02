using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Web.Core.Security;
using CRIneta.Web.Core.Security.Cryptography;

namespace CRIneta.Web.Core.Services
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
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IMemberRepository memberRepository;

        public AuthenticationService(IMemberRepository memberRepository, ICryptographer cryptographer, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.memberRepository = memberRepository;
            this.cryptographer = cryptographer;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        #region Implementation of IAuthenticationService

        public bool VerifyAccount(Member member, string password)
        {
            string passwordHash = cryptographer.Hash(password, member.PasswordSalt);
            return passwordHash == member.Password;
        }

        public bool SignIn(string username, string password)
        {
            using(unitOfWorkFactory.Create())
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