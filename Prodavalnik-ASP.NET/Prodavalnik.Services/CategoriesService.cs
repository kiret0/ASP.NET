namespace Prodavalnik.Services
{
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;

    public class CategoriesService :Service, ICategoriesService
    {
        public CategoriesService(IProdavalnikData data) : base(data)
        {
        }
        
        public void AddNewCategory(Category category)
        {
            data.Categories.InsertOrUpdate(category);
            data.SaveChanges();
        }
    }
}