namespace DziennikUczniaN.Migrations
{
    using DziennikUczniaN.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DziennikUczniaN.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DziennikUczniaN.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            IdentityManager role = new IdentityManager();
            role.CreateRole("Admin");
            role.CreateRole("Teacher");
            role.CreateRole("Parent");
            role.CreateRole("Student");
        }
    }
}
