namespace DziennikUczniaKoniec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "SecondName", c => c.String());
            AddColumn("dbo.User", "SelectedRole", c => c.String());
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.User", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "RoleName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            DropColumn("dbo.User", "SelectedRole");
            DropColumn("dbo.User", "SecondName");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
