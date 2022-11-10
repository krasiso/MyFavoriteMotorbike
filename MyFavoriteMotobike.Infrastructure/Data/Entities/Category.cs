using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Motorbikes = new List<Motorbike>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        public List<Motorbike> Motorbikes { get; set; }
    }
}
