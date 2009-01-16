using System.Security.Principal;
using CRIneta.Model.Domain;

namespace CRIneta.Model.Security
{
    public interface IAuthenticator
    {
        void SignIn(Member member);
        void SignOut();
        IIdentity GetActiveIdentity();
        bool VerifyAccount(Member member, string password);
    }
}