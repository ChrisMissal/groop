using System.Linq;
using Groop.Core.Domain;
using Groop.DataAccess;
using IntegrationTests.DataAccess;
using NUnit.Framework;

namespace Groop.IntegrationTests.DataAccess
{
    [TestFixture]
    public class SponsorRepositoryTests : RepositoryTestBase
    {
        [Test]
        public void AddSponsor_saves_sponsor_to_database()
        {
            // Arrange
            var repository = new SponsorRepository(activeSessionManager);
            var sponsor = new Sponsor() {Name = "Sample Sponsor"};

            // Act
            int returnedId = repository.Add(sponsor);

            // Assert
            Assert.That(returnedId, Is.EqualTo(sponsor.SponsorId));
        }

        [Test]
        public void GetAll_returns_all_sponsors()
        {
            // Arrange
            var repository = new SponsorRepository(activeSessionManager);

            // Act
            var sponsors = repository.GetAll();

            // Assert
            Assert.That(sponsors.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetById_returns_a_sponsor()
        {
            // Arrange
            var repository = new SponsorRepository(activeSessionManager);
    
            // Act
            var sponsor = repository.GetById(3);

            // Assert
            Assert.That(sponsor.Name, Is.EqualTo("TekSystems"));
            Assert.That(sponsor.Url, Is.EqualTo("http://teksystems.com"));
            Assert.That(sponsor.Description, Is.EqualTo("TekSystem is your one stop staffing shop."));
        }
    }
}