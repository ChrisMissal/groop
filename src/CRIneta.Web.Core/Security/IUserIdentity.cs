using System.Collections.Generic;
using System.Security.Principal;

namespace CRIneta.Web.Core.Security
{
    public interface IUserIdentity : IIdentity
    {
        int MemberId { get; set; }
        string First { get; set; }
        string Last { get; set; }
        IList<string> Roles { get; }
        string Serialize();
    }
}