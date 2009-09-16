using System;
using System.Collections.Generic;
using CRIneta.DataAccess;
using CRIneta.Web.Core.Domain;
using Microdesk.Utility.UnitTest;
using NHibernate;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class MemberRepostoryTests : DatabaseUnitTestBase
    {
        private HybridSessionBuilder sessionBuilder;

        #region Setup

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            DatabaseFixtureSetUp();
            sessionBuilder = new HybridSessionBuilder();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            DatabaseFixtureTearDown();
        }

        [SetUp]
        public void Setup()
        {
            DatabaseSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseTearDown();
        }

        #endregion

        [Test]
        public void GetById_returns_a_member()
        {
            // Arrange
            var memberRepository = new MemberRepository(sessionBuilder);

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
            var memberRepository = new MemberRepository(sessionBuilder);

            // Act
            var members = memberRepository.GetAllMembers();

            // Assert
            Assert.That(members.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddMember_can_successfully_save_a_Member()
        {
            // Arrange
            var memberRepository = new MemberRepository(sessionBuilder);

            
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
            var returnedMemberId = memberRepository.AddMember(member);

            // Assert
            Assert.That(member.MemberId, Is.GreaterThan(0));
            Assert.That(member.MemberId, Is.EqualTo(returnedMemberId));
            
        }
    }
}