using System.Data;
using SubSonic;

namespace CRIneta.DataAccess.Migrations
{
    internal class Migration003_AddFacilities : Migration
    {
        private const string FACILITIES_TABLE_NAME = "Facilities";

        public override void Up()
        {
            TableSchema.Table sponsors = CreateTableWithKey(FACILITIES_TABLE_NAME, "Id");
            sponsors.AddColumn("Name", DbType.String, 255, false);
            sponsors.AddColumn("Address", DbType.String, 255, false);
            sponsors.AddColumn("City", DbType.String, 255, false);
            sponsors.AddColumn("Region", DbType.String, 255, false);
            sponsors.AddColumn("PostalCode", DbType.String, 255, false);
            sponsors.AddColumn("ImageUrl", DbType.String, 255, false, "''");
            sponsors.AddLongText("Description", false, "''");
        }

        public override void Down()
        {
            DropTable(FACILITIES_TABLE_NAME);
        }
    }
}