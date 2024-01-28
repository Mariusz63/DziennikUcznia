namespace NowyDziennik.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTestGradeStudentSubjectRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "TestViewModel_TestViewModelId", "dbo.TestViewModels");
            DropForeignKey("dbo.TestViewModels", "TestId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestViewModel_TestViewModelId" });
            DropIndex("dbo.TestViewModels", new[] { "TestId" });
            DropColumn("dbo.Questions", "TestViewModel_TestViewModelId");
            DropTable("dbo.TestViewModels");
        }

        public override void Down()
        {
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
                    GradeId = c.Int(nullable: false),
                    Score = c.Single(nullable: false),
                    TestId = c.Int(),
                })
                .PrimaryKey(t => t.TestViewModelId);

            AddColumn("dbo.Questions", "TestViewModel_TestViewModelId", c => c.Int());
            CreateIndex("dbo.TestViewModels", "TestId");
            CreateIndex("dbo.Questions", "TestViewModel_TestViewModelId");
            AddForeignKey("dbo.TestViewModels", "TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Questions", "TestViewModel_TestViewModelId", "dbo.TestViewModels", "TestViewModelId");
        }
    }
}
