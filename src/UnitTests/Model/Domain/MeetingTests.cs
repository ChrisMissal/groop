using System;
using System.Linq;
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

            var returnedAttendee = meeting.AddGuestAttendee("TimBarcz@BarczMail.com", "Tim", "Barcz");

            Assert.That(meeting.AttendeeCount, Is.EqualTo(1));
            Assert.That(meeting.Attendees.First(), Is.EqualTo(returnedAttendee));
        }

        [Test]
        public void AddAttendee_should_accept_a_user_to_be_added()
        {
            // Arrange
            var meeting = new Meeting();
            var member = new Member();

            // Act
            var attendee = meeting.AddAttendee(member) as MemberAttendee;

            // Assert
            Assert.That(attendee, Is.Not.Null);
            Assert.That(attendee.Meeting, Is.EqualTo(meeting));
            Assert.That(attendee.Member, Is.EqualTo(member));
        }

        [Test]
        [ExpectedException(typeof(DuplicateRegistrationException))]
        public void AddAttendee_should_not_allow_a_user_to_be_added_twice()
        { 
            // Arrange
            var meeting = new Meeting();
            var member = new Member();

            // Act
            meeting.AddAttendee(member);
            meeting.AddAttendee(member);

            // Assert
            // no assert here - the assert is the ExpectedException
        }

        [Test]
        public void AddAttendee_should_return_an_attendee_with_a_DateRegistered_close_to_current_time()
        {
            // Arrange
            var meeting = new Meeting();
            var member = new Member();
            var currentDate = DateTime.Now;

            // Act
            var attendee = meeting.AddAttendee(member);
            
            // Assert
            Assert.That(attendee.DateRegistered, Is.GreaterThanOrEqualTo(currentDate));
        }

        [Test]
        public void AddAttendee_should_accept_a_guest_registration()
        {
            // Arrange
            var stubMeeting = new Meeting();
            const string email = "email@email.com";
            const string firstname = "FirstName";
            const string lastname = "LastName";  

            // Act
            var attendee = stubMeeting.AddGuestAttendee(email, firstname, lastname) as GuestAttendee;

            // Assert
            Assert.That(attendee, Is.Not.Null);
            Assert.That(attendee.Meeting, Is.EqualTo(stubMeeting));
            Assert.That(attendee.Email, Is.EqualTo(email));
            Assert.That(attendee.FirstName, Is.EqualTo(firstname));
            Assert.That(attendee.LastName, Is.EqualTo(lastname));
        }

        [Test]
        [ExpectedException(typeof(DuplicateRegistrationException))]
        public void AddAttendee_should_throw_DuplicateRegistrationException_when_email_is_used_twice()
        {
            // Arrange
            var stubMeeting = new Meeting();
            const string email = "email@email.com";
            const string firstname = "FirstName";
            const string lastname = "LastName";

            // Act
            stubMeeting.AddGuestAttendee(email, firstname, lastname);
            stubMeeting.AddGuestAttendee(email, firstname, lastname);

            // Assert
            // no assert here - the assert is the ExpectedException
        }

        [Test]
        [ExpectedException(typeof(DuplicateRegistrationException))]
        public void AddAttendee_should_not_allow_a_guest_to_register_when_user_with_that_email_has_already_registered()
        { 
            // Arrange
            var stubMeeting = new Meeting();
            const string email = "email@email.com";
            const string firstname = "FirstName";
            const string lastname = "LastName";
            var stubMember = new Member() {Email = email};

            // Act
            stubMeeting.AddAttendee(stubMember); // first, add the member
            stubMeeting.AddGuestAttendee(email, firstname, lastname); // second, add the guest with the same email

            // Assert
            // no assert here - the assert is the ExpectedException
        }

        [Test]
        public void AddAttendee_should_promote_a_guest_registration_to_a_user_regisration_when_the_user_email_matches_a_guest_email()
        {
            // Arrange
            var stubMeeting = new Meeting();
            const string email = "email@email.com";
            const string firstname = "FirstName";
            const string lastname = "LastName";
            var stubMember = new Member() { Email = email };

            // Act
            var firstAttendee = stubMeeting.AddGuestAttendee(email, firstname, lastname); // first, add the guest
            var secondAttendee = stubMeeting.AddAttendee(stubMember); // second, add the member with the same email

            // Assert
            Assert.That(stubMeeting.AttendeeCount, Is.EqualTo(1));
            Assert.That(secondAttendee, Is.TypeOf(typeof(PromotedAttendee)));
        }

        [Test]
        public void AddAttendee_should_have_the_original_dateRegistered_when_promoted()
        {
            // Arrange
            var stubMeeting = new Meeting();
            const string email = "email@email.com";
            const string firstname = "FirstName";
            const string lastname = "LastName";
            var stubMember = new Member() { Email = email };

            // Act
            var firstAttendee = stubMeeting.AddGuestAttendee(email, firstname, lastname); // first, add the guest
            var secondAttendee = stubMeeting.AddAttendee(stubMember) as PromotedAttendee; // second, add the member with the same email

            // Assert
            Assert.That(secondAttendee.DateRegistered, Is.EqualTo(firstAttendee.DateRegistered));
        }

        [Test]
        public void Sponsors_should_be_empty_when_a_meeing_is_created()
        { 
            // Arrange
            
            // Act
            var meeting = new Meeting();

            // Assert
            Assert.That(meeting.Sponsors.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddSponsor_should_increment_the_sponsor_quantity()
        { 
            // Arrange
            var meeting = new Meeting();

            // Act
            meeting.AddSponsor(new Sponsor());

            // Assert
            Assert.That(meeting.Sponsors.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSponsor_should_return_a_MeetingSponsor_typed_Object()
        { 
            // Arrange
            var meeting = new Meeting();

            // Act
            var returnMeetingSponsor = meeting.AddSponsor(new Sponsor());

            // Assert
            Assert.That(returnMeetingSponsor, Is.TypeOf(typeof(MeetingSponsor)));
        }

        [Test]
        public void AddSponsor_should_allow_a_type_of_sponsor_to_be_added()
        {
            // Arrange
            var meeting = new Meeting();

            // Act
            var returnMeetingSponsor = meeting.AddSponsor(new Sponsor(), SponsorType.Food);

            // Assert
            Assert.That(returnMeetingSponsor, Is.TypeOf(typeof(MeetingSponsor)));
            Assert.That(returnMeetingSponsor.Type, Is.EqualTo(SponsorType.Food));
        }
    }
}
