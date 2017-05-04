namespace Prodavalnik.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string ImageName { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}