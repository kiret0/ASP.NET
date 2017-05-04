namespace Prodavalnik.Models.BindingModels.Ads
{
    using System.ComponentModel.DataAnnotations;

    public class ReportAdBindingModel
    {
        public string Optradio { get; set; }

        [StringLength(1000, ErrorMessage = "Описанието е твърде дълго.")]
        [MinLength(20, ErrorMessage = "Описанието е твърде кратко.")]
        public string ReportInfo { get; set; }
    }
}