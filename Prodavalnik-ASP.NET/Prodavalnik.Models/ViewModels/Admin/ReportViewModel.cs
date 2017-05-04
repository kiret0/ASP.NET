namespace Prodavalnik.Models.ViewModels.Admin
{
    using EntityModels;

    public class ReportViewModel
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public string ReportInfo { get; set; }

        public Ad ReportedAd { get; set; }
    }
}