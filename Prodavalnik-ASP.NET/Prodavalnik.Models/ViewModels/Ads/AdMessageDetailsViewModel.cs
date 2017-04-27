namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using EntityModels;
    using EntityModels.Enums;

    public class AdMessageDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public State State { get; set; }

        public DateTime PublishOn { get; set; }

        public ApplicationUser Author { get; set; }
    }
}