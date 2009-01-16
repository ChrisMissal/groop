using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Data;
using CRIneta.Web.Core.Domain;
using CRIneta.Web.Core.Security.Cryptography;

namespace CRIneta.Website.Impl.Data
{
    public class FakeMemberRepository : RepositoryBase, IMemberRepository
    {
        private readonly ICryptographer cryptographer;
        private Dictionary<string, Member> db;

        public FakeMemberRepository(ISessionBuilder sessionFactory, ICryptographer cryptographer) : base(sessionFactory)
        {
            this.cryptographer = cryptographer;
            InitializeAndFillDB();
        }

        #region IMemberRepository Members

        public Member GetById(int key)
        {
            if (key <= 0)
                throw new ArgumentException("id must be a positive integer");

            throw new NotImplementedException();
        }

        public Member GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            if (!db.ContainsKey(username))
                return null;

            return db[username];


            Member member = (from entry in db
                             where ((entry.Value as Member).Username == username)
                             select entry.Value).First();

            return member;
        } 

        //public Member GetByEmail(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //        return null;

        //    if (!db.ContainsKey(email))
        //        return null;

        //    return db[email];
        //}

        #endregion

        private void InitializeAndFillDB()
        {
            db = new Dictionary<string, Member>();

            string salt = cryptographer.CreateSalt();

            db.Add("timbarcz",
                   new Member("timbarcz", "Tim", "Barcz", "timbarcz@gmail.com") {PasswordSalt = salt, Password = cryptographer.Hash("password", salt)});
            db.Add("chrismissal",
                   new Member("cmissal", "Chris", "Missal", "chris.missal@gmail.com") {PasswordSalt = salt, Password = cryptographer.Hash("password", salt)});
            db.Add("chrissutton",
                   new Member("bdsutton", "Chris", "Sutton", "bdsutton@gmail.com") {PasswordSalt = salt, Password = cryptographer.Hash("password", salt)});
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public int AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("User must not be null.");

            db.Add(member.Email, member);

            return db.Count;
        }

        /// <summary>
        /// Removes the user from the Repository.
        /// </summary>
        /// <param name="user">The user.</param>
        public void RemoveMember(Member user)
        {
            if (user == null)
                throw new ArgumentException("User must not be null.");

            db.Remove(user.Email);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="member">The member.</param>
        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentException("User must not be null.");

            db[member.Email] = member;
        }
    }
}