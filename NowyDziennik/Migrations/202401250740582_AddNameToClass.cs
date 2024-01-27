namespace NowyDziennik.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNameToClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "ClassName", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Classes", "ClassName");
        }
    }
}
