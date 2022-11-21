using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Core.Models.Sorting;

namespace MyFavoriteMotorbike.Core.Contracts
{
    public interface IMotorbikeService
    {
        Task<IEnumerable<MotorbikeHomePageModel>> LastRentedMotorbikes();
        Task<IEnumerable<MotorbikeCategoryModel>> AllCategories();
        Task<bool> CategoryExists(int categoryId);
        Task<int> Create(MotorbikeModel model, int administratorId);
        Task<MotorbikesQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            MotorbikeSorting sorting = MotorbikeSorting.Newest,
            int currentPage = 1,
            int motorbikesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();
    }
}
