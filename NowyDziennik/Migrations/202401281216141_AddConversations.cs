namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConversations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConversationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Messages", "ConversationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "ConversationId");
            AddForeignKey("dbo.Messages", "ConversationId", "dbo.Conversations", "ConversationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conversations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ConversationId", "dbo.Conversations");
            DropIndex("dbo.Messages", new[] { "ConversationId" });
            DropIndex("dbo.Conversations", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Messages", "ConversationId");
            DropTable("dbo.Conversations");
        }
    }
}
