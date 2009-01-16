using CRIneta.Web.Core;
using CRIneta.Web.Core.Domain;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CRIneta.UnitTests.Model
{
    [TestFixture]
    public class UserDataTests
    {
        [Test]
        public void Ensure_null_Member_passed_to_UserData_is_not_authenticated()
        {
            var userData = new UserData(null);
            Assert.That(userData.IsAuthenticated, Is.EqualTo(false));
        }

        [Test]
        public void Ensure_good_Member_passed_to_UserData_is_authenticated()
        {
            var member = new Member("cmissal", "Chris", "Missal", "chris.missal@gmail.com");

            var userData = new UserData(member);

            Assert.That(userData.IsAuthenticated, Is.EqualTo(true));
        }
    }
}
