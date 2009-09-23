using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Domain;
using Microdesk.Utility.UnitTest;
using NHibernate;
using NUnit.Framework;
using ISessionFactory = CRIneta.DataAccess.ISessionFactory;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class MemberRepostoryTests : RepositoryTestBase
    {
        [Test]
        public void GetById_returns_a_member()
        {
            // Arrange
            var memberRepository = new MemberRepository(activeSessionManager);

            // Act
            var member = memberRepository.GetById(1);

            // Assert
            Assert.That(member.MemberId, Is.EqualTo(1));
            Assert.That(member.FirstName, Is.EqualTo("Tim"));
            Assert.That(member.LastName, Is.EqualTo("Barcz"));
        }

        [Test]
        public void GetAllMembers_returns_two_members()
        {
            // Arrange
            var memberRepository = new MemberRepository(activeSessionManager);

            // Act
            var members = memberRepository.GetAll();

            // Assert
            Assert.That(members.Count(), Is.EqualTo(2));
        }

        [Test]
        public void AddMember_can_successfully_save_a_Member()
        {
            // Arrange
            var memberRepository = new MemberRepository(activeSessionManager);

            
            var member = new Member()
                             {
                                 Email = "email@domain.com",
                                 FirstName = "Tim",
                                 LastName = "Barcz",
                                 Username = "timbarcz1",
                                 Password = "somepassword",
                                 PasswordSalt = "sodium chloride"
                             };
            // Act
            var returnedMemberId = memberRepository.Add(member);

            // Assert
            Assert.That(member.MemberId, Is.GreaterThan(0));
            Assert.That(member.MemberId, Is.EqualTo(returnedMemberId));   
        }

        [Test]
        public void GetByUsername_returns_the_user_with_that_username_ignoring_case()
        {
            // Arrange
            var memberRepository = new MemberRepository(activeSessionManager);
            const string username = "timbarcz";

            // Act
            var member = memberRepository.GetByUsername(username);

            // Assert
            Assert.That(member.MemberId, Is.EqualTo(1));
            Assert.That(member.Username, Is.EqualTo("TimBarcz"));
        }

        [Test]
        public void Update_should_persist_changes_to_the_database()
        {
            // Arrange
            var memberRepository = new MemberRepository(activeSessionManager);
            var member = memberRepository.GetById(1);

            // Act
            member.Username = "newUsername";
            memberRepository.Update(member);
            member = memberRepository.GetById(1);

            // Assert
            Assert.That(member.Username, Is.EqualTo("newUsername"));
        }

    }
}