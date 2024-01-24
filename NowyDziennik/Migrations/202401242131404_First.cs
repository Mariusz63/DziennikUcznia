namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        SupervisorId = c.String(maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.SupervisorId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.TeacherClassSubjects",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.ClassId, t.SubjectId })
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Students", "ClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "ParentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "ParentId");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ParentId", "dbo.Parents", "ParentId");
            AddForeignKey("dbo.Students", "StudentId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.Classes", "SupervisorId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherClassSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherClassSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherClassSubjects", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.TeacherClassSubjects", new[] { "SubjectId" });
            DropIndex("dbo.TeacherClassSubjects", new[] { "ClassId" });
            DropIndex("dbo.TeacherClassSubjects", new[] { "TeacherId" });
            DropIndex("dbo.Classes", new[] { "SupervisorId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Students", new[] { "ParentId" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            AlterColumn("dbo.Students", "ParentId", c => c.String());
            DropColumn("dbo.Students", "ClassId");
            DropTable("dbo.TeacherClassSubjects");
            DropTable("dbo.Classes");
        }
    }
}
