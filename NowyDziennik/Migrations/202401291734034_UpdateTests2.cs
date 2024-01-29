namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTests2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectTopics", "TestId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectTopics", "TestId");
        }
    }
}
