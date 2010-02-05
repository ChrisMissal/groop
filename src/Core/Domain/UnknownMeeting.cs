namespace Groop.Core.Domain
{
    public class UnknownMeeting : Meeting
    {
        public UnknownMeeting()
        {
            Facility = new UnknownFacility();
        }
    }
}