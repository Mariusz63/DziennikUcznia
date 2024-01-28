namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConversationsRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageConversations", "Conversation_ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Conversation_ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.MessageConversations", "Message_MessageId", "dbo.Messages");
            DropForeignKey("dbo.ConversationApplicationUsers", "Conversation_ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.ConversationApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessageConversations", new[] { "Conversation_ConversationId" });
            DropIndex("dbo.MessageConversations", new[] { "Message_MessageId" });
            DropIndex("dbo.Messages", new[] { "Conversation_ConversationId" });
            DropIndex("dbo.ConversationApplicationUsers", new[] { "Conversation_ConversationId" });
            DropIndex("dbo.ConversationApplicationUsers", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.MessageRecipients",
                c => new
                    {
                        MessageId = c.Int(nullable: false),
                        RecipientId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MessageId, t.RecipientId })
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.RecipientId);
            
            AddColumn("dbo.Messages", "SenderId", c => c.String(maxLength: 128));
            AddColumn("dbo.Announcements", "MessageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "SenderId");
            CreateIndex("dbo.Announcements", "MessageId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Announcements", "MessageId", "dbo.Messages", "MessageId", cascadeDelete: true);
            DropColumn("dbo.Messages", "Conversation_ConversationId");
            DropTable("dbo.Conversations");
            DropTable("dbo.MessageConversations");
            DropTable("dbo.ConversationApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConversationApplicationUsers",
                c => new
                    {
                        Conversation_ConversationId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Conversation_ConversationId, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.MessageConversations",
                c => new
                    {
                        MessageConversationId = c.Int(nullable: false, identity: true),
                        Conversation_ConversationId = c.Int(),
                        Message_MessageId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageConversationId);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ConversationId);
            
            AddColumn("dbo.Messages", "Conversation_ConversationId", c => c.Int());
            DropForeignKey("dbo.Announcements", "MessageId", "dbo.Messages");
            DropForeignKey("dbo.MessageRecipients", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRecipients", "MessageId", "dbo.Messages");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Announcements", new[] { "MessageId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.MessageRecipients", new[] { "RecipientId" });
            DropIndex("dbo.MessageRecipients", new[] { "MessageId" });
            DropColumn("dbo.Announcements", "MessageId");
            DropColumn("dbo.Messages", "SenderId");
            DropTable("dbo.MessageRecipients");
            CreateIndex("dbo.ConversationApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ConversationApplicationUsers", "Conversation_ConversationId");
            CreateIndex("dbo.Messages", "Conversation_ConversationId");
            CreateIndex("dbo.MessageConversations", "Message_MessageId");
            CreateIndex("dbo.MessageConversations", "Conversation_ConversationId");
            AddForeignKey("dbo.ConversationApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ConversationApplicationUsers", "Conversation_ConversationId", "dbo.Conversations", "ConversationId", cascadeDelete: true);
            AddForeignKey("dbo.MessageConversations", "Message_MessageId", "dbo.Messages", "MessageId");
            AddForeignKey("dbo.Messages", "Conversation_ConversationId", "dbo.Conversations", "ConversationId");
            AddForeignKey("dbo.MessageConversations", "Conversation_ConversationId", "dbo.Conversations", "ConversationId");
        }
    }
}
