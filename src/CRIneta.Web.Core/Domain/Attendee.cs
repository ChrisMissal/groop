namespace CRIneta.Web.Core.Domain
{
public class Attendee
{
    protected readonly string email;
    protected readonly Meeting meeting;
    protected readonly int attendeeId;

    protected Attendee()
    {
        // no args constructor used for NHibernate. So much for persistence ignorance!
    }

    public Attendee(string email, Meeting meeting)
    {
        this.email = email;
        this.meeting = meeting;
    }

    public virtual string Email
    {
        get { return email; }
    }

    public virtual Meeting Meeting
    {
        get { return meeting; }
    }

    public override bool Equals(object obj)
    {
        var other = obj as Attendee;
        if(other == default(Attendee))
            return false;

        return (email == other.email);
    }
}
}