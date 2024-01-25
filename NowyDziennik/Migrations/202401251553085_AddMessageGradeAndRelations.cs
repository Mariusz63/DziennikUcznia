namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessageGradeAndRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        AnnouncementId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        FileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnnouncementId)
                .ForeignKey("dbo.FileTypes", t => t.FileTypeId, cascadeDelete: true)
                .Index(t => t.FileTypeId);
            
            CreateTable(
                "dbo.FileTypes",
                c => new
                    {
                        FileTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FileTypeId);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        StudentGradeId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentGradeId)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Value = c.Single(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        StudentSubjectId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentSubjectId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        TestName = c.String(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        SenderId = c.String(maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentGrades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Tests", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentGrades", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Announcements", "FileTypeId", "dbo.FileTypes");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.Tests", new[] { "TeacherId" });
            DropIndex("dbo.Tests", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjects", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjects", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "TeacherId" });
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            DropIndex("dbo.StudentGrades", new[] { "GradeId" });
            DropIndex("dbo.StudentGrades", new[] { "StudentId" });
            DropIndex("dbo.Announcements", new[] { "FileTypeId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Tests");
            DropTable("dbo.StudentSubjects");
            DropTable("dbo.Grades");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.FileTypes");
            DropTable("dbo.Announcements");
        }
    }
}
