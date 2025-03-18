using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1006,"Submissions")]
    public class Create_Submissions : Migration
    {
        public override void Up()
        {
            Create.Table("Submissions")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("StudentId").AsInt32().NotNullable()
                .WithColumn("AssignmentId").AsInt32().NotNullable()
                .WithColumn("SubmittedOn").AsDateTime().NotNullable()
                .WithColumn("FilePath").AsString(500).Nullable()
                .WithColumn("Marks").AsString(200).Nullable();

            Create.ForeignKey("FK_Submissions_Student_Id").FromTable("Submissions").ForeignColumn("StudentId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Submissions_Assignment_Id").FromTable("Submissions").ForeignColumn("AssignmentId").ToTable("Assignment").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Submissions");
        }
    }
}
