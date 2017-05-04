namespace Prodavalnik.Data.Contracts
{
    using Models.EntityModels;

    public interface IProdavalnikData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Ad> Ads { get; }

        IRepository<Category> Categories { get; }

        IRepository<Image> Images { get; }

        IRepository<Message> Messages { get; }

        IRepository<Report> Reports { get; }

        IProdavalnikContext Context { get; }

        int SaveChanges();
    }
}
