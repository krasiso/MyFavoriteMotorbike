using MyFavoriteMotorbike.Core.Models.Motorbike;

namespace MyFavoriteMotorbike.Core.Contracts
{
    public interface IMotorbikeService
    {
        Task<IEnumerable<MotorbikeHomePageModel>> LastRentedMotorbikes();
    }
}
