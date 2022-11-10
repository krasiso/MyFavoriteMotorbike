using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //[Required]
        //public string FlagUrl { get; set; } = null!;

        //[Required]
        //public int BrandId { get; set; }

        //[ForeignKey(nameof(BrandId))]
        //public Brand Brand { get; set; } = null!;
    }
}
