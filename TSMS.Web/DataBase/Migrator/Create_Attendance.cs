using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1007,"Attendance")]
    public class Create_Attendance : Migration
    {
        public override void Up()
        {
            Create.Table("Attendance")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("StudentId").AsInt32().NotNullable()
                .WithColumn("Date").AsDate().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable()
                .WithColumn("CourseId").AsInt32().NotNullable();

            Create.ForeignKey("FK_Attendance_Student_Id").FromTable("Attendance").ForeignColumn("StudentId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Attendance_Course_Id").FromTable("Attendance").ForeignColumn("CourseId").ToTable("Course").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Attendance");
        }
    }
}
