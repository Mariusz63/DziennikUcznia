namespace DziennikUczniaKoniec.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(),
                    SecondName = c.String(),
                    Role = c.String(),
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
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
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
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
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
                    MessageId = c.Int(nullable: false, identity: true),
                    SendTime = c.DateTime(nullable: false),
                    Content = c.String(),
                    SenderId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);

            CreateTable(
                "dbo.Attachment",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    MessageId = c.Int(),
                    FileTypeId = c.Int(),
                    Data = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileType", t => t.FileTypeId)
                .ForeignKey("dbo.Message", t => t.MessageId)
                .Index(t => t.MessageId)
                .Index(t => t.FileTypeId);

            CreateTable(
                "dbo.FileType",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

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
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Class",
                c => new
                {
                    ClassId = c.Int(nullable: false, identity: true),
                    ClassName = c.String(),
                })
                .PrimaryKey(t => t.ClassId);

            CreateTable(
                "dbo.ClassMembership",
                c => new
                {
                    ClassMembershipId = c.Int(nullable: false, identity: true),
                    UserId = c.String(maxLength: 128),
                    ClassId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ClassMembershipId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ClassId);

            CreateTable(
                "dbo.Subject",
                c => new
                {
                    SubjectId = c.Int(nullable: false, identity: true),
                    SubjectName = c.String(),
                    SubjectDescription = c.String(),
                    Class_ClassId = c.Int(),
                })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Class", t => t.Class_ClassId)
                .Index(t => t.Class_ClassId);

            CreateTable(
                "dbo.Grade",
                c => new
                {
                    GradeId = c.Int(nullable: false, identity: true),
                    Value = c.Single(nullable: false),
                    Weight = c.Single(nullable: false),
                    Date = c.DateTime(nullable: false),
                    Comment = c.String(),
                    StudentId = c.String(maxLength: 128),
                    TeacherId = c.String(maxLength: 128),
                    SubjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    StudentId = c.String(nullable: false, maxLength: 128),
                    ParentId = c.String(maxLength: 128),
                    ClassId = c.Int(),
                })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Parent", t => t.ParentId)
                .Index(t => t.StudentId)
                .Index(t => t.ParentId)
                .Index(t => t.ClassId);

            CreateTable(
                "dbo.Parent",
                c => new
                {
                    ParentId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.AspNetUsers", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.StudentPrent",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StudentID = c.Int(nullable: false),
                    ParentID = c.Int(nullable: false),
                    Parent_ParentId = c.String(maxLength: 128),
                    Student_StudentId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parent", t => t.Parent_ParentId)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .Index(t => t.Parent_ParentId)
                .Index(t => t.Student_StudentId);

            CreateTable(
                "dbo.TestAttempt",
                c => new
                {
                    TestAttemptId = c.Int(nullable: false, identity: true),
                    TestId = c.Int(),
                    StudentId = c.String(maxLength: 128),
                    Start = c.DateTime(nullable: false),
                    Finish = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.TestAttemptId)
                .ForeignKey("dbo.Test", t => t.TestId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.TestId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.ClosedQuestionAnswer",
                c => new
                {
                    TestAttemptId = c.Int(nullable: false),
                    SelectedOptionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.TestAttemptId, t.SelectedOptionId })
                .ForeignKey("dbo.ClosedQuestionOption", t => t.SelectedOptionId, cascadeDelete: true)
                .ForeignKey("dbo.TestAttempt", t => t.TestAttemptId, cascadeDelete: true)
                .Index(t => t.TestAttemptId)
                .Index(t => t.SelectedOptionId);

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
                "dbo.ClosedQuestion",
                c => new
                {
                    QuestionId = c.Int(nullable: false, identity: true),
                    TestId = c.Int(),
                    Content = c.String(),
                })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Test", t => t.TestId)
                .Index(t => t.TestId);

            CreateTable(
                "dbo.Test",
                c => new
                {
                    TestId = c.Int(nullable: false, identity: true),
                    SubjectId = c.Int(),
                    AuthorId = c.String(maxLength: 128),
                    Name = c.String(nullable: false),
                    Duration = c.Int(nullable: false),
                    ModificationTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Teacher", t => t.AuthorId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Teacher",
                c => new
                {
                    TeacherId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherId)
                .Index(t => t.TeacherId);

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
                "dbo.OpenQuestion",
                c => new
                {
                    QuestionId = c.Int(nullable: false, identity: true),
                    MaxPoints = c.Int(nullable: false),
                    MaxAnswerLength = c.Int(nullable: false),
                    TestId = c.Int(),
                    Content = c.String(),
                })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Test", t => t.TestId)
                .Index(t => t.TestId);

            CreateTable(
                "dbo.OpenTestAnswer",
                c => new
                {
                    TestAttemptId = c.Int(nullable: false),
                    OpenQuestionId = c.Int(nullable: false),
                    Content = c.String(),
                })
                .PrimaryKey(t => new { t.TestAttemptId, t.OpenQuestionId })
                .ForeignKey("dbo.OpenQuestion", t => t.OpenQuestionId, cascadeDelete: true)
                .ForeignKey("dbo.TestAttempt", t => t.TestAttemptId, cascadeDelete: true)
                .Index(t => t.TestAttemptId)
                .Index(t => t.OpenQuestionId);

            CreateTable(
                "dbo.TestSharing",
                c => new
                {
                    ClassId = c.Int(nullable: false),
                    TestId = c.Int(nullable: false),
                    GradeWeight = c.Single(nullable: false),
                })
                .PrimaryKey(t => new { t.ClassId, t.TestId })
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.TestId);

            CreateTable(
                "dbo.TeacherSubjectAssignment",
                c => new
                {
                    TeacherSubjectAssignmentId = c.Int(nullable: false, identity: true),
                    TeacherId = c.String(maxLength: 128),
                    SubjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TeacherSubjectAssignmentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(nullable: false),
                    PhoneNumber = c.String(nullable: false),
                    Password = c.String(nullable: false, maxLength: 100),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(),
                    RoleName = c.String(),
                    ConfirmPassword = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Subject", "Class_ClassId", "dbo.Class");
            DropForeignKey("dbo.TeacherSubjectAssignment", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherSubjectAssignment", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Grade", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "StudentId", "dbo.Student");
            DropForeignKey("dbo.TestAttempt", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ClosedQuestionAnswer", "TestAttemptId", "dbo.TestAttempt");
            DropForeignKey("dbo.TestSharing", "TestId", "dbo.Test");
            DropForeignKey("dbo.TestSharing", "ClassId", "dbo.Class");
            DropForeignKey("dbo.TestAttempt", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.OpenQuestion", "TestId", "dbo.Test");
            DropForeignKey("dbo.OpenTestAnswer", "TestAttemptId", "dbo.TestAttempt");
            DropForeignKey("dbo.OpenTestAnswer", "OpenQuestionId", "dbo.OpenQuestion");
            DropForeignKey("dbo.ClosedQuestion", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "AuthorId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherClassSubject", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherClassSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.TeacherClassSubject", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Teacher", "TeacherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClosedQuestionOption", "ClosedQuestionId", "dbo.ClosedQuestion");
            DropForeignKey("dbo.ClosedQuestionAnswer", "SelectedOptionId", "dbo.ClosedQuestionOption");
            DropForeignKey("dbo.Student", "ParentId", "dbo.Parent");
            DropForeignKey("dbo.StudentPrent", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentPrent", "Parent_ParentId", "dbo.Parent");
            DropForeignKey("dbo.Parent", "ParentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Student", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassMembership", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassMembership", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Administrator", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRecipient", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRecipient", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attachment", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Attachment", "FileTypeId", "dbo.FileType");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GlobalAnnouncement", "AuthorId", "dbo.Administrator");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TeacherSubjectAssignment", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjectAssignment", new[] { "TeacherId" });
            DropIndex("dbo.TestSharing", new[] { "TestId" });
            DropIndex("dbo.TestSharing", new[] { "ClassId" });
            DropIndex("dbo.OpenTestAnswer", new[] { "OpenQuestionId" });
            DropIndex("dbo.OpenTestAnswer", new[] { "TestAttemptId" });
            DropIndex("dbo.OpenQuestion", new[] { "TestId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "SubjectId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "ClassId" });
            DropIndex("dbo.TeacherClassSubject", new[] { "TeacherId" });
            DropIndex("dbo.Teacher", new[] { "TeacherId" });
            DropIndex("dbo.Test", new[] { "AuthorId" });
            DropIndex("dbo.Test", new[] { "SubjectId" });
            DropIndex("dbo.ClosedQuestion", new[] { "TestId" });
            DropIndex("dbo.ClosedQuestionOption", new[] { "ClosedQuestionId" });
            DropIndex("dbo.ClosedQuestionAnswer", new[] { "SelectedOptionId" });
            DropIndex("dbo.ClosedQuestionAnswer", new[] { "TestAttemptId" });
            DropIndex("dbo.TestAttempt", new[] { "StudentId" });
            DropIndex("dbo.TestAttempt", new[] { "TestId" });
            DropIndex("dbo.StudentPrent", new[] { "Student_StudentId" });
            DropIndex("dbo.StudentPrent", new[] { "Parent_ParentId" });
            DropIndex("dbo.Parent", new[] { "ParentId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "ParentId" });
            DropIndex("dbo.Student", new[] { "StudentId" });
            DropIndex("dbo.Grade", new[] { "SubjectId" });
            DropIndex("dbo.Grade", new[] { "TeacherId" });
            DropIndex("dbo.Grade", new[] { "StudentId" });
            DropIndex("dbo.Subject", new[] { "Class_ClassId" });
            DropIndex("dbo.ClassMembership", new[] { "ClassId" });
            DropIndex("dbo.ClassMembership", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Attachment", new[] { "FileTypeId" });
            DropIndex("dbo.Attachment", new[] { "MessageId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.MessageRecipient", new[] { "RecipientId" });
            DropIndex("dbo.MessageRecipient", new[] { "MessageId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.GlobalAnnouncement", new[] { "AuthorId" });
            DropIndex("dbo.Administrator", new[] { "Id" });
            DropTable("dbo.User");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TeacherSubjectAssignment");
            DropTable("dbo.TestSharing");
            DropTable("dbo.OpenTestAnswer");
            DropTable("dbo.OpenQuestion");
            DropTable("dbo.TeacherClassSubject");
            DropTable("dbo.Teacher");
            DropTable("dbo.Test");
            DropTable("dbo.ClosedQuestion");
            DropTable("dbo.ClosedQuestionOption");
            DropTable("dbo.ClosedQuestionAnswer");
            DropTable("dbo.TestAttempt");
            DropTable("dbo.StudentPrent");
            DropTable("dbo.Parent");
            DropTable("dbo.Student");
            DropTable("dbo.Grade");
            DropTable("dbo.Subject");
            DropTable("dbo.ClassMembership");
            DropTable("dbo.Class");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.FileType");
            DropTable("dbo.Attachment");
            DropTable("dbo.Message");
            DropTable("dbo.MessageRecipient");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.GlobalAnnouncement");
            DropTable("dbo.Administrator");
        }
    }
}
