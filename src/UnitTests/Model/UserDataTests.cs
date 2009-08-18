using CRIneta.Web.Core;
using CRIneta.Web.Core.Domain;
using NUnit.Framework;


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
            var member = new Member
                             {
                                 Username = "cmissal",
                                 Email = "chris.missal@gmail.com",
                                 FirstName = "Chris", 
                                 LastName = "Missal"
                             };

            var userData = new UserData(member);

            Assert.That(userData.IsAuthenticated, Is.EqualTo(true));
        }
    }
}
