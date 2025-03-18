using FluentMigrator;

namespace TSMS.Web.DataBase.Migrator
{
    [Migration(1011,"Feedback")]
    public class Create_Feedback : Migration
    {
        public override void Up()
        {
            Create.Table("Feedback")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("CourseId").AsInt32().NotNullable()
                .WithColumn("Rating").AsInt32().NotNullable()
                .WithColumn("Review").AsString(500).Nullable()
                .WithColumn("SubmittedOn").AsDateTime().NotNullable();

            Create.ForeignKey("FK_Feedback_User_Id").FromTable("Feedback").ForeignColumn("UserId").ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey("FK_Feedback_Course_Id").FromTable("Feedback").ForeignColumn("CourseId").ToTable("Course").PrimaryColumn("Id");

        }
        public override void Down()
        {
            Delete.Table("Feedback");
        }
    }
}
