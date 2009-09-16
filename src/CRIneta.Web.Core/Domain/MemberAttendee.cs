namespace CRIneta.Web.Core.Domain
{
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
}