using System;

namespace CRIneta.Web.Core.Domain
{
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