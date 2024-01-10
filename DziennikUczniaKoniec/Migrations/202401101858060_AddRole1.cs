namespace DziennikUczniaKoniec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRole1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GlobalAnnouncement", newName: "Announcement");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Announcement", newName: "GlobalAnnouncement");
        }
    }
}
