using System;
using System.Collections.Generic;

namespace CRIneta.Web.Core.Domain
{
    public class Meeting
    {
        private readonly IList<Attendee> attendees;

        public Meeting()
        {
            attendees = new List<Attendee>();
        }

        public virtual int AttendeeCount
        {
            get { return attendees.Count; }
        }

        public virtual int MeetingId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string Description { get; set; }
        public virtual Facility Facility { get; set; }

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
            foreach (Attendee a in attendees)
            {
                if (attendee == a)
                    return true;
            }

            return false;
        }
    }
}