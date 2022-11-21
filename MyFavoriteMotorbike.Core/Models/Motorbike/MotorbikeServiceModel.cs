using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class MotorbikeServiceModel
    {
        public int Id { get; init; }

        public string Brand { get; init; } = null!;

        public string Variety { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price per day")]
        [Range(0.00, 2000.00, ErrorMessage = "Price per day must be positive number and less than {2} euro!")]
        public decimal PricePerDay { get; init; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; }
    }
}
