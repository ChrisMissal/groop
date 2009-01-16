using System.Data;
using SubSonic;

namespace CRIneta.DataAccess.Migrations
{
    class Migration004_AddMeetings : Migration
    {
        private const string MEETINGS_TABLE_NAME = "Meetings";
        private const string FACILITIES_TABLE_NAME = "Facilities";

        public override void Up()
        {
            TableSchema.Table meetings = CreateTableWithKey(MEETINGS_TABLE_NAME, "Id");
            meetings.AddColumn("Title", DbType.String, 255, false);
            meetings.AddColumn("StartsAt", DbType.DateTime, 0, false);
            meetings.AddColumn("EndsAt", DbType.DateTime, 0, false);
            meetings.AddColumn("ImageUrl", DbType.String, 255, false, "''");
            meetings.AddLongText("Description", false, "''");
            meetings.AddColumn("Presenter", DbType.String, 255, false);
            meetings.AddColumn("FacilityId", DbType.Int32, 0, true);

            //add a relationship between Meetings and Facilities
            TableSchema.Table facility = GetTable(FACILITIES_TABLE_NAME);
            CreateForeignKey(facility.GetColumn("Id"), meetings.GetColumn("FacilityId"));
        }

        public override void Down()
        {
            TableSchema.Table facility = GetTable(FACILITIES_TABLE_NAME);
            TableSchema.Table meetings = GetTable(MEETINGS_TABLE_NAME);

            DropForeignKey(facility.GetColumn("Id"), meetings.GetColumn("FacilityId"));
            DropTable(MEETINGS_TABLE_NAME);

        }
    }
}
