using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1002,"Role")]
    public class Create_Role : Migration
    {
        public override void Up()
        {
            Create.Table("Role")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("RoleName").AsString(100).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Role");
        }
    }
}
