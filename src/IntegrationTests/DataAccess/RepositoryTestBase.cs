using System;
using Groop.DataAccess;
using Microdesk.Utility.UnitTest;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    public class RepositoryTestBase : DatabaseUnitTestBase
    {
        protected IActiveSessionManager activeSessionManager;
        protected ISessionFactory sessionFactory;
        
        #region Setup

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            DatabaseFixtureSetUp();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            DatabaseFixtureTearDown();
        }

        [SetUp]
        public void Setup()
        {
            sessionFactory = new SessionFactory();
            activeSessionManager = new ActiveSessionManager();
            activeSessionManager.SetActiveSession(sessionFactory.Create());

            DatabaseSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseTearDown();
            activeSessionManager.ClearActiveSession();
        }

        #endregion
    }
}