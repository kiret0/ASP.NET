﻿namespace Prodavalnik.Models.EntityModels
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}