namespace Prodavalnik.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        public int Id { get; set; }

        [Required]
        public string Reason { get; set; }

        [StringLength(1000, MinimumLength = 20)]
        public string ReportInfo { get; set; }

        public bool Read { get; set; }

        public virtual Ad ReportedAd { get; set; }
    }
}