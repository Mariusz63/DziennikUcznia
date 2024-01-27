namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileSaveInClassTopic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassTopics", "FileContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassTopics", "FileContent");
        }
    }
}
