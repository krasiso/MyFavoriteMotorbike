using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        //[Required]
        //public int MotorbikeId { get; set; }

        //[ForeignKey(nameof(MotorbikeId))]
        //public Motorbike Motorbike { get; set; } = null!;
    }
}
