using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace CRIneta.DataAccess.Migrations
{
    public class Migration005_AddNews : Migration
    {
        private const string NEWS_TABLE_NAME = "News";
        private const string PEOPLE_TABLE_NAME = "People";

        public override void Up()
        {
            TableSchema.Table news = CreateTableWithKey(NEWS_TABLE_NAME, "Id");
            news.AddColumn("Title", DbType.String, 255, false);
            news.AddColumn("PostedAt", DbType.DateTime, 0, false);
            news.AddLongText("Content", false, "''");
            news.AddColumn("PersonId", DbType.Int32, 0, false);

            //add a relationship between Meetings and Facilities
            TableSchema.Table people = GetTable(PEOPLE_TABLE_NAME);
            CreateForeignKey(people.GetColumn("Id"), news.GetColumn("PersonId"));
        }

        public override void Down()
        {
            TableSchema.Table people = GetTable(PEOPLE_TABLE_NAME);
            TableSchema.Table news = GetTable(NEWS_TABLE_NAME);

            DropForeignKey(people.GetColumn("Id"), news.GetColumn("PersonId"));
            DropTable(NEWS_TABLE_NAME);
        }
    }
}
