using NUnit.Framework;
using Rhino.Mocks;

namespace Groop.UnitTests
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