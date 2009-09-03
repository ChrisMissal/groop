namespace CRIneta.Website.Models
{
    public class RsvpData
    {
        private readonly bool hasRSVPd;
        private readonly int meetingId;

        public RsvpData(bool hasRsvPd, int meetingId)
        {
            hasRSVPd = hasRsvPd;
            this.meetingId = meetingId;
        }

        public int MeetingId
        {
            get { return meetingId; }
        }

        public bool HasRSVPd
        {
            get { return hasRSVPd; }
        }
    }
}