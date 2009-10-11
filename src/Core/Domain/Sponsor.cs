using System.Collections.Generic;

namespace Groop.Core.Domain
{
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