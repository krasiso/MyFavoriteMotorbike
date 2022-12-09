using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotorbike.Core.Models.Administrator
{
    public class BecomeAdministratorModel
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
