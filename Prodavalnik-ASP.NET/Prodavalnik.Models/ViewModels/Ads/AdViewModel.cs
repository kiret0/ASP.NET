﻿namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;
    using Categories;
    using EntityModels;
    using EntityModels.Enums;

    public class AdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public State State { get; set; }

        public DateTime PublishOn { get; set; }

        public ApplicationUser Author { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}