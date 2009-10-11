using Microdesk.Utility.UnitTest;

namespace Groop.IntegrationTests.DataAccess
{
    public class DataHelper : DatabaseUnitTestBase
    {
        public void GetMyTestDataXmlFile()
        {
            SaveTestDatabase();
        }

        public void LoadDataFromXmlFile()
        {
            base.DatabaseFixtureSetUp();
            base.DatabaseSetUp();
        }
    }
}