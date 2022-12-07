using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class MotorbikeModel
    {
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Variety { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal CubicCentimeters { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price per day")]
        [Range(0.00, 2000.00, ErrorMessage = "Price per day must be positive number and less than {2} euro")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<MotorbikeCategoryModel> MotorbikeCategories { get; set; } = new List<MotorbikeCategoryModel>();

        public IEnumerable<MotorbikeBrandModel> MotorbikeBrands { get; set; } = new List<MotorbikeBrandModel>();
    }
}
