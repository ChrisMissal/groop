using System;
using System.IO;
using System.Text.RegularExpressions;
using Microdesk.Utility.UnitTest;

namespace CRIneta.IntegrationTests.TestData
{
    public class TestDataCreator : DatabaseUnitTestBase
    {
        /// <summary>
        /// Helps build the test data xml file
        /// </summary>
        public void GetMyTestDataXmlFile()
        {
            SaveTestDatabase();
        }

        /// <summary>
        /// Will take data from testdata.xml and put it back into the database.
        /// </summary>
        public void InsertTestData()
        {
            base.DatabaseFixtureSetUp();
            base.DatabaseSetUp();
        }

        public void DeleteTableAdapters()
        {
            var d = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent; // current dir, then go up two levels
            var path = Path.Combine(d.FullName, @"testdata\database.xsd");
            var text = File.ReadAllText(path);
            File.WriteAllText(path, Regex.Replace(text, "<TableAdapter.*?>.*?</TableAdapter>", "", RegexOptions.Singleline));
        }
    }
}