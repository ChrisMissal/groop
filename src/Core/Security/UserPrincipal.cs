using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;

namespace Groop.Core.Security
{
    public class UserPrincipal : IPrincipal
    {
        private readonly List<string> roles;
        private IIdentity identity;

        public UserPrincipal(IEnumerable<string> roles, IIdentity identity)
        {
            this.roles = new List<string>(roles);
            this.identity = identity;
        }

        public UserPrincipal() : this(new List<string>(), new UserIdentity())
        {
            
        }

        public bool IsInRole(string role)
        {
            return roles.Contains(role, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.
        /// </returns>
        public IIdentity Identity
        {
            get { return identity; }
        }

        public UserPrincipal With(IUserIdentity identity)
        {
            this.identity = identity;
            roles.AddRange(identity.Roles);
            return this;
        }
    }
}