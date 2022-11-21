using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class AddMotorbikeViewModel
    {
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
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
