using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Models.Motorbike;
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
