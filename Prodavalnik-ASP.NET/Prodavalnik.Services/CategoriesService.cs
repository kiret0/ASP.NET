namespace Prodavalnik.Services
{
    using System.Collections.Generic;
    using System.IO.MemoryMappedFiles;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Categories;

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