namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTopicToClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassTopics",
                c => new
                    {
                        ClassTopicId = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Description = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassTopicId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.FileAttachments",
                c => new
                    {
                        FileAttachmentId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileContent = c.Binary(),
                        ClassTopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileAttachmentId)
                .ForeignKey("dbo.ClassTopics", t => t.ClassTopicId, cascadeDelete: true)
                .Index(t => t.ClassTopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassTopics", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.FileAttachments", "ClassTopicId", "dbo.ClassTopics");
            DropIndex("dbo.FileAttachments", new[] { "ClassTopicId" });
            DropIndex("dbo.ClassTopics", new[] { "ClassId" });
            DropTable("dbo.FileAttachments");
            DropTable("dbo.ClassTopics");
        }
    }
}
