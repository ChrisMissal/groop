using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate.Criterion;

namespace CRIneta.DataAccess
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