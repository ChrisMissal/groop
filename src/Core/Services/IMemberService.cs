using System;
using System.Collections.Generic;
using Groop.Core.Domain;

namespace Groop.Core.Services
{
    public interface IMemberService
    {
        Member GetByUsername(string username);
        void Add(Member member);
    }
}