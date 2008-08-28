using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace CRIneta.DataAccess.Migrations
{
    public class Migration001_AddSponsors : Migration
    {
        private const string SPONSORS_TABLE_NAME = "Sponsors";

        public override void Up()
        {
            TableSchema.Table sponsors = CreateTableWithKey(SPONSORS_TABLE_NAME, "Id");
            sponsors.AddColumn("Name", DbType.String, 255, false, "");
            sponsors.AddColumn("ImageUrl", DbType.String, 255, false, "");
            sponsors.AddLongText("Description", false, "");
        }

        public override void Down()
        {
            DropTable(SPONSORS_TABLE_NAME);
        }
    }
}
