namespace Prodavalnik.Models.ViewModels.User
{
    using System;
    using EntityModels;

    public class MessageViewModel
    {
        public int Id { get; set; }

        public ApplicationUser Sender { get; set; }

        public string Content { get; set; }

        public DateTime DateOfSent { get; set; }

        public Ad Ad { get; set; }
    }
}