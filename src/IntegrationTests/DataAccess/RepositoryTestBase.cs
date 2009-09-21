using System;
using CRIneta.DataAccess;
using Microdesk.Utility.UnitTest;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    public class RepositoryTestBase : DatabaseUnitTestBase
    {
        protected HybridSessionBuilder sessionBuilder;

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
    }
}