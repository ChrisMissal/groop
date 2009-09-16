using System;
using NUnit.Framework;

namespace CRIneta.Web.Core.Domain
{
    public class Attendee
    {
        protected string email;
        protected Meeting meeting;
        protected int attendeeId;
        protected DateTime dateRegistered;

        protected Attendee()
        {
            // no args constructor used for NHibernate. So much for persistence ignorance!
        }

        protected Attendee(Meeting meeting)
        {
            this.meeting = meeting;
            dateRegistered = DateTime.Now;
        }

        public Attendee(string email, Meeting meeting) : this(meeting)
        {
            this.email = email;
        }

        public virtual string Email
        {
            get { return email; }
        }

        public virtual Meeting Meeting
        {
            get { return meeting; }
        }

        public virtual DateTime DateRegistered
        {
            get { return dateRegistered; }
            internal set { dateRegistered = value; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Attendee;
            if (other == default(Attendee))
                return false;

            return (email == other.email);
        }
    }

    public class MemberAttendee : Attendee
    {
        protected Member member;

        protected MemberAttendee()
        {
            
        }

        public MemberAttendee(Member member, Meeting meeting) : base(meeting)
        {
            this.member = member;
        }

        public virtual Member Member
        {
            get { return member; }
        }
    }

    public class GuestAttendee : Attendee
    {
        protected string firstName;
        protected string lastName;

        protected GuestAttendee()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestAttendee"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="meeting">The meeting.</param>
        public GuestAttendee(string email, string firstName, string lastName, Meeting meeting) : base(email, meeting)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public virtual string FirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public virtual string LastName
        {
            get { return lastName; }
        }
    }

    /// <summary>
    /// Represents a user who was a guest but has upgraded their account
    /// </summary>
    public class PromotedAttendee : MemberAttendee
    {
        protected DateTime datePromoted;

        protected PromotedAttendee()
        {
            
        }

        public PromotedAttendee(GuestAttendee previous, Member member, Meeting meeting) : base(member, meeting)
        {
            datePromoted = DateTime.Now;
            this.dateRegistered = previous.DateRegistered;
        }

        public virtual DateTime DatePromoted
        {
            get { return datePromoted; }
        }
    }
}