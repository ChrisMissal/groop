using System;
using System.Collections.Generic;
using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Services
{
    public interface IMemberService
    {
        Member GetByUsername(string username);
        void Add(Member member);
    }
}