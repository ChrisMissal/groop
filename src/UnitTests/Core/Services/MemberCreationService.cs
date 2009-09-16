using System;
using CRIneta.Web.Core.Domain;
using NUnit.Framework;

namespace CRIneta.UnitTests.Core.Services
{
    [TestFixture]
    public class MemberCreationServiceTests
    {
        [Test]
        public void CreateMember_should_return_non_null_member()
        { 
            // Arrange
            var factory = new MemberCreationService();

            // Act
            Member member = factory.CreateNewMember("email@email.com", "JoeUser", "Joe", "User");

            // Assert
            Assert.That(member, Is.Not.Null);
        }
    }

    public class MemberCreationService
    {
        public Member CreateNewMember(string email, string username, string firstName, string lastName)
        {
            var member = new Member
                       {
                           Email = email,
                           Username = username,
                           FirstName = firstName,
                           LastName = lastName
                       };

            return member;
        }
    }
}