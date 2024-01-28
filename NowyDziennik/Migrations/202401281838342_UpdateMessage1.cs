namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMessage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FileTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "FileTypeId");
        }
    }
}
