using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1005,"Assignment")]
    public class Create_Assignment : Migration
    {
        public override void Up()
        {
            Create.Table("Assignment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("DueDate").AsDate().Nullable()
                .WithColumn("TeacherId").AsInt32().NotNullable()
                .WithColumn("CourseId").AsInt32().NotNullable();

            Create.ForeignKey("FK_Assignment_Teacher_Id").FromTable("Assignment").ForeignColumn("TeacherId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Assignment_Course_Id").FromTable("Assignment").ForeignColumn("CourseId").ToTable("Users").PrimaryColumn("Id");

        }
        public override void Down()
        {
            Delete.Table("Assignment");
        }
    }
}
