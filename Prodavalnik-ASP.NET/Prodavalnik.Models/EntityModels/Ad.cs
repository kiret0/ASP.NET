namespace Prodavalnik.Models.EntityModels
{
    using System.Collections.Generic;
    using Enums;

    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Category Category { get; set; }

        public decimal Price { get; set; }

        public State State { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public ICollection<string> Images { get; set; }
    }
}