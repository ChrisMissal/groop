using System.Linq;
using Groop.Core.Domain;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    public class SponsorRepositoryTests : XmlRepositoryTesterBase
    {
        [Test]
        public void GetById_returns_a_Sponsor()
        {
            var repository = GetRepository();

            var newSponsor = new Sponsor {Description = "I just added this."};
            repository.Add(newSponsor);

            var sponsor = repository.GetById(newSponsor.SponsorId);

            Assert.That(sponsor.Description, Is.EqualTo(newSponsor.Description));
        }

        [Test]
        public void GetById_returns_null_if_Sponsor_not_found()
        {
            var repository = GetRepository();

            var sponsor = repository.GetById(999);

            Assert.Null(sponsor);
        }

        [Test]
        public void Add_puts_the_sponsor_in_the_Repository()
        {
            var repository = GetRepository();

            var sponsor = new Sponsor {Description = "newly created", Name = "some company", Url = "http://example.com"};

            repository.Add(sponsor);

            var all = repository.GetAll();

            Assert.True(all.Any(s => s.Name == "some company"));
        }

        private SponsorRepository GetRepository()
        {
            return new SponsorRepository(TestXmlRepository);
        }
    }
}