using System.IO;
using Groop.DataAccess;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;


namespace Groop.IntegrationTests.DataAccess
{
    [TestFixture]
    public class SchemaGeneration
    {
        protected HybridSessionBuilder sessionBuilder;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            sessionBuilder = new HybridSessionBuilder();
        }

        /// <summary>
        /// Creates the DDL file.
        /// </summary>
        /// <remarks>
        /// If you test with TestDriven.Net and get an error: "Common Language Runtime detected an invalid program", test
        /// with In-Proc instead.
        /// </remarks>
        /// <seealso cref="http://markmail.org/message/njtwa5huhdlfq3h7" />
        [Test]
        public void Create_Database()
        {
            Configuration config = sessionBuilder.GetConfiguration();

            var exporter = new SchemaExport(config);

            exporter.SetOutputFile(@"C:\temp\GroopSchema.ddl");
            exporter.Create(true, false);
        }

        /// <summary>
        /// Can_create_databases this instance.
        /// </summary>
        [Test]
        public void Can_create_database()
        {
            Configuration config = sessionBuilder.GetConfiguration();

            var exporter = new SchemaExport(config);

            var sw = new StringWriter();
            exporter.Execute(true, false, false, true, null, sw);

            string schema = sw.ToString();

            Assert.That(schema.Contains("create table Members"), Is.True);
        }
    }
}