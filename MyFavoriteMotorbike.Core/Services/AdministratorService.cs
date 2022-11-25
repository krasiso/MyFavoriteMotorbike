//using Microsoft.EntityFrameworkCore;
//using MyFavoriteMotobike.Infrastructure.Data.Entities;
//using MyFavoriteMotorbike.Core.Contracts;
//using MyFavoriteMotorbike.Infrastructure.Data.Common;

//namespace MyFavoriteMotorbike.Core.Services
//{
//    public class AdministratorService : IAdministratorService
//    {
//        private readonly IRepository repo;

//        public AdministratorService(IRepository _repo)
//        {
//            repo = _repo;
//        }

//        public async Task Create(string userId, string phoneNumber)
//        {
//            var administrator = new Administrator()
//            {
//                UserId = userId,
//                PhoneNumber = phoneNumber
//            };

//            await repo.AddAsync(administrator);
//            await repo.SaveChangesAsync();
//        }

//        public async Task<bool> ExistsById(string userId)
//        {
//            return await repo.All<Administrator>()
//                .AnyAsync(a => a.UserId == userId);
//        }

//        public async Task<int> GetAdministratorId(string userId)
//        {
//            return (await repo.AllReadonly<Administrator>()
//                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
//        }

//        public async Task<bool> UserHasRents(string userId)
//        {
//            return await repo.All<Motorbike>()
//                .AnyAsync(m => m.RenterId == userId);
//        }

//        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
//        {
//            return await repo.All<Administrator>()
//                .AnyAsync(a => a.PhoneNumber == phoneNumber);
//        }
//    }
//}
