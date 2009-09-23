using CRIneta.DataAccess;
using Microdesk.Utility.UnitTest;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class FacilityRepositoryTests : RepositoryTestBase
    {
        [Test]
        public void GetAllFacilities_should_return_three_results()
        { 
            // Arrange
            var facilityRepository = new FacilityRepository(activeSessionManager);

            // Act
            var facilities = facilityRepository.GetAll();

            // Assert
            Assert.That(facilities.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetFacility_returns_proper_facility()
        {
            // Arrange
            var facilityRepository = new FacilityRepository(activeSessionManager);

            // Act
            var facility = facilityRepository.GetById(1);

            // Assert
            Assert.That(facility.Name, Is.EqualTo("Baymont Inn"));
            Assert.That(facility.Description, Is.EqualTo("Baymont is a great location"));
        }
    }
}