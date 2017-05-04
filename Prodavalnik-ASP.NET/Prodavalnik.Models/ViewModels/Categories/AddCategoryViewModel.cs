namespace Prodavalnik.Models.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required]
        public string ImageName { get; set; }
    }
}