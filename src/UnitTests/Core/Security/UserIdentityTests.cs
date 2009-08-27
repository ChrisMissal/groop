using CRIneta.Web.Core.Security;
using NUnit.Framework;

namespace CRIneta.UnitTests.Core.Security
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
    }
}