using System.Collections.Generic;
using Groop.Core.Domain;

namespace Groop.Core.Data
{
    public interface IMemberRepository : IRepository<Member, int>
    {
        Member GetByUsername(string username);
        //Member GetByEmail(string email);
        int Add(Member member);
        void Update(Member member);
        IList<Member> GetAll();
    }
}