namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp1.DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;  // if this is set to true, we can skip the "add-migration" step
            ContextKey = "ConsoleApp1.DAL.MyContext";
        }

        protected override void Seed(ConsoleApp1.DAL.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Korisnici.Add(new Models.Korisnik { Username = "admin", Password = "admin" });

        }
    }
}
