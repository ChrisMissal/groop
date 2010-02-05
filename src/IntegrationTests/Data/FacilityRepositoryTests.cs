using Groop.Core.Domain;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    public class FacilityRepositoryTests : XmlRepositoryTesterBase
    {
        [Test]
        public void GetById_should_return_null_for_Facility_that_doesnt_exist()
        {
            var repository = GetRepository();

            var facility = repository.GetById(9999);

            Assert.Null(facility);
        }

        [Test]
        public void Add_allows_a_Facility_to_be_saved_successfully()
        {
            var facility = GetFacility();

            var repository = GetRepository();

            var id = repository.Add(facility);

            var savedFacility = repository.GetById(id);

            Assert.That(savedFacility.Address.City, Is.SameAs(facility.Address.City));
            Assert.That(savedFacility.ImageUrl, Is.SameAs(facility.ImageUrl));
        }

        [Test]
        public void GetAll_should_return_an_expected_amount_of_Facilities()
        {
            var repository = GetRepository();

            for (var i = 0; i < 5; i++)
                repository.Add(new Facility {Name = "Facility #" + i});

            var allFacilities = repository.GetAll();

            Assert.That(allFacilities.Count, Is.EqualTo(5));
        }

        private static Facility GetFacility()
        {
            return new Facility
            {
                Address = new Address
                {
                    Street = "724 Evergreen Tr.",
                    City = "Springfield",
                    Region = "United States",
                    ZipCode = "01234"
                },
                Description = "The house from the animated television classic Simpson's",
                ImageUrl = "http://img.domain.com/simpsons.jpg",
                Name = "Simpson's House"
            };
        }

        private FacilityRepository GetRepository()
        {
            return new FacilityRepository(TestXmlRepository);
        }
    }
}