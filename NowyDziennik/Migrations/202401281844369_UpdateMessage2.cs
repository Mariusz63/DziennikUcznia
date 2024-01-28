namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMessage2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            AddColumn("dbo.Messages", "RecipientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "RecipientId");
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            AddForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Messages", new[] { "RecipientId" });
            DropColumn("dbo.Messages", "ApplicationUser_Id");
            DropColumn("dbo.Messages", "RecipientId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id");
        }
    }
}
