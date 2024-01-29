namespace NowyDziennik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Tests", new[] { "SubjectId" });
            DropIndex("dbo.Grades", new[] { "Subject_SubjectId" });
            AddColumn("dbo.Tests", "SubjectTopicId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "SubjectTopic_SubjectTopicId", c => c.Int());
            CreateIndex("dbo.Tests", "SubjectTopicId");
            CreateIndex("dbo.Grades", "SubjectTopic_SubjectTopicId");
            AddForeignKey("dbo.Grades", "SubjectTopic_SubjectTopicId", "dbo.SubjectTopics", "SubjectTopicId");
            AddForeignKey("dbo.Tests", "SubjectTopicId", "dbo.SubjectTopics", "SubjectTopicId", cascadeDelete: true);
            DropColumn("dbo.Tests", "SubjectId");
            DropColumn("dbo.Grades", "Subject_SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "Subject_SubjectId", c => c.Int());
            AddColumn("dbo.Tests", "SubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tests", "SubjectTopicId", "dbo.SubjectTopics");
            DropForeignKey("dbo.Grades", "SubjectTopic_SubjectTopicId", "dbo.SubjectTopics");
            DropIndex("dbo.Grades", new[] { "SubjectTopic_SubjectTopicId" });
            DropIndex("dbo.Tests", new[] { "SubjectTopicId" });
            DropColumn("dbo.Grades", "SubjectTopic_SubjectTopicId");
            DropColumn("dbo.Tests", "SubjectTopicId");
            CreateIndex("dbo.Grades", "Subject_SubjectId");
            CreateIndex("dbo.Tests", "SubjectId");
            AddForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}
