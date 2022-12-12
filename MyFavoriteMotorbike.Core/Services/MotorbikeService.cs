using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Exceptions;
using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Core.Models.Sorting;
using MyFavoriteMotorbike.Infrastructure.Data.Common;

namespace MyFavoriteMotorbike.Core.Services
{
    public class MotorbikeService : IMotorbikeService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        public MotorbikeService(
            IRepository _repo,
            IGuard _guard)
        {
            repo = _repo;
            guard = _guard;
        }

        public async Task<MotorbikesQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            MotorbikeSorting sorting = MotorbikeSorting.Newest,
            int currentPage = 1,
            int motorbikesPerPage = 1)
        {
            var result = new MotorbikesQueryModel();
            var motorbikes = repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                motorbikes = motorbikes
                    .Where(m => m.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                motorbikes = motorbikes
                    .Where(m => EF.Functions.Like(m.Brand.Name.ToLower(), searchTerm) ||
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
                    PricePerDay = m.PricePerDay,
                    IsRented = m.RenterId != null
                })
                .ToListAsync();

            result.TotalMotorbikesCount = await motorbikes.CountAsync();

            return result;
        }

        public async Task<IEnumerable<MotorbikeBrandModel>> AllBrands()
        {
            return await repo.AllReadonly<Brand>()
               .OrderBy(c => c.Name)
               .Select(c => new MotorbikeBrandModel()
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllBrandsNames()
        {
            return await repo.AllReadonly<Brand>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
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

        public async Task<IEnumerable<MotorbikeServiceModel>> AllMotorbikesByGoldenClientId(int id)
        {
            return await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive)
                .Select(m => new MotorbikeServiceModel()
                {
                    Brand = m.Brand.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    PricePerDay = m.PricePerDay,
                    IsRented = m.RenterId != null
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MotorbikeServiceModel>> AllMotorbikesByUserId(string userId)
        {
            return await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive)
                .Where(m => m.RenterId == userId)
                .Select(m => new MotorbikeServiceModel()
                {
                    Brand = m.Brand.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    PricePerDay = m.PricePerDay,
                    IsRented = m.RenterId != null
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(MotorbikeModel model)
        {
            var motorbike = new Motorbike()
            {
                BrandId = model.BrandId,
                Variety = model.Variety,
                CubicCentimeters = model.CubicCentimeters,
                ImageUrl = model.ImageUrl,
                PricePerDay = model.PricePerDay,
                CategoryId = model.CategoryId
            };

            await repo.AddAsync(motorbike);
            await repo.SaveChangesAsync();

            return motorbike.Id;
        }

        public async Task Delete(int motorbikeId)
        {
            var motorbike = await repo.GetByIdAsync<Motorbike>(motorbikeId);
            motorbike.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task Edit(int motorbikeId, MotorbikeModel model)
        {
            var motorbike = await repo.GetByIdAsync<Motorbike>(motorbikeId);

            motorbike.BrandId = model.BrandId;
            motorbike.Variety = model.Variety;
            motorbike.CubicCentimeters = model.CubicCentimeters;
            motorbike.ImageUrl = model.ImageUrl;
            motorbike.PricePerDay = model.PricePerDay;
            motorbike.CategoryId = model.CategoryId;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Motorbike>()
                .AnyAsync(m => m.Id == id && m.IsActive);
        }

        public async Task<IEnumerable<MotorbikeServiceModel>> GetMineAsync(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.Motorbikes
                .Select(m => new MotorbikeServiceModel()
                {
                    Id = m.Id,
                    Brand = m.Brand.Name,
                    Variety = m.Variety,
                    ImageUrl = m.ImageUrl,
                    PricePerDay = m.PricePerDay,
                    IsRented = m.RenterId == userId
                });
        }

        public async Task<int> GetMotorbikeCategoryId(int motorbikeId)
        {
            return (await repo.GetByIdAsync<Motorbike>(motorbikeId))
                .CategoryId;
        }

        public async Task<bool> HasGoldenClientWithId(int motorbikeId, string currentUserId)
        {
            bool result = false;
            var motorbike = await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive)
                .Where(m => m.Id == motorbikeId)
                .FirstOrDefaultAsync();

            if (motorbike?.GoldenClient != null && motorbike.GoldenClient.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> IsRented(int motorbikeId)
        {
            return (await repo.GetByIdAsync<Motorbike>(motorbikeId)).RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int motorbikeId, string currentUserId)
        {
            bool result = false;
            var motorbike = await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive && m.Id == motorbikeId)
                .FirstOrDefaultAsync();

            if (motorbike != null && motorbike.RenterId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<MotorbikeHomePageModel>> LastRentedMotorbikes()
        {
            return await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive)
                .OrderByDescending(m => m.Id)
                .Select(m => new MotorbikeHomePageModel()
                {
                    Id = m.Id,
                    Brand = m.Brand.Name,
                    Variety = m.Variety,
                    ImageUrl = m.ImageUrl
                })
                .Take(7)
                .ToListAsync();
        }

        public async Task<MotorbikeDetailsModel> MotorbikeDetailsById(int id)
        {
            return await repo.AllReadonly<Motorbike>()
                .Where(m => m.IsActive)
                .Where(m => m.Id == id)
                .Select(m => new MotorbikeDetailsModel()
                {
                    Id = id,
                    Brand = m.Brand.Name,
                    Variety = m.Variety,
                    ImageUrl = m.ImageUrl,
                    PricePerDay = m.PricePerDay,
                    IsRented = m.RenterId != null,
                    Description = m.Description,
                    Category = m.Category.Name
                })
                .FirstAsync();
        }

        public async Task Rent(int motorbikeId, string currentUserId)
        {
            var motorbike = await repo.GetByIdAsync<Motorbike>(motorbikeId);

            if (motorbike != null && motorbike.RenterId != null)
            {
                throw new ArgumentException("Motorbike is already rented!");
            }

            guard.AgainstNull(motorbike, "This motorbike can not be found!");
            motorbike.RenterId = currentUserId;

            await repo.SaveChangesAsync();
        }

        public async Task Vacate(int motorbikeId)
        {
            var motorbike = await repo.GetByIdAsync<Motorbike>(motorbikeId);
            guard.AgainstNull(motorbike, "This motorbike can not be found!");

            motorbike.RenterId = null;
            await repo.SaveChangesAsync();
        }
    }
}
