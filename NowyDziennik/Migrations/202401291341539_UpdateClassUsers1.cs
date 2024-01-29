namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassUsers1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassTopics", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.FileAttachments", "ClassTopicId", "dbo.ClassTopics");
            DropIndex("dbo.ClassTopics", new[] { "ClassId" });
            DropIndex("dbo.FileAttachments", new[] { "ClassTopicId" });
            CreateTable(
                "dbo.SubjectTopics",
                c => new
                    {
                        SubjectTopicId = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Description = c.String(),
                        FileContent = c.Binary(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectTopicId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.FileAttachments", "SubjectTopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.FileAttachments", "SubjectTopicId");
            AddForeignKey("dbo.FileAttachments", "SubjectTopicId", "dbo.SubjectTopics", "SubjectTopicId", cascadeDelete: true);
            DropColumn("dbo.FileAttachments", "ClassTopicId");
            DropTable("dbo.ClassTopics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClassTopics",
                c => new
                    {
                        ClassTopicId = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Description = c.String(),
                        FileContent = c.Binary(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassTopicId);
            
            AddColumn("dbo.FileAttachments", "ClassTopicId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SubjectTopics", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.FileAttachments", "SubjectTopicId", "dbo.SubjectTopics");
            DropIndex("dbo.FileAttachments", new[] { "SubjectTopicId" });
            DropIndex("dbo.SubjectTopics", new[] { "SubjectId" });
            DropColumn("dbo.FileAttachments", "SubjectTopicId");
            DropTable("dbo.SubjectTopics");
            CreateIndex("dbo.FileAttachments", "ClassTopicId");
            CreateIndex("dbo.ClassTopics", "ClassId");
            AddForeignKey("dbo.FileAttachments", "ClassTopicId", "dbo.ClassTopics", "ClassTopicId", cascadeDelete: true);
            AddForeignKey("dbo.ClassTopics", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
    }
}
