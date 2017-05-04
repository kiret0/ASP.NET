namespace Prodavalnik.Models.ViewModels.User
{
    using EntityModels;
    using Manage;

    public class SettingsViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }
}