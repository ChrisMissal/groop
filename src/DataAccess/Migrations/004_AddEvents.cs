using System.Data;
using SubSonic;

namespace CRIneta.DataAccess.Migrations
{
    class Migration004_AddEvents : Migration
    {
        private const string EVENTS_TABLE_NAME = "Events";

        public override void Up()
        {
            TableSchema.Table events = CreateTableWithKey(EVENTS_TABLE_NAME, "Id");
            events.AddColumn("Title", DbType.String, 255, false);
            events.AddColumn("StartsAt", DbType.DateTime, 0, false);
            events.AddColumn("EndsAt", DbType.DateTime, 0, false);
            events.AddColumn("ImageUrl", DbType.String, 255, false, "''");
            events.AddLongText("Description", false, "''");
            events.AddColumn("FacilityId", DbType.Int32, 0, true);

            //add a relationship between Events and Facilities
            TableSchema.Table facility = GetTable("Facilities");
            CreateForeignKey(facility.GetColumn("Id"), events.GetColumn("FacilityId"));
        }

        public override void Down()
        {
            TableSchema.Table facility = GetTable("Facilities");
            TableSchema.Table events = GetTable("Events");

            DropForeignKey(facility.GetColumn("Id"), events.GetColumn("FacilityId"));
            DropTable(EVENTS_TABLE_NAME);
            
        }
    }
}
