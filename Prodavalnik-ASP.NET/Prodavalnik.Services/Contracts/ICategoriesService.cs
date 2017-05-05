namespace Prodavalnik.Services.Contracts
{
    using Models.EntityModels;

    public interface ICategoriesService
    {
        void AddNewCategory(Category category);
    }
}