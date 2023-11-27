namespace DziennikUczniaV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                        Teacher_TeacherId = c.Int(),
                        HomeroomTeacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId)
                .ForeignKey("dbo.Teachers", t => t.HomeroomTeacher_TeacherId)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.HomeroomTeacher_TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        Class_ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.ApplicationUsers", t => t.TeacherId)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId)
                .Index(t => t.TeacherId)
                .Index(t => t.Class_ClassId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        MobileNo = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Subject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        TestQuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.TestQuestionId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.TestAnswers",
                c => new
                    {
                        TestAnswerId = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Question_TestQuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.TestAnswerId)
                .ForeignKey("dbo.TestQuestions", t => t.Question_TestQuestionId)
                .Index(t => t.Question_TestQuestionId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Parent_ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.ApplicationUsers", t => t.StudentId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Parents", t => t.Parent_ParentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => t.Parent_ParentId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        AddedBy = c.String(),
                        message = c.String(),
                        MessageGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ParentId);
            
            CreateTable(
                "dbo.SubjectClasses",
                c => new
                    {
                        Subject_SubjectId = c.Int(nullable: false),
                        Class_ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectId, t.Class_ClassId })
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Class_ClassId);
            
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                    {
                        Subject_SubjectId = c.Int(nullable: false),
                        Teacher_TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectId, t.Teacher_TeacherId })
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId, cascadeDelete: true)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Teacher_TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Parent_ParentId", "dbo.Parents");
            DropForeignKey("dbo.Teachers", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Students", "StudentId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Classes", "HomeroomTeacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Tests", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TestQuestions", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.TestAnswers", "Question_TestQuestionId", "dbo.TestQuestions");
            DropForeignKey("dbo.SubjectTeachers", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeachers", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectClasses", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.SubjectClasses", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Classes", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "TeacherId", "dbo.ApplicationUsers");
            DropIndex("dbo.SubjectTeachers", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.SubjectTeachers", new[] { "Subject_SubjectId" });
            DropIndex("dbo.SubjectClasses", new[] { "Class_ClassId" });
            DropIndex("dbo.SubjectClasses", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Students", new[] { "Parent_ParentId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropIndex("dbo.TestAnswers", new[] { "Question_TestQuestionId" });
            DropIndex("dbo.TestQuestions", new[] { "Test_TestId" });
            DropIndex("dbo.Tests", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Teachers", new[] { "Class_ClassId" });
            DropIndex("dbo.Teachers", new[] { "TeacherId" });
            DropIndex("dbo.Classes", new[] { "HomeroomTeacher_TeacherId" });
            DropIndex("dbo.Classes", new[] { "Teacher_TeacherId" });
            DropTable("dbo.SubjectTeachers");
            DropTable("dbo.SubjectClasses");
            DropTable("dbo.Parents");
            DropTable("dbo.Messages");
            DropTable("dbo.Groups");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.TestAnswers");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.Tests");
            DropTable("dbo.Subjects");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Classes");
        }
    }
}
