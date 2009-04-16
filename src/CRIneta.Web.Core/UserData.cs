using System;
using System.Collections.Generic;
using System.Linq;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core
{
    public class UserData
    {
        private readonly bool isAuthenticated;
        private readonly Member member;

        public UserData(Member member)
        {
            isAuthenticated = false;
            if (member == null) return;

            isAuthenticated = true;
            this.member = member;
        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public string Username
        {
            get { return member.Username; }
        }

        public string Name
        {
            get { return member.GetName(); }
        }

        public bool IsInRole(Func<Role, bool> func)
        {
            return member.Roles.Any(func);
        }
    }
}