using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        public List<UserMotorbike> UserMotorbikes { get; set; }
    }
}
