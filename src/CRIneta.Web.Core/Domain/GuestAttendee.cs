namespace CRIneta.Web.Core.Domain
{
    public class GuestAttendee : Attendee
    {
        protected string firstName;
        protected string lastName;

        protected GuestAttendee()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestAttendee"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="meeting">The meeting.</param>
        public GuestAttendee(string email, string firstName, string lastName, Meeting meeting) : base(email, meeting)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public virtual string FirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public virtual string LastName
        {
            get { return lastName; }
        }
    }
}