using Project.Backend.Entities;

namespace Project.Backend.Contracts.Identity
{
    public interface IUserService
    {
        Task<User> GetUser(string userId);
        public string UserId { get; }
    }
}
