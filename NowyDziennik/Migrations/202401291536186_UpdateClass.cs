namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "ClassId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "ClassId");
        }
    }
}
