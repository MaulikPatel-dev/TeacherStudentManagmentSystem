using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1008,"Chats")]
    public class Create_Chats : Migration
    {
        public override void Up()
        {
            Create.Table("Chats")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("SenderId").AsString(200).NotNullable()
                .WithColumn("ReceiverId").AsString(200).NotNullable()
                .WithColumn("Message").AsString(200).NotNullable()
                .WithColumn("Timestamp").AsDateTime().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Chats");
        }
    }
}
