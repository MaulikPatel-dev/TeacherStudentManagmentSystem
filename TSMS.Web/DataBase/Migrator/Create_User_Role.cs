using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1003,"UserRole")]
    public class Create_User_Role : Migration
    {
        public override void Up()
        {
            Create.Table("Userrole")
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable();

            Create.ForeignKey("FK_User_Id").FromTable("Userrole").ForeignColumn("UserId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Role_Id").FromTable("Userrole").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Userrole");
        }
    }
}
