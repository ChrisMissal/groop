using System;
using Groop.Core.Data;
using Groop.Core.Domain;
using Groop.Core.Services.Impl;
using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests.Core.Services
{
    [TestFixture]
    public class MemberServiceTests
    {
        private IMemberRepository memberRepository;

        [SetUp]
        public void SetUp()
        {
            memberRepository = MockRepository.GenerateMock<IMemberRepository>();
        }

        [Test]
        public void Add_should_call_Add_on_MemberRepository()
        {
            var member = new Member();
            var service = GetService();

            service.Add(member);

            memberRepository.AssertWasCalled(x => x.Add(member));
        }

        [Test]
        public void GetByUsername_should_call_GetByUsername_on_MemberRepository()
        {
            var username = "the-dude";
            var service = GetService();

            service.GetByUsername(username);

            memberRepository.AssertWasCalled(x => x.GetByUsername(username));
        }

        private MemberService GetService()
        {
            return new MemberService(memberRepository);
        }
    }
}