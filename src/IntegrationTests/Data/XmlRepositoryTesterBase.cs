using System;
using System.Xml.Linq;
using Groop.Core;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    [TestFixture]
    public class XmlRepositoryTesterBase
    {
        private static readonly IXmlRepository instance = new XmlRepository("groop-data.xml", new SerializationProvider(), new TempPathResolver());

        [SetUp]
        public void SetFixture()
        {
            const string fileLocation = @"C:\temp\groop-data.xml";
            var document = XDocument.Load(fileLocation);
            document.Root.Element(XName.Get("Members")).RemoveNodes();
            document.Root.Element(XName.Get("Meetings")).RemoveNodes();
            document.Root.Element(XName.Get("Sponsors")).RemoveNodes();
            document.Root.Element(XName.Get("Facilities")).RemoveNodes();
            document.Save(fileLocation);
        }

        protected IXmlRepository TestXmlRepository
        {
            get { return instance; }
        }
    }

    internal class TempPathResolver : IPathResolver
    {
        public string Resolve(string path)
        {
            return "C:\\temp\\" + path;
        }
    }
}