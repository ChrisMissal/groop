using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace CRIneta.Web.Core.Domain
{
    public class Member
    {
        public Member()
        {
            Name = new Name();
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual Name Name { get; set; }

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
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual ISet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is administrator.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is administrator; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsAdministrator { get; set; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            return Name.ToString();
        }
    }
}