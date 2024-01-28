namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConversationsRelations2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileTypes", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileTypes", "Data");
        }
    }
}
