namespace DziennikUczniaKoniec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        LessonNumber = c.String(),
                        IsJustified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ParentId = c.String(maxLength: 128),
                        ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Parent", t => t.ParentId)
                .Index(t => t.Id)
                .Index(t => t.ParentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MessageRecipient",
                c => new
                    {
                        MessageId = c.Int(nullable: false),
                        RecipientId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MessageId, t.RecipientId })
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SendTime = c.DateTime(nullable: false),
                        Content = c.String(),
                        SenderId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.Attachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MessageId = c.Int(),
                        FileType = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.MessageId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisorId = c.String(maxLength: 128),
                        Year = c.Int(nullable: false),
                        Unit = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.SupervisorId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.QuizSharing",
                c => new
                    {
                        ClassId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                        GradeWeight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassId, t.QuizId })
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(),
                        AuthorId = c.String(maxLength: 128),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        ModificationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Teacher", t => t.AuthorId)
                .Index(t => t.SubjectId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ModificationTime = c.DateTime(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                        FileType = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Syllabus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        Comment = c.String(),
                        ModificationTime = c.DateTime(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        TeacherId = c.String(maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.TeacherClassSubject",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.ClassId, t.SubjectId })
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ClosedQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.ClosedQuestionOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClosedQuestionId = c.Int(),
                        Content = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClosedQuestion", t => t.ClosedQuestionId)
                .Index(t => t.ClosedQuestionId);
            
            CreateTable(
                "dbo.ClosedQuestionAnswer",
                c => new
                    {
                        QuizAttemptId = c.Int(nullable: false),
                        SelectedOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizAttemptId, t.SelectedOptionId })
                .ForeignKey("dbo.QuizAttempt", t => t.QuizAttemptId, cascadeDelete: true)
                .ForeignKey("dbo.ClosedQuestionOption", t => t.SelectedOptionId, cascadeDelete: true)
                .Index(t => t.QuizAttemptId)
                .Index(t => t.SelectedOptionId);
            
            CreateTable(
                "dbo.QuizAttempt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(),
                        DoerId = c.String(maxLength: 128),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.DoerId)
                .ForeignKey("dbo.Quiz", t => t.QuizId)
                .Index(t => t.QuizId)
                .Index(t => t.DoerId);
            
            CreateTable(
                "dbo.OpenQuestionAnswer",
                c => new
                    {
                        QuizAttemptId = c.Int(nullable: false),
                        OpenQuestionId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.QuizAttemptId, t.OpenQuestionId })
                .ForeignKey("dbo.OpenQuestion", t => t.OpenQuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuizAttempt", t => t.QuizAttemptId, cascadeDelete: true)
                .Index(t => t.QuizAttemptId)
                .Index(t => t.OpenQuestionId);
            
            CreateTable(
                "dbo.OpenQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxPoints = c.Int(nullable: false),
                        MaxAnswerLength = c.Int(nullable: false),
                        QuizId = c.Int(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GlobalAnnouncement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        ModificationTime = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrator", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Administrator", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GlobalAnnouncement", "AuthorId", "dbo.Administrator");
            DropForeignKey("dbo.Absence", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "ParentId", "dbo.Parent");
            DropForeignKey("dbo.Parent", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Class", "SupervisorId", "dbo.Teacher");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.QuizSharing", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.ClosedQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.ClosedQuestionOption", "ClosedQuestionId", "dbo.ClosedQuestion");
            DropForeignKey("dbo.ClosedQuestionAnswer", "SelectedOptionId", "dbo.ClosedQuestionOption");
            DropForeignKey("dbo.QuizAttempt", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.OpenQuestionAnswer", "QuizAttemptId", "dbo.QuizAttempt");
            DropForeignKey("dbo.OpenQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.OpenQuestionAnswer", "OpenQuestionId", "dbo.OpenQuestion");
            DropForeignKey("dbo.QuizAttempt", "DoerId", "dbo.Student");
            DropForeignKey("dbo.ClosedQuestionAnswer", "QuizAttemptId", "dbo.QuizAttempt");
            DropForeignKey("dbo.Quiz", "AuthorId", "dbo.Teacher");
            DropForeignKey("dbo.File", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherClassSubject", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherClassSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.TeacherClassSubject", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Quiz", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Grade", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "StudentId", "dbo.Student");
            DropForeignKey("dbo.File", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Teacher", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuizSharing", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Student", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRecipient", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRecipient", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attachment", "MessageId", "dbo.Message");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GlobalAnnouncement", new[] { "AuthorId" });
            DropIndex("dbo.Administrator", new[] { "Id" });
            DropIndex("dbo.Parent", new[] { "Id" });
            DropIndex("dbo.OpenQuestion", new[] { "QuizId" });
            DropIndex("dbo.OpenQuestionAnswer", new[] { "OpenQuestionId" });
            DropIndex("dbo.OpenQuestionAnswer", new[] { "QuizAttemptId" });
            DropIndex("dbo.QuizAttempt", new[] { "DoerId" });
            DropIndex("dbo.QuizAttempt", new[] { "QuizId" });
            DropIndex("dbo.ClosedQuestionAnswer", new[] { "SelectedOptionId" });
            DropIndex("dbo.ClosedQuestionAnswer", new[] { "QuizAttemptId" });
            DropIndex("dbo.ClosedQuestionOption", new[] { "ClosedQuestionId" });
            DropIndex("dbo.ClosedQuestion", new[] { "QuizId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "SubjectId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "ClassId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "TeacherId" });
            DropIndex("dbo.Grade", new[] { "SubjectId" });
            DropIndex("dbo.Grade", new[] { "TeacherId" });
            DropIndex("dbo.Grade", new[] { "StudentId" });
            DropIndex("dbo.File", new[] { "SubjectId" });
            DropIndex("dbo.File", new[] { "TeacherId" });
            DropIndex("dbo.Teacher", new[] { "Id" });
            DropIndex("dbo.Quiz", new[] { "AuthorId" });
            DropIndex("dbo.Quiz", new[] { "SubjectId" });
            DropIndex("dbo.QuizSharing", new[] { "QuizId" });
            DropIndex("dbo.QuizSharing", new[] { "ClassId" });
            DropIndex("dbo.Class", new[] { "SupervisorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Attachment", new[] { "MessageId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.MessageRecipient", new[] { "RecipientId" });
            DropIndex("dbo.MessageRecipient", new[] { "MessageId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "ParentId" });
            DropIndex("dbo.Student", new[] { "Id" });
            DropIndex("dbo.Absence", new[] { "StudentId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.GlobalAnnouncement");
            DropTable("dbo.Administrator");
            DropTable("dbo.Parent");
            DropTable("dbo.OpenQuestion");
            DropTable("dbo.OpenQuestionAnswer");
            DropTable("dbo.QuizAttempt");
            DropTable("dbo.ClosedQuestionAnswer");
            DropTable("dbo.ClosedQuestionOption");
            DropTable("dbo.ClosedQuestion");
            DropTable("dbo.TeacherClassSubject");
            DropTable("dbo.Grade");
            DropTable("dbo.Subject");
            DropTable("dbo.File");
            DropTable("dbo.Teacher");
            DropTable("dbo.Quiz");
            DropTable("dbo.QuizSharing");
            DropTable("dbo.Class");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Attachment");
            DropTable("dbo.Message");
            DropTable("dbo.MessageRecipient");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Student");
            DropTable("dbo.Absence");
        }
    }
}
