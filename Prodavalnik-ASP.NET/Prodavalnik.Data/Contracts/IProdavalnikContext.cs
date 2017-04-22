namespace Prodavalnik.Data.Contracts
{
    using System.Data.Entity;
    using Models.EntityModels;

    public interface IProdavalnikContext
    {
        DbContext DbContext { get; }

        IDbSet<Ad> Ads { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Image> Images { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
