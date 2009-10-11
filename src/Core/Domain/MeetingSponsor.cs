namespace Groop.Core.Domain
{
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
}