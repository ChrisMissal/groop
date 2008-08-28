using System.Data;
using SubSonic;

namespace CRIneta.DataAccess.Migrations
{
    internal class Migration002_AddPeople : Migration
    {
        private const string PEOPLE_TABLE_NAME = "People";

        public override void Up()
        {
            TableSchema.Table sponsors = CreateTableWithKey(PEOPLE_TABLE_NAME, "Id");
            sponsors.AddColumn("FirstName", DbType.String, 255, false);
            sponsors.AddColumn("LastName", DbType.String, 255, false);
            sponsors.AddColumn("ImageUrl", DbType.String, 255, false, "''");
            sponsors.AddLongText("Bio", false, "''");
            sponsors.AddColumn("City", DbType.String, 50, false, "''");
            sponsors.AddColumn("Region", DbType.String, 50, false, "''");
        }

        public override void Down()
        {
            DropTable(PEOPLE_TABLE_NAME);
        }
    }
}