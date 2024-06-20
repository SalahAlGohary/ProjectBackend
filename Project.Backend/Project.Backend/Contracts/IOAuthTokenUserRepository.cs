using Project.Backend.Entities;

namespace Project.Backend.Contracts
{
    public interface IOAuthTokenUserRepository
    {
        Task<OAuthTokenUser> GetByToken(string Token);
        Task<int> AddOAuthTokenToUser(Guid UserId, string Token);

    }
}
