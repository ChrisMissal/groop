using CRIneta.Model.Domain;

namespace CRIneta.DataAccess
{
    public interface IMemberRepository : IRepository<Member, int>
    {
        Member GetByUsername(string username);
        //Member GetByEmail(string email);
        int AddMember(Member member);
        void RemoveMember(Member member);
        void UpdateMember(Member member);
    }
}