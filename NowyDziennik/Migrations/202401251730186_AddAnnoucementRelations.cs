namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnoucementRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementUsers",
                c => new
                    {
                        AnnouncementUserId = c.Int(nullable: false, identity: true),
                        AnnouncementId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnnouncementUserId)
                .ForeignKey("dbo.Announcements", t => t.AnnouncementId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AnnouncementId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnouncementUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnnouncementUsers", "AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.AnnouncementUsers", new[] { "UserId" });
            DropIndex("dbo.AnnouncementUsers", new[] { "AnnouncementId" });
            DropTable("dbo.AnnouncementUsers");
        }
    }
}
