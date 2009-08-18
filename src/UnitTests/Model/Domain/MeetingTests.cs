using CRIneta.Web.Core.Domain;
using NUnit.Framework;

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

            var stubAttendee = new Attendee("TimBarcz@BarczMail.com");

            meeting.AddAttendee(stubAttendee);

            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
        }

        [Test]
        public void Meeting_does_not_allow_attendee_to_be_added_twice_with_same_object()
        {
            var meeting = new Meeting();

            var stubAttendee = new Attendee("Chris.Missal@AwesomeMail.com");

            meeting.AddAttendee(stubAttendee);
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));

            meeting.AddAttendee(stubAttendee);
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
        }

        [Test]
        public void Meeting_does_not_allow_attendee_to_be_added_twice_with_equal_objects()
        {
            var meeting = new Meeting();

            meeting.AddAttendee(new Attendee("Chris.Missal@AwesomeMail.com"));
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));

            meeting.AddAttendee(new Attendee("Chris.Missal@AwesomeMail.com"));
            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
        }
    }
}
