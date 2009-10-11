using System;
using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;
using NHibernate.Criterion;

namespace Groop.DataAccess
{
    public class MemberRepository : RepositoryBaseUoW<Member, int>, IMemberRepository
    {
        public MemberRepository(IActiveSessionManager activeSessionManager) : base(activeSessionManager)
        {
        }

        #region IMemberRepository Members

        public Member GetByUsername(string username)
        {
            var criteria = DetachedCriteria.For<Member>()
                .Add(Restrictions.Eq("Username", username.ToLower()).IgnoreCase());

            return FindOne(criteria);
        }

        protected override Func<Member, int> GetKey
        {
            get { return member => member.MemberId; }
        }

        public IList<Member> GetAll()
        {
            var criteria = DetachedCriteria.For<Member>();
            return new List<Member>(FindAll(criteria));
        }

        #endregion
    }
}