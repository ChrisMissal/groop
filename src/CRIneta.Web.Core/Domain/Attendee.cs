namespace CRIneta.Model.Domain
{
    public class Attendee
    {
        private readonly string first;
        private readonly string last;

        public Attendee(string first, string last)
        {
            this.first = first;
            this.last = last;
        }
    }
}