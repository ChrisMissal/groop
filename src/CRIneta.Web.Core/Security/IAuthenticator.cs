using System.Security.Principal;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Security
{
    public interface IAuthenticator
    {
        void SignIn(Member member);
        void SignOut();
        IIdentity GetActiveIdentity();
        bool VerifyAccount(Member member, string password);
    }
}