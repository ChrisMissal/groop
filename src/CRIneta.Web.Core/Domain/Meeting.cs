using System;
using System.Collections.Generic;
using System.Linq;

namespace CRIneta.Web.Core.Domain
{
    public class Meeting
    {
        private readonly IList<Attendee> attendees;

        public Meeting()
        {
            attendees = new List<Attendee>();
        }

        public virtual int AttendeeCount
        {
            get { return attendees.Count(); }
        }

        public virtual IEnumerable<Attendee> Attendees
        {
            get { return attendees; }
        }

        public virtual int MeetingId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string Description { get; set; }
        public virtual string Presenter { get; set; }
        public virtual Facility Facility { get; set; }

        public virtual GuestAttendee AddGuestAttendee(string email, string firstname, string lastname)
        {
            if (attendees
                .Any(attendee => attendee.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new DuplicateRegistrationException();
            }

            var guestAttendee = new GuestAttendee(email, firstname, lastname, this);
            attendees.Add(guestAttendee);

            return guestAttendee;
        }

        public virtual MemberAttendee AddAttendee(Member member)
        {
            if (attendees
                .OfType<MemberAttendee>()
                .Cast<MemberAttendee>()
                .Any(attendee => attendee.Member == member))
            {
                throw new DuplicateRegistrationException();
            }

            if (attendees
                .OfType<GuestAttendee>()
                .Any(attendee => attendee.Email.Equals(member.Email, StringComparison.OrdinalIgnoreCase)))
            {
                var previousRegistrationAsGuest = attendees.OfType<GuestAttendee>().First(attendee => attendee.Email.Equals(member.Email, StringComparison.OrdinalIgnoreCase));

                var indexOfRegistration = attendees.IndexOf(previousRegistrationAsGuest);

                attendees.Remove(previousRegistrationAsGuest);

                var promotedAttendee = new PromotedAttendee(previousRegistrationAsGuest, member, this);
                attendees.Insert(indexOfRegistration, promotedAttendee);
                return promotedAttendee;
            }

            var memberAttendee = new MemberAttendee(member, this);
            attendees.Add(memberAttendee);
            return memberAttendee;
        }

        public virtual bool ContainsAttendee(string email)
        {
            return attendees.Any(x => x.Email == email);
        }
    }
}