namespace Groop.Core.Domain
{
    public class MemberAttendee : Attendee
    {
        protected Member member;

        protected MemberAttendee()
        {
            
        }

        public MemberAttendee(Member member, Meeting meeting) : base(member.Email, meeting)
        {
            this.member = member;
        }

        public virtual Member Member
        {
            get { return member; }
        }
    }
}