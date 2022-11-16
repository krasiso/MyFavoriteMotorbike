using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class Motorbike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        [Required]
        public string Variety { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal CubicCentimeters { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PricePerDay { get; set; }
    }
}
