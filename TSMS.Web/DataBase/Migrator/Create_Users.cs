using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1001,"Users")]
    public class Create_Users : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(100).NotNullable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Password").AsString(500).NotNullable()
                .WithColumn("ProfilePicture").AsString(500).Nullable()
                .WithColumn("MobileNo").AsString(10).NotNullable()
                .WithColumn("Address").AsString(500).Nullable()
                .WithColumn("DateOfBirth").AsDate().NotNullable()
                .WithColumn("Gender").AsInt16().NotNullable()
                .WithColumn("LastLogin").AsDateTime().Nullable()
                .WithColumn("LoginAttempts").AsInt16().Nullable()
                .WithColumn("AccountStatus").AsInt16().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
