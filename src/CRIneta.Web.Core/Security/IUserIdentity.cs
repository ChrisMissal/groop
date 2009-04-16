using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Security
{
    public interface IUserIdentity : IIdentity
    {
        int MemberId { get; set; }
        string First { get; set; }
        string Last { get; set; }
        IList<string> Roles { get; }
        string Serialize();
    }

    public class UserIdentity : IUserIdentity
    {
        private List<string> roles;

        public UserIdentity()
        {
            roles = new List<string>();
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return MemberId > 0; }
        }

        public int MemberId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public IList<string> Roles
        {
            get { return roles; }
        }


        public UserIdentity From(Member member)
        {
            MemberId = member.MemberId;
            Name = member.Username;
            Email = member.Email;
            First = member.Name.First;
            Last = member.Name.Last;
            roles.AddRange(GetRoleNames(member.Roles));

            return this;
        }

        public string Serialize()
        {
            var rolesString = new StringBuilder();
            foreach (var role in roles)
            {
                rolesString.Append(role).Append(":");
            }

            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}", MemberId, Name, Email, First, Last, rolesString);
        }

        public UserIdentity Deserialize(string data)
        {
            var dataValues = data.Split("|".ToCharArray());

            MemberId = Convert.ToInt32(dataValues[0]);
            Name = dataValues[1];
            Email = dataValues[2];
            First = dataValues[3];
            Last = dataValues[4];

            var roles = dataValues[5].Split(":".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            this.roles.AddRange(roles);

            return this;
        }

        private IEnumerable<string> GetRoleNames(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                yield return role.Name;
            }
        }
    }
}