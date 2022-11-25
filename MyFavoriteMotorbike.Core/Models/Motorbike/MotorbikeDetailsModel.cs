using MyFavoriteMotorbike.Core.Models.Administrator;

namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class MotorbikeDetailsModel : MotorbikeServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        //public AdministratorServiceModel Administrator { get; set; }
    }
}
