using Groop.Core;
using Groop.Core.Presentation;
using Groop.Core.Services;
using Groop.Core.Validation;
using Groop.Website.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Website.Controllers
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