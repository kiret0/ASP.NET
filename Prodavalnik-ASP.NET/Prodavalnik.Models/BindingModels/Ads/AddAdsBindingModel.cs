namespace Prodavalnik.Models.BindingModels.Ads
{
    using EntityModels.Enums;

    public class AddAdsBindingModel
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

       
        public string State { get; set; }

       
        public string Description { get; set; }
    }
}