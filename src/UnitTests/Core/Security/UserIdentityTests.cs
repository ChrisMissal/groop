using Groop.Core.Domain;
using Groop.Core.Security;
using NUnit.Framework;

namespace Groop.UnitTests.Core.Security
{
    [TestFixture]
    public class UserIdentityTests
    {
        [Test]
        public void UserIdentity_Deserialize_should_return_nonAuthenticated_UserIdentity_for_bad_data()
        {
            // Arrange
            const string data = "Users";
            var identity = new UserIdentity();

            // Act
            var result = identity.Deserialize(data);

            // Assert
            Assert.That(result.IsAuthenticated, Is.False);
        }

        [Test]
        public void UserIdentity_Deserialize_should_return_nonAuthenticated_UserIdentity_for_null()
        {
            // Arrange
            const string data = null;
            var identity = new UserIdentity();

            // Act
            var result = identity.Deserialize(data);

            // Assert
            Assert.That(result.IsAuthenticated, Is.False);
        }

        [Test]
        public void From_should_add_role_based_on_UserType()
        {
            // Arrange
            var member = new Member { UserType = UserType.Member };

            // Act
            var identity = new UserIdentity().From(member);

            // Assert
            Assert.That(identity.Roles.Contains("Member"));
        }

        [Test]
        public void From_should_add_many_roles_based_on_UserType()
        {
            // Arrange
            var member = new Member { UserType = UserType.Administrator };

            // Act
            var identity = new UserIdentity().From(member);

            // Assert
            Assert.That(identity.Roles.Contains("Member"));
            Assert.That(identity.Roles.Contains("Administrator"));
        }
    }
}