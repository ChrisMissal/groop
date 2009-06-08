using CRIneta.Web.Core.Presentation;
using CRIneta.Web.Core.Validation;
using NUnit.Framework;


namespace CRIneta.UnitTests.Core.Presentation
{
    [TestFixture]
    public class ContactMessageDataTests
    {
        [Test]
        public void Ensure_that_a_ContactMessageData_by_default_is_not_valid()
        {
            // Arrange
            var data = new ContactMessageData();
            var validator = new PresentationValidator();

            // Act
            var valid = validator.IsValid(data);
            
            // Assert
            Assert.That(valid, Is.False);
        }

        [Test]
        public void Ensure_that_a_ContactMessageData_with_good_data_is_valid()
        {
            // Arrange
            var validator = new PresentationValidator();
            var data = new ContactMessageData
                       {
                           Email = "chris.missal@gmail.com",
                           Message = "I like your web site.",
                           Name = "Hamburger Magic",
                           Subject = "Hello"
                       };

            // Act
            var valid = validator.IsValid(data);

            // Assert
            Assert.That(valid, Is.True);
        }
    }
}