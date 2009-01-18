using Castle.Windsor;
using NUnit.Framework;

namespace CRIneta.UnitTests
{

    [TestFixture]
    public class WindsorTests
    {
        [Test]
        public void Can_initiate_Windsor()
        {
            IWindsorContainer container = new WindsorContainer("windsor.config.xml");
            foreach (var handler in container.Kernel.GetAssignableHandlers(typeof(object)))
            {
                container.Resolve(handler.ComponentModel.Service);
            }
        }
    }
}
