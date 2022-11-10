using MyFavoriteMotobike.Infrastructure.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class Engine
    {
        public Engine()
        {
            Motorbikes = new List<Motorbike>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public NumberOfStrokes NumberOfStrokes { get; set; }

        public int MyProperty { get; set; }

        [Required]
        public CoolingType CoolingType { get; set; }

        public List<Motorbike> Motorbikes { get; set; }
    }
}
