using System.Web.Mvc;
using Groop.Core;
using Groop.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Website.Controllers
{
    [TestFixture]
    public class SponsorControllerTests
    {
        [Test]
        public void SponsorController_should_return_Index()
        {
            var fakeUserSession = MockRepository.GenerateStub<IUserSession>();
            var controller = new SponsorController(fakeUserSession);

            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }
    }
}