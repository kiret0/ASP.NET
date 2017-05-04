namespace Prodavalnik.Models.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using EntityModels;

    public class MyAdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishOn { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}