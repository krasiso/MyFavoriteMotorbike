using MyFavoriteMotorbike.Core.Models.Motorbike;

namespace MyFavoriteMotorbike.Areas.Admin.Models
{
    public class MyMotorbikesViewModel
    {
        public IEnumerable<MotorbikeServiceModel> AddedMotorbikes { get; set; } = new List<MotorbikeServiceModel>();

        public IEnumerable<MotorbikeServiceModel> RentedMotorbikes { get; set; } = new List<MotorbikeServiceModel>();
    }
}
