using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;

namespace CRIneta.DataAccess.Migrations
{
    public class Migration007_AddRoles : Migration
    {
        private const string ROLES_TABLE_NAME = "Roles";

        public override void Up()
        {
            TableSchema.Table members = CreateTableWithKey(ROLES_TABLE_NAME, "RoleId");
            members.AddColumn("Name", DbType.String, 255, false);
        }

        public override void Down()
        {
            TableSchema.Table news = GetTable(ROLES_TABLE_NAME);

            DropTable(ROLES_TABLE_NAME);
        }
    }
}
