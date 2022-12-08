using MyFavoriteMotorbike.Core.Models.Admin;

namespace MyFavoriteMotorbike.Core.Contracts.Admin
{
    public interface IUserGoldenClientService
    {
        Task<string> UserUserName(string userId);

        Task<IEnumerable<UserAdminServiceModel>> All();
    }
}
