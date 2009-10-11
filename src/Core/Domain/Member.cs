using System;
using System.Collections.Generic;

namespace Groop.Core.Domain
{
    public class Member
    {
        private UserType userType = UserType.Member;
        private IList<Meeting> attendedMeetings;

        public Member()
        {
            attendedMeetings = new List<Meeting>();
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
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is administrator.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is administrator; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsAdministrator
        {
            get { return UserType == UserType.Administrator; }
        }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public virtual UserType UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public virtual IList<Meeting> AttendedMeetings
        {
            get { return attendedMeetings; }
        }
    }
}