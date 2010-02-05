using Groop.Core.Domain;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    public class MemberRepositoryTests : XmlRepositoryTesterBase
    {
        [Test]
        public void GetById_returns_null_if_Member_not_found()
        {
            var repository = GetRepository();

            var member = repository.GetById(9999);

            Assert.Null(member);
        }

        [Test]
        public void Add_will_insert_new_Member()
        {
            var repository = GetRepository();

            var member = GetMember();

            var id = repository.Add(member);

            Assert.That(id, Is.EqualTo(1));
        }

        [Test]
        public void GetById_can_retrieve_the_member_successfully()
        {
            var repository = GetRepository();

            var member = GetMember();

            var id = repository.Add(member);

            var savedMember = repository.GetById(id);

            Assert.That(savedMember.MemberId, Is.EqualTo(member.MemberId));
            Assert.That(savedMember.Email, Is.EqualTo(member.Email));
            Assert.That(savedMember.FirstName, Is.EqualTo(member.FirstName));
            Assert.That(savedMember.LastName, Is.EqualTo(member.LastName));
            Assert.That(savedMember.Username, Is.EqualTo(member.Username));
            Assert.That(savedMember.UserType, Is.EqualTo(member.UserType));
        }

        [Test]
        public void Update_can_modify_a_Member_successfully()
        {
            var repository = GetRepository();

            var member = GetMember();

            repository.Add(member);

            member.FirstName = "Chris";
            member.UserType = UserType.Administrator;

            repository.Update(member);

            Assert.That(member.UserType, Is.EqualTo(UserType.Administrator));
            Assert.That(member.FirstName, Is.EqualTo("Chris"));
        }

        [Test]
        public void GetByUsername_returns_the_correct_Member()
        {
            const string expectedFirstName = "Christopher";
            var member1 = new Member { FirstName = "Michael", Username = "mervin"};
            var member2 = new Member { FirstName = expectedFirstName, Username = "chris"};

            var repository = GetRepository();

            repository.Add(member1);
            repository.Add(member2);

            var searchedUser = repository.GetByUsername("chris");

            Assert.That(searchedUser.FirstName, Is.EqualTo(expectedFirstName));
        }

        [Test]
        public void GetByUsername_with_unknown_Username_should_return_null()
        {
            var member = GetRepository().GetByUsername("nobody");

            Assert.Null(member);
        }

        [Test]
        public void GetAll_should_return_an_expected_number_of_Members()
        {
            var repository = GetRepository();

            for (var i = 0; i < 17; i++)
                repository.Add(new Member());

            var members = repository.GetAll();

            Assert.That(members.Count, Is.EqualTo(17));
        }

        private static Member GetMember()
        {
            return new Member
                       {
                           Email = "bob@bob.bob",
                           FirstName = "Bob",
                           LastName = "Robertson",
                           Username = "bobby",
                           UserType = UserType.Member
                       };
        }

        private MemberRepository GetRepository()
        {
            return new MemberRepository(TestXmlRepository);
        }
    }
}