namespace Prodavalnik.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class ProdavalnikContext : IdentityDbContext<ApplicationUser>, IProdavalnikContext
    {
        public ProdavalnikContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ProdavalnikContext Create()
        {
            return new ProdavalnikContext();
        }

        public DbContext DbContext => this;

        public IDbSet<Ad> Ads { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOptional(c => c.SubCategories).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }


}