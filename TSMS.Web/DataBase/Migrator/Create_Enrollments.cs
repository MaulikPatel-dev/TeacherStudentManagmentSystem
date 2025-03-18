using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1010,"Enrollments")]
    public class Create_Enrollments : Migration
    {
        public override void Up()
        {
            Create.Table("Enrollments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("StudentId").AsInt32().NotNullable()
                .WithColumn("CourseId").AsInt32().NotNullable()
                .WithColumn("EnrolledOn").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable();

            Create.ForeignKey("FK_Enrollments_Student_Id").FromTable("Enrollments").ForeignColumn("StudentId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Enrollments_Course_Id").FromTable("Enrollments").ForeignColumn("CourseId").ToTable("Course").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Enrollments");
        }
    }
}
