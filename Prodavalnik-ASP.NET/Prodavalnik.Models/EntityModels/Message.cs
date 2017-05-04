namespace Prodavalnik.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int Id { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }

        public DateTime DateOfSent { get; set; }

        public virtual Ad Ad { get; set; }
    }
}