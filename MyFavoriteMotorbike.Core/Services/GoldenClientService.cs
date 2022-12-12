using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Infrastructure.Data.Common;
using MyFavoriteMotorbike.Infrastructure.Data.Entities;

namespace MyFavoriteMotorbike.Core.Services
{
    public class GoldenClientService : IGoldenClientService
    {
        private readonly IRepository repo;

        public GoldenClientService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var administrator = new GoldenClient()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repo.AddAsync(administrator);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<GoldenClient>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetGoldenClientId(string userId)
        {
            return (await repo.AllReadonly<GoldenClient>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await repo.All<Motorbike>()
                .AnyAsync(m => m.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<GoldenClient>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
