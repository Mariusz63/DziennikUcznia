namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        StudentClassId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentClassId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);
            
            DropColumn("dbo.Students", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ClassId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentClasses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "ClassId", "dbo.Classes");
            DropIndex("dbo.StudentClasses", new[] { "ClassId" });
            DropIndex("dbo.StudentClasses", new[] { "StudentId" });
            DropTable("dbo.StudentClasses");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
    }
}
