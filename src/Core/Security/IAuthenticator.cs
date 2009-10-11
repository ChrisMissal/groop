using System.Security.Principal;
using Groop.Core.Domain;

namespace Groop.Core.Security
{
    public interface IAuthenticator
    {
        void SignIn(Member member);
        void SignOut();
        IIdentity GetActiveIdentity();
        bool VerifyAccount(Member member, string password);
    }
}