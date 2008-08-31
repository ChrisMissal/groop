using NUnit.Framework;
using Rhino.Mocks;

namespace CRIneta.UnitTests
{
    [TestFixture]
    public abstract class MockingBase
    {
        protected MockRepository mockery;

        [SetUp]
        public virtual void Setup()
        {
            mockery = new MockRepository();
        }

        [TearDown]
        public virtual void Teardown()
        {
            mockery = null;
        }
    }
}