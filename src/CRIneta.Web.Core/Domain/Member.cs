namespace CRIneta.Web.Core.Domain
{
    public class Member
    {
        private string email;
        private string first;
        private string last;
        private string username;

        protected Member()
        {
        }

        public Member(string username, string first, string last, string email)
        {
            this.username = username;
            this.first = first;
            this.last = last;
            this.email = email;
        }

        /// <summary>
        /// Gets the identifier for this user.
        /// </summary>
        /// <value>The id.</value>
        public virtual int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Gets the first.
        /// </summary>
        /// <value>The first.</value>
        public virtual string First
        {
            get { return first; }
            set { first = value; }
        }

        /// <summary>
        /// Gets the last.
        /// </summary>
        /// <value>The last.</value>
        public virtual string Last
        {
            get { return last; }
            set { last = value; }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>The password salt.</value>
        public virtual string PasswordSalt { get; set; }

        public virtual bool IsAdministrator { get; set; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            return string.Format("{0} {1}", First, Last);
        }
    }
}