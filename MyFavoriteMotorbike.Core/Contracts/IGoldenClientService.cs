namespace MyFavoriteMotorbike.Core.Contracts
{
    public interface IGoldenClientService
    {
        Task<bool> ExistsById(string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        Task<bool> UserHasRents(string userId);
        Task Create(string userId, string phoneNumber);
        Task<int> GetGoldenClientId(string userId);
    }
}
