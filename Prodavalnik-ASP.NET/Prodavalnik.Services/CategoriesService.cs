namespace Prodavalnik.Services
{
    using Data.Contracts;
    using Models.EntityModels;

    public class CategoriesService :Service
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