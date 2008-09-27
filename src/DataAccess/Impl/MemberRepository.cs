using System;
using CRIneta.Model.Domain;
using NHibernate;

namespace CRIneta.DataAccess.Impl
{
    public class MemberRepository : RepositoryBase, IMemberRepository
    {
        public MemberRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        public Member GetById(int key)
        {
            if (key <= 0)
                return null;

            using (var session = getSession())
            {
                return session.Get<Member>(key);
            }
        }

        public Member GetByUsername(string username)
        {
            using (ISession session = getSession())
            {
                return session.CreateQuery("from Member m where lower(m.Username) like :username")
                    .SetString("username", username.ToLower())
                    .SetMaxResults(1)
                    .UniqueResult<Member>();
            }
        }

        //public Member GetByEmail(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //        return null;

        //    using (ISession session = getSession())
        //    {
        //        IQuery query = session.CreateQuery("from Member m where lower(m.Email) like :email");
        //        query.SetString("email", email.ToLower());
        //        query.SetMaxResults(1);
        //        return query.UniqueResult<Member>();
        //    }
        //}

        /// <summary>
        /// Adds the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public int AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("Member must not be null.");

            object id;
            using (ISession session = getSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        id = session.Save(member);
                        tx.Commit();
                    }
                    catch (NHibernate.HibernateException)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            return Convert.ToInt32(id);
        }

        /// <summary>
        /// Removes the member.
        /// </summary>
        /// <param name="member">The member.</param>
        public void RemoveMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("Member must not be null.");

            using (ISession session = getSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(member);
                        session.Flush();
                        tx.Commit();
                    }
                    catch (NHibernate.HibernateException)
                    {
                        tx.Rollback();
                        throw;
                    }
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

            using (ISession session = getSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(member);
                        session.Flush();
                        tx.Commit();
                    }
                    catch (NHibernate.HibernateException)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}