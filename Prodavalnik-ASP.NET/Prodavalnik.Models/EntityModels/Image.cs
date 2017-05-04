namespace Prodavalnik.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImageName { get; set; }
    }
}