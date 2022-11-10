using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class UserMotorbikes
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int MotorbikeId { get; set; }

        [ForeignKey(nameof(MotorbikeId))]
        public Motorbike Motorbike { get; set; } = null!;
    }
}
