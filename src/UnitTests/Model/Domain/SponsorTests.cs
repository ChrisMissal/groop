using CRIneta.Web.Core.Domain;
using NUnit.Framework;

namespace CRIneta.UnitTests.Model.Domain
{

    [TestFixture]
    public class SponsorTests
    {
        [Test]
        public void Sponsor_should_have_zero_meetings_when_created()
        {
            // Arrange
            
            // Act
            var sponsor = new Sponsor();

            // Assert
            Assert.That(sponsor.SponsoredMeetings.Count, Is.EqualTo(0));
        }
    }
}
