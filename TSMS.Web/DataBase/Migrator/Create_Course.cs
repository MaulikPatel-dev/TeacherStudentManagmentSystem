using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1004, "Course")]
    public class Create_Course : Migration
    {
        public override void Up()
        {
            Create.Table("Course").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Description").AsString(250).Nullable()
                .WithColumn("TeacherId").AsInt32().NotNullable();

            Create.ForeignKey("FK_Teacher_Id").FromTable("Course").ForeignColumn("TeacherId").ToTable("Users").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Course");
        }
    }
}
