namespace Prodavalnik.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));
            }
            
        }
    }
}
