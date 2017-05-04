namespace Prodavalnik.Models.EntityModels.Enums
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum State
    {
        [Display(Name = "Ново")]
        New,
        [Display(Name = "Използвано")]
        Used
    }
}