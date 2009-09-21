using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using NHibernate;

namespace CRIneta.DataAccess
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        public Member GetByUsername(string username)
        {
            using(var session = getSession())
            using(var txn = session.BeginTransaction())
            {
                try
                {
                    var member = session.CreateQuery("from Member m where lower(m.Username) like :username")
                            .SetString("username", username.ToLower())
                            .UniqueResult<Member>();
                    txn.Commit();
                    return member;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Adds the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public int AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("Member must not be null.");

            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    session.Save(member);
                    txn.Commit();
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }

            return Convert.ToInt32(member.MemberId);
        }

        /// <summary>
        /// Removes the member.
        /// </summary>
        /// <param name="member">The member.</param>
        public void RemoveMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("Member must not be null.");

            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    session.Delete(member);
                    txn.Commit();
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the member.
        /// </summary>
        /// <param name="member">The member.</param>
        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("Member must not be null.");

            using (var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    session.Update(member);
                    txn.Commit();
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }

        public IList<Member> GetAllMembers()
        {
            using(var session = getSession())
            using (var txn = session.BeginTransaction())
            {
                try
                {
                    var members = session.CreateQuery("from Member").List<Member>();
                    txn.Commit();
                    return members;
                }
                catch (HibernateException)
                {
                    txn.Rollback();
                    throw;
                }
            }
        }
    }
}