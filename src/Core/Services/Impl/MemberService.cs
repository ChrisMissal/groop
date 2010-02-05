using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Core.Services.Impl
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public Member GetByUsername(string username)
        {
            return memberRepository.GetByUsername(username);
        }

        public void Add(Member member)
        {
            memberRepository.Add(member);
        }
    }
}