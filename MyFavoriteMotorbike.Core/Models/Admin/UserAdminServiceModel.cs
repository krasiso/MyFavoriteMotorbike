namespace MyFavoriteMotorbike.Core.Models.Admin
{
    public class UserAdminServiceModel
    {
        public string UserId { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string UserName { get; init; } = null!;
        public string? PhoneNumber { get; init; } = null;
    }
}
