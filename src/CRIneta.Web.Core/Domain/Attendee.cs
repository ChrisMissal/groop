namespace CRIneta.Web.Core.Domain
{
    public class Attendee
    {
        private readonly string email;

        public Attendee(string email)
        {
            this.email = email;
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