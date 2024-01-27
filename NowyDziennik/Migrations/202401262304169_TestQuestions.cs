namespace NowyDziennik.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                {
                    AnswerId = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    IsCorrect = c.Boolean(nullable: false),
                    QuestionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);

            CreateTable(
                "dbo.Questions",
                c => new
                {
                    QuestionId = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    TestId = c.Int(nullable: false),
                    TestViewModel_TestViewModelId = c.Int(),
                })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .ForeignKey("dbo.TestViewModels", t => t.TestViewModel_TestViewModelId)
                .Index(t => t.TestId)
                .Index(t => t.TestViewModel_TestViewModelId);

            CreateTable(
                "dbo.TestViewModels",
                c => new
                {
                    TestViewModelId = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    StartTime = c.DateTime(nullable: false),
                    EndTime = c.DateTime(nullable: false),
                    MaxPoints = c.Int(nullable: false),
                    SubjectId = c.Int(nullable: false),
                    TeacherId = c.String(),
                })
                .PrimaryKey(t => t.TestViewModelId);

            AddColumn("dbo.Tests", "Title", c => c.String());
            AddColumn("dbo.Tests", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "MaxPoints", c => c.Int(nullable: false));
            DropColumn("dbo.Tests", "TestName");
        }

        public override void Down()
        {
            AddColumn("dbo.Tests", "TestName", c => c.String());
            DropForeignKey("dbo.Questions", "TestViewModel_TestViewModelId", "dbo.TestViewModels");
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "TestViewModel_TestViewModelId" });
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropColumn("dbo.Tests", "MaxPoints");
            DropColumn("dbo.Tests", "EndTime");
            DropColumn("dbo.Tests", "StartTime");
            DropColumn("dbo.Tests", "Title");
            DropTable("dbo.TestViewModels");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
