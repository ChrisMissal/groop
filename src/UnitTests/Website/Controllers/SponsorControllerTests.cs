using System.Web.Mvc;
using CRIneta.Web.Core;
using CRIneta.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Website.Controllers
{
    [TestFixture]
    public class SponsorControllerTests
    {
        [Test]
        public void SponsorController_should_return_Index()
        {
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new SponsorController(fakeUserSession);

            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void SponsorController_should_return_List()
        {
            var fakeUserSession = MockRepository.GenerateMock<IUserSession>();
            var controller = new SponsorController(fakeUserSession);

            var result = controller.List() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("List"));
        }
    }
}