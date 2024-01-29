namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassSubjectRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSubjects",
                c => new
                    {
                        ClassSubjectId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassSubjectId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ClassSubjects", "ClassId", "dbo.Classes");
            DropIndex("dbo.ClassSubjects", new[] { "SubjectId" });
            DropIndex("dbo.ClassSubjects", new[] { "ClassId" });
            DropTable("dbo.ClassSubjects");
        }
    }
}
