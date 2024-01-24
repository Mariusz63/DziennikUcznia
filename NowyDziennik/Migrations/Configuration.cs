namespace NowyDziennik.Migrations
{
    using NowyDziennik.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NowyDziennik.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NowyDziennik.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            IdentityManager IM = new IdentityManager();
            IM.CreateRole("Admin");
            IM.CreateRole("Teacher");
            IM.CreateRole("Parent");
            IM.CreateRole("Student");
        }
    }
}
