namespace Prodavalnik.Models.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using EntityModels;

    public class HomeAdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}