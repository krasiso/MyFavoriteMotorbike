using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class GoldenClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
