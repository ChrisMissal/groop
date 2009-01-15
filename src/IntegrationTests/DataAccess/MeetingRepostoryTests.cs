using System;
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
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);

            // Act
            var meeting = meetingRepository.GetById(1);

            // Assert
            Assert.That(meeting.MeetingId, Is.EqualTo(1));
            Assert.That(meeting.Facility.Name, Is.EqualTo("Baymont Inn"));
        }

        [Test]
        public void Can_load_all_meetings()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);

            // Assert
            IList<Meeting> meetings = meetingRepository.GetAllMeetings();

            // Act
            Assert.That(meetings.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMeetingsBetween_returns_one_meeting()
        {
            // Arrange
            var meetingRepository = new MeetingRepository(sessionBuilder);
            var startDate = DateTime.Parse("1/1/2008");
            var endDate = DateTime.Parse("1/1/2009");

            // Act
            IList<Meeting> meetings = meetingRepository.GetMeetingsBetween(startDate, endDate);

            // Assert
            Assert.That(meetings.Count, Is.EqualTo(2));
        }
    }
}