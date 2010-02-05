using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IXmlRepository xmlRepository;
        private IList<Member> allMembers;

        public MemberRepository(IXmlRepository xmlRepository)
        {
            this.xmlRepository = xmlRepository;
            this.xmlRepository.DataChangedEventHandler += (o, e) => allMembers = null;
        }

        protected IEnumerable<Member> AllMembers
        {
            get
            {
                if (allMembers == null)
                    allMembers = xmlRepository.GetAll<Member>();

                return allMembers;
            }
        }

        public Member GetById(int key)
        {
            return AllMembers.FirstOrDefault(x => x.MemberId == key);
        }

        public Member GetByUsername(string username)
        {
            return AllMembers.FirstOrDefault(x => x.Username == username);
        }

        public int Add(Member member)
        {
            xmlRepository.Add(member, (m, id) => m.MemberId = id);
            return member.MemberId;
        }

        public void Update(Member member)
        {
            xmlRepository.Update(member, member.MemberId);
        }

        public IList<Member> GetAll()
        {
            return AllMembers.ToList();
        }
    }
}