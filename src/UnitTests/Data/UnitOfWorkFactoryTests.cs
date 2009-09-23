using CRIneta.DataAccess;
using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Data
{

    [TestFixture]
    public class UnitOfWorkFactoryTests
    {
        [Test]
        public void Create_should_return_a_non_null_instance()
        {
            // Arrange
            var mockSessionFactory = MockRepository.GenerateMock<ISessionFactory>();
            var mockActiveSessionManager = MockRepository.GenerateMock<IActiveSessionManager>();
            var factory = new UnitOfWorkFactory(mockSessionFactory, mockActiveSessionManager);

            // Act
            var unitOfWork = factory.Create();

            // Assert
            Assert.That(unitOfWork, Is.Not.Null);
            mockSessionFactory.AssertWasCalled(x=>x.Create());
        }
    }
}
