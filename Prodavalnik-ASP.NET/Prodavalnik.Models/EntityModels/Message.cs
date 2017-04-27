namespace Prodavalnik.Models.EntityModels
{
    using System;

    public class Message
    {
        public int Id { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        public string Content { get; set; }

        public DateTime DateOfSent { get; set; }

        public virtual Ad Ad { get; set; }

        public int  dfdgdfgdg { get; set; }
    }
}