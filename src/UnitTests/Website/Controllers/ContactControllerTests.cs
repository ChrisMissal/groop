using CRIneta.Web.Core;
using CRIneta.Web.Core.Presentation;
using CRIneta.Web.Core.Services;
using CRIneta.Web.Core.Validation;
using CRIneta.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Website.Controllers
{
    [TestFixture]
    public class ContactControllerTests
    {
        private IValidator mockValidator;
        private IUserSession mockUserSession;
        private IEmailService mockEmailService;

        [Test]
        public void Ensure_that_EmailService_calls_Send_if_ContactMessageData_is_valid()
        {
            // Arrange
            var controller = GetController();
            var contactMessageData = MockRepository.GenerateMock<ContactMessageData>();
            mockValidator.Stub(v => v.IsValid(contactMessageData)).Return(true);

            // Act
            controller.Index(contactMessageData);

            // Assert
            mockEmailService.AssertWasCalled(s => s.Send(null), s => s.IgnoreArguments());
        }

        private ContactController GetController()
        {
            mockValidator = MockRepository.GenerateMock<IValidator>();
            mockEmailService = MockRepository.GenerateMock<IEmailService>();
            mockUserSession = MockRepository.GenerateMock<IUserSession>();

            return new ContactController(mockUserSession, mockEmailService, mockValidator);
        }
    }
}