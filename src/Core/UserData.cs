using System;
using System.Collections.Generic;
using System.Linq;
using Groop.Core.Domain;

namespace Groop.Core
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

        public bool IsInRole(Func<Role, bool> func)
        {
            // TODO: This needs to be fixed (Tim Barcz)
            return true;
            //return member.Roles.Any(func);
        }
    }
}