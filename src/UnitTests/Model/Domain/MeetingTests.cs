using CRIneta.Web.Core.Domain;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CRIneta.UnitTests.Model.Domain
{
    [TestFixture]
    public class MeetingTests
    {
        [Test]
        public void Meeting_has_zero_attendees_when_created()
        {
            var meeting = new Meeting();

            Assert.That(meeting.AttendeeCount, Is.EqualTo(0));
        }

        [Test]
        public void AddAttendee_increases_attendee_count()
        {
            var meeting = new Meeting();

            var stubAttendee = new Attendee("Tim", "Barcz");

            meeting.AddAttendee(stubAttendee);

            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
        }

        [Test]
        public void Meeting_does_not_allow_attendee_to_be_added_twice()
        {
            var meeting = new Meeting();

            var stubAttendee = new Attendee("Chris", "Missal");

            meeting.AddAttendee(stubAttendee);
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));

            meeting.AddAttendee(stubAttendee);
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
        }
    }
}
