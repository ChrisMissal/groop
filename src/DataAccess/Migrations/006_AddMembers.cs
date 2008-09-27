using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace CRIneta.DataAccess.Migrations
{
    public class Migration006_AddMembers : Migration
    {
        private const string MEMBERS_TABLE_NAME = "Members";

        public override void Up()
        {
            TableSchema.Table members = CreateTableWithKey(MEMBERS_TABLE_NAME, "MemberId");
            members.AddColumn("Username", DbType.String, 50, false);
            members.AddColumn("Password", DbType.String, 255, false);
            members.AddColumn("PasswordSalt", DbType.String, 255, false);
            members.AddColumn("First", DbType.String, 50, false);
            members.AddColumn("Last", DbType.String, 50, false);
            members.AddColumn("EmailAddress", DbType.String, 100, false);
            members.AddColumn("DateCreated", DbType.DateTime, 0, false, "GetDate()");
            members.AddColumn("DateUpdated", DbType.DateTime, 0, false, "GetDate()");
        }

        public override void Down()
        {
            TableSchema.Table news = GetTable(MEMBERS_TABLE_NAME);

            DropTable(MEMBERS_TABLE_NAME);
        }
    }
}
