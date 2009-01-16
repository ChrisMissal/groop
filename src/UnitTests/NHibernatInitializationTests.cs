using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace CRIneta.UnitTests
{

    [TestFixture]
    public class NHibernatInitializationTests
    {
        [Test]
        public void Can_compile_mappings()
        {
            Configuration config = new Configuration().Configure();

            ISessionFactory factory = config.BuildSessionFactory();

            factory.Close();
        }

        [Test]
        public void Can_read_configuration()
        {
            Configuration config = new Configuration().Configure();
        }
    }
}
