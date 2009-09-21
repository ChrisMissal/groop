using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CRIneta.Web.Core.Domain
{
    public class Meeting
    {
        private readonly IList<Attendee> attendees;
        private readonly IList<MeetingSponsor> sponsors;

        public Meeting()
        {
            attendees = new List<Attendee>();
            sponsors = new List<MeetingSponsor>();
        }

        public virtual int MeetingId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string Description { get; set; }
        public virtual string Presenter { get; set; }
        public virtual Facility Facility { get; set; }

        public virtual IList<Attendee> Attendees
        {
            get { return attendees; }
        }

        public virtual int AttendeeCount
        {
            get { return attendees.Count(); }
        }

        public virtual IList<MeetingSponsor> Sponsors
        {
            get { return sponsors; }
        }

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

        public virtual MeetingSponsor AddSponsor(Sponsor sponsor)
        {
            return AddSponsor(sponsor, SponsorType.General);
        }

        public virtual MeetingSponsor AddSponsor(Sponsor sponsor, SponsorType type)
        {
            var meetingSponsor = new MeetingSponsor(sponsor, this);

            meetingSponsor.Type = type;

            sponsors.Add(meetingSponsor);
            return meetingSponsor;
        }
    }

    public class MeetingSponsor
    {
        protected int meetingSponsorId;
        private Sponsor sponsor;
        private Meeting meeting;

        protected MeetingSponsor()
        {
            // For NH
        }

        public MeetingSponsor(Sponsor sponsor, Meeting meeting)
        {
            this.sponsor = sponsor;
            this.meeting = meeting;
        }

        public virtual Meeting Meeting { get { return meeting; } }
        public virtual Sponsor Sponsor { get { return sponsor; } }
        public virtual SponsorType Type { get; set; }
    }

    /// <summary>
    /// Represents an entity which helps covering costs
    /// </summary>
    public class Sponsor
    {
        private IList<MeetingSponsor> sponsoredMeetings;

        public Sponsor()
        {
            sponsoredMeetings = new List<MeetingSponsor>();
        }
        public virtual int SponsorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<MeetingSponsor> SponsoredMeetings
        {
            get { return sponsoredMeetings; }
        }
    }
}