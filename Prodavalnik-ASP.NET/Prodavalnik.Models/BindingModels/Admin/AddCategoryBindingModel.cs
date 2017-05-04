namespace Prodavalnik.Models.BindingModels.Admin
{
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryBindingModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string ImageName { get; set; }
    }
}