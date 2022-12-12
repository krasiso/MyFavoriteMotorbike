using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Core.Models.Sorting;

namespace MyFavoriteMotorbike.Core.Contracts
{
    public interface IMotorbikeService
    {
        Task<IEnumerable<MotorbikeHomePageModel>> LastRentedMotorbikes();
        Task<IEnumerable<MotorbikeCategoryModel>> AllCategories();
        Task<IEnumerable<MotorbikeBrandModel>> AllBrands();
        Task<bool> CategoryExists(int categoryId);
        Task<int> Create(MotorbikeModel model);
        Task<MotorbikesQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            MotorbikeSorting sorting = MotorbikeSorting.Newest,
            int currentPage = 1,
            int motorbikesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<string>> AllBrandsNames();

        Task<IEnumerable<MotorbikeServiceModel>> AllMotorbikesByGoldenClientId(int id);

        Task<IEnumerable<MotorbikeServiceModel>> AllMotorbikesByUserId(string userId);

        Task<MotorbikeDetailsModel> MotorbikeDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int motorbikeId, MotorbikeModel model);

        Task<bool> HasGoldenClientWithId(int motorbikeId, string currentUserId);

        Task<int> GetMotorbikeCategoryId(int motorbikeId);

        Task<IEnumerable<MotorbikeServiceModel>> GetMineAsync(string userId);

        Task Delete(int motorbikeId);

        Task<bool> IsRented(int motorbikeId);

        Task<bool> IsRentedByUserWithId(int motorbikeId, string currentUserId);

        Task Vacate(int motorbikeId);

        Task Rent(int motorbikeId, string currentUserId);
    }
}
