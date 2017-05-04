namespace Prodavalnik.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Ad
    {
        public Ad()
        {
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Title { get; set; }

        public virtual Category Category { get; set; }

        
        public decimal Price { get; set; }

        [EnumDataType(typeof(State))]
        public State State { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 25)]
        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public DateTime PublishOn { get; set; }
        
    }
}