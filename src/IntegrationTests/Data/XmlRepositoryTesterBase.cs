using System;
using System.Xml.Linq;
using Groop.Data;
using NUnit.Framework;

namespace Groop.IntegrationTests.Data
{
    [TestFixture]
    public class XmlRepositoryTesterBase
    {
        private const string FILE_LOCATION = @"C:\temp\groop-data.xml";

        protected IXmlRepository TestXmlRepository
        {
            get
            {
                var document = XDocument.Load(FILE_LOCATION);
                document.Root.Element(XName.Get("Members")).RemoveNodes();
                document.Root.Element(XName.Get("Meetings")).RemoveNodes();
                document.Root.Element(XName.Get("Sponsors")).RemoveNodes();
                document.Root.Element(XName.Get("Facilities")).RemoveNodes();
                document.Save(FILE_LOCATION);
                
                return new XmlRepository(FILE_LOCATION, new SerializationProvider());
            }
        }
    }
}