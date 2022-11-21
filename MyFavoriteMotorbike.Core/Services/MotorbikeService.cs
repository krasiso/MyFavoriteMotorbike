using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Core.Models.Sorting;
using MyFavoriteMotorbike.Infrastructure.Data.Common;

namespace MyFavoriteMotorbike.Core.Services
{
    public class MotorbikeService : IMotorbikeService
    {
        private readonly IRepository repo;

        public MotorbikeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<MotorbikesQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            MotorbikeSorting sorting = MotorbikeSorting.Newest,
            int currentPage = 1,
            int motorbikesPerPage = 1)
        {
            var result = new MotorbikesQueryModel();
            var motorbikes = repo.AllReadonly<Motorbike>();

            if (string.IsNullOrEmpty(category) == false)
            {
                motorbikes = motorbikes
                    .Where(m => m.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                motorbikes = motorbikes
                    .Where(m => EF.Functions.Like(m.Brand.Name, searchTerm) ||
                                EF.Functions.Like(m.Variety.ToLower(), searchTerm) ||
                                EF.Functions.Like(m.Description.ToLower(), searchTerm));
            }

            motorbikes = sorting switch
            {
                MotorbikeSorting.Price => motorbikes
                    .OrderBy(m => m.PricePerDay),
                MotorbikeSorting.NotRentedFirst => motorbikes
                    .OrderBy(m => m.RenterId),
                _ => motorbikes.OrderByDescending(m => m.Id)
            };

            result.Motorbikes = await motorbikes
                .Skip((currentPage - 1) * motorbikesPerPage)
                .Take(motorbikesPerPage)
                .Select(m => new MotorbikeServiceModel()
                {
                    Brand = m.Brand.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    IsRented = m.RenterId != null,
                    PricePerDay = m.PricePerDay,
                })
                .ToListAsync();

            result.TotalMotorbikesCount = await motorbikes.CountAsync();

            return result;
        }

        public async Task<IEnumerable<MotorbikeCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new MotorbikeCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(MotorbikeModel model, int administratorId)
        {
            var motorbike = new Motorbike()
            {
                BrandId = model.BrandId,
                Variety = model.Variety,
                CubicCentimeters = model.CubicCentimeters,
                ImageUrl = model.ImageUrl,
                PricePerDay = model.PricePerDay,
                CategoryId = model.CategoryId,
                AdministratorId = administratorId
            };

            await repo.AddAsync(motorbike);
            await repo.SaveChangesAsync();

            return motorbike.Id;
        }

        public async Task<IEnumerable<MotorbikeHomePageModel>> LastRentedMotorbikes()
        {
            return await repo.AllReadonly<Motorbike>()
                .OrderByDescending(m => m.Id)
                .Select(m => new MotorbikeHomePageModel()
                {
                    Id = m.Id,
                    Brand = m.Brand.Name,
                    Model = m.Variety,
                    ImageUrl = m.ImageUrl
                })
                .Take(7)
                .ToListAsync();
        }
    }
}
