using System.Collections.Generic;
using CRIneta.DataAccess;
using CRIneta.DataAccess.Impl;
using CRIneta.Model.Domain;
using Microdesk.Utility.UnitTest;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class MeetingRepostoryTests : DatabaseUnitTestBase
    {
        private HybridSessionBuilder sessionBuilder;

        #region Setup

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            DatabaseFixtureSetUp();
            sessionBuilder = new HybridSessionBuilder();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            DatabaseFixtureTearDown();
        }

        [SetUp]
        public void Setup()
        {
            DatabaseSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseTearDown();
        }

        #endregion

        public void GetMyTestDataXmlFile()
        {
            SaveTestDatabase();
        }

        [Test]
        public void Can_get_meeting_by_Id()
        {
            var meetingRepository = new MeetingRepository(sessionBuilder);

            var meeting = meetingRepository.GetById(1);

            Assert.That(meeting.MeetingId, Is.EqualTo(1));
            Assert.That(meeting.Facility.Name, Is.EqualTo("Baymont Inn"));
        }

        [Test]
        public void Can_load_all_meetings()
        {
            var meetingRepository = new MeetingRepository(sessionBuilder);

            IList<Meeting> meetings = meetingRepository.GetAllMeetings();

            Assert.That(meetings.Count, Is.EqualTo(1));
        }
    }
}