namespace Prodavalnik.Models.ViewModels.User
{
    using System;
    using EntityModels;

    public class MessageDetailsViewModel
    {
        public string Content { get; set; }

        public Ad Ad { get; set; }

        public ApplicationUser Sender { get; set; }

        public DateTime DateOfSent { get; set; }
    }
}