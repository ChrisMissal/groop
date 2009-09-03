using System;
using System.Collections.Generic;
using System.Linq;

namespace CRIneta.Web.Core.Domain
{
public class Meeting
{
    private readonly List<Attendee> attendees;

    public Meeting()
    {
        attendees = new List<Attendee>();
    }

    public virtual int AttendeeCount
    {
        get { return attendees.Count(); }
    }

    protected virtual IEnumerable<Attendee> Attendees
    {
        get { return attendees; }
    }

    public virtual int MeetingId { get; set; }
    public virtual string Title { get; set; }
    public virtual DateTime StartTime { get; set; }
    public virtual DateTime EndTime { get; set; }
    public virtual string Description { get; set; }
    public virtual string Presenter { get; set; }
    public virtual Facility Facility { get; set; }

    public virtual void AddAttendee(Attendee attendee)
    {
        if (!AlreadyAttending(attendee))
            attendees.Add(attendee);
    }

    /// <summary>
    /// Returns whether the attendee is already attending.
    /// </summary>
    /// <param name="attendee">The attendee.</param>
    /// <returns></returns>
    private bool AlreadyAttending(Attendee attendee)
    {
        return attendees.Contains(attendee);
    }

    public virtual bool ContainsAttendee(string email)
    {
        return attendees.Any(x => x.Email == email);
    }
}
}