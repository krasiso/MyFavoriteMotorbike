using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Core.Contracts.Admin;
using MyFavoriteMotorbike.Core.Models.Admin;
using MyFavoriteMotorbike.Infrastructure.Data.Common;
using MyFavoriteMotorbike.Infrastructure.Data.Entities;

namespace MyFavoriteMotorbike.Core.Services.Admin
{
    public class UserGoldenClientService : IUserGoldenClientService
    {
        private readonly IRepository repo;

        public UserGoldenClientService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserAdminServiceModel>> All()
        {
            List<UserAdminServiceModel> result;

            result = await repo.AllReadonly<GoldenClient>()
                .Select(gc => new UserAdminServiceModel()
                {
                    UserId = gc.UserId,
                    Email = gc.User.Email,
                    UserName = gc.User.UserName,
                    PhoneNumber = gc.User.PhoneNumber
                })
                .ToListAsync();

            string[] goldenClientIds = result.Select(gc => gc.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<User>()
                .Where(u => goldenClientIds.Contains(u.Id) == false)
                .Select(gc => new UserAdminServiceModel()
                {
                    UserId = gc.Id,
                    Email = gc.Email,
                    UserName = gc.UserName,
                    PhoneNumber = gc.PhoneNumber
                })
                .ToListAsync());

            return result;
        }

        public async Task<string> UserUserName(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            return user.UserName;
        }
    }
}
