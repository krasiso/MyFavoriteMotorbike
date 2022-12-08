using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class UserMotorbike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public string MotorbikeId { get; set; } = null!;

        [ForeignKey(nameof(MotorbikeId))]
        public Motorbike Motorbike { get; set; } = null!;

        public List<Motorbike> Motorbikes { get; set; } = new List<Motorbike>();
    }
}
