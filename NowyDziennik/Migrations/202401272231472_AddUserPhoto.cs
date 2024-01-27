namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePhoto");
        }
    }
}
