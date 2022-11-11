using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class CountryOfOrigin
    {
        public CountryOfOrigin()
        {
            Brands = new List<Brand>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        public List<Brand> Brands { get; set; } = null!;
    }
}
