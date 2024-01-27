namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestViewModelQuestions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            RenameColumn(table: "dbo.Grades", name: "SubjectId", newName: "Subject_SubjectId");
            AddColumn("dbo.Questions", "Points", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "GradeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TestViewModels", "GradeId", c => c.Int(nullable: false));
            AddColumn("dbo.TestViewModels", "Score", c => c.Single(nullable: false));
            AddColumn("dbo.TestViewModels", "TestId", c => c.Int());
            AlterColumn("dbo.Grades", "Subject_SubjectId", c => c.Int());
            CreateIndex("dbo.Grades", "TestId");
            CreateIndex("dbo.Grades", "Subject_SubjectId");
            CreateIndex("dbo.TestViewModels", "TestId");
            AddForeignKey("dbo.Grades", "TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestViewModels", "TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Grades", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
            DropColumn("dbo.Grades", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "StudentId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Grades", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TestViewModels", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Grades", "TestId", "dbo.Tests");
            DropIndex("dbo.TestViewModels", new[] { "TestId" });
            DropIndex("dbo.Grades", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Grades", new[] { "TestId" });
            AlterColumn("dbo.Grades", "Subject_SubjectId", c => c.Int(nullable: false));
            DropColumn("dbo.TestViewModels", "TestId");
            DropColumn("dbo.TestViewModels", "Score");
            DropColumn("dbo.TestViewModels", "GradeId");
            DropColumn("dbo.Grades", "GradeDate");
            DropColumn("dbo.Grades", "TestId");
            DropColumn("dbo.Questions", "Points");
            RenameColumn(table: "dbo.Grades", name: "Subject_SubjectId", newName: "SubjectId");
            CreateIndex("dbo.Grades", "StudentId");
            CreateIndex("dbo.Grades", "SubjectId");
            AddForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Students", "StudentId");
        }
    }
}
