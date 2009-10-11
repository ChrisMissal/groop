using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Core.Services.Impl
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public MemberService(IMemberRepository memberRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.memberRepository = memberRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Member GetByUsername(string username)
        {
            using (unitOfWorkFactory.Create())
            {
                return memberRepository.GetByUsername(username);
            }
        }

        public void Add(Member member)
        {
            using (unitOfWorkFactory.Create())
            {
                memberRepository.Add(member);
            }
        }
    }
}