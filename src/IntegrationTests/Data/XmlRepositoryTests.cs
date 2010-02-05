using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    public class XmlRepositoryTests
    {
        private readonly ISerializationProvider serializationProvider = new SerializationProvider();

        [Test]
        public void Ctor_will_create_file_if_it_doesnt_exist()
        {
            const string file = "\\temp.xml";
            new XmlRepository(file, serializationProvider);
            new FileInfo(file).Delete();
        }

        [Test]
        public void Get_GetAll_and_Update_should_throw_for_unknown_Type()
        {
            const string file = "\\somefile.xml";

            var repository = new XmlRepository(file, serializationProvider);

            Assert.Throws<InvalidOperationException>(() => repository.Get<MeetingRepository>(0));
            Assert.Throws<InvalidOperationException>(() => repository.GetAll<MeetingRepository>());
            Assert.Throws<InvalidOperationException>(() => repository.Update("", 0));

            new FileInfo(file).Delete();
        }

        [Test]
        public void Ctor_should_create_the_parent_nodes_based_on_Serializers()
        {
            const string file = "\\dummyfile.xml";

            new XmlRepository(file, serializationProvider);

            var document = XDocument.Load(file);

            if (document.Root != null)
            {
                Assert.That(document.Root.Elements().Count(), Is.EqualTo(serializationProvider.XmlSerializers.Count()));

                foreach (var serializer in serializationProvider.XmlSerializers)
                {
                    Assert.That(document.Root.Elements(XmlRepository.ParentName(serializer.Type)).Count(), Is.EqualTo(1));
                }
            }
            else
            {
                Assert.Fail("Xml file not created successfully.");
            }

            new FileInfo(file).Delete();
        }
    }
}