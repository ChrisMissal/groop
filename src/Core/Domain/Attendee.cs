using System;

namespace Groop.Core.Domain
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
}