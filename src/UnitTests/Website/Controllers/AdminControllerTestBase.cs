using System;
using System.Web.Mvc;
using Groop.Core;
using Groop.Core.Data;
using Groop.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Website.Controllers
{
    [TestFixture]
    public class AdminControllerTestBase
    {
        protected IFacilityRepository facilityRepository;
        protected IMeetingRepository meetingRepository;
        protected IUserSession userSession;

        public AdminControllerTestBase()
        {
            facilityRepository = MockRepository.GenerateMock<IFacilityRepository>();
            meetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
            userSession = MockRepository.GenerateMock<IUserSession>();
        }

        public virtual AdminController GetController()
        {
            return new AdminController(userSession, meetingRepository, facilityRepository);
        }

        [Test]
        public void All_Actions_should_require_administrator_access()
        {
            var controller = GetController();
            var authorizeAttribute = controller.GetType().GetCustomAttributes(typeof (AuthorizeAttribute), true);

            Console.WriteLine(authorizeAttribute);

            Assert.That(((AuthorizeAttribute) authorizeAttribute[0]).Roles.Contains("Administrator"));
        }
    }
}