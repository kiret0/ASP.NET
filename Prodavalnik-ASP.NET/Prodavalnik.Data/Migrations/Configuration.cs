namespace Prodavalnik.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<Prodavalnik.Data.ProdavalnikContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProdavalnikDb";
        }

        protected override void Seed(Prodavalnik.Data.ProdavalnikContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            
             

//            context.Ads.AddOrUpdate(new Ad[]
//            {
//                new Ad()
//                {
//                    Title = "Kartofi",
//                    Description = "Mnogo sveji kartofi ot gradinata na selo",
//                    Price = 12,
//                    Author = author,
//                    Category = category
//                },
//                new Ad()
//                {
//                    Title = "Svinski but",
//                    Description = "Ot Nasheto prasence specqlna selekciq",
//                    Price = 9,
//                    Author = author,
//                    Category = category
//                },
//            });
        }
    }
}
