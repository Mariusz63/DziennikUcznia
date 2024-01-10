namespace DziennikUczniaKoniec.Migrations
{
    using DziennikUczniaKoniec.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DziennikUczniaKoniec.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DziennikUczniaKoniec.Models.ApplicationDbContext context)
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
