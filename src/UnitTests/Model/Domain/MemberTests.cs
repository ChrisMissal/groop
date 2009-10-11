using System;
using Groop.Core.Domain;
using NUnit.Framework;

namespace Groop.UnitTests.Model.Domain
{
    [TestFixture]
    public class MemberTests
    {
        [Test]
        public void MemberType_should_default_to_Member()
        { 
            // Arrange

            // Act
            var member = new Member();

            // Assert
            Assert.That(member.UserType, Is.EqualTo(UserType.Member));
            Assert.That(member.IsAdministrator, Is.False);
        }

        [Test]
        public void IsAdministrator_should_return_true_when_UserType_is_Administrator()
        {
            // Arrange
            var member = new Member();

            // Act
            member.UserType = UserType.Administrator;

            // Assert
            Assert.That(member.IsAdministrator, Is.True);
        }
    }
}