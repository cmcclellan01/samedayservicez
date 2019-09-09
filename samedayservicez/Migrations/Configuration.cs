namespace samedayservicez.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<samedayservicez.Models.samedayservicezContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "samedayservicez.Models.samedayservicezContext";
        }

        protected override void Seed(samedayservicez.Models.samedayservicezContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
