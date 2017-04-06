namespace Prodavalnik.Models.EntityModels
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual  ICollection<Category> SubCategories { get; set; }
    }
}