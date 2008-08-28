using System.Collections.Generic;

namespace CRIneta.Model.Domain
{
    public class Meeting
    {
        private IList<Attendee> attendees;

        public Meeting()
        {
            attendees = new List<Attendee>();
        }

        public virtual int AttendeeCount
        {
            get { return attendees.Count; }
        }

        public virtual void AddAttendee(Attendee attendee)
        {
            if (AlreadyAttending(attendee))
            {
                return; // do nothing
            }

            attendees.Add(attendee);
        }

        /// <summary>
        /// Returns whether the attendee is already attending.
        /// </summary>
        /// <param name="attendee">The attendee.</param>
        /// <returns></returns>
        private bool AlreadyAttending(Attendee attendee)
        {
            foreach (var a in attendees)
            {
                if (attendee == a)
                    return true;
            }

            return false;
        }
    }
}