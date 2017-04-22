namespace Prodavalnik.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Ad
    {
        public Ad()
        {
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Category Category { get; set; }

        public decimal Price { get; set; }

        public State State { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public DateTime PublishOn { get; set; }

        
    }
}