using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1009,"Notifications")]
    public class Create_Notifications : Migration
    {
        public override void Up()
        {
            Create.Table("Notifications")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("Message").AsString(500).NotNullable()
                .WithColumn("IsRead").AsBoolean().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable();

            Create.ForeignKey("FK_Notifications_User_Id").FromTable("Notifications").ForeignColumn("UserId").ToTable("Users").PrimaryColumn("Id");

        }
        public override void Down()
        {
            Delete.Table("Notifications");
        }
    }
}
