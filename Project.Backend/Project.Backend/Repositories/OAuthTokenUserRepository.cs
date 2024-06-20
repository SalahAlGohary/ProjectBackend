using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Entities;

namespace Project.Backend.Repositories
{
    public class OAuthTokenUserRepository : IOAuthTokenUserRepository
    {
        ProjectDBContext _context;
        public OAuthTokenUserRepository(ProjectDBContext context)
        {
            _context = context;
        }

        public async Task<OAuthTokenUser> GetByToken(string Token)
        {
            return await _context.OAuthTokenUsers.FirstOrDefaultAsync(x => x.Token == Token);
        }
        public async Task<int> AddOAuthTokenToUser(Guid UserId, string Token)
        {
            var userToken = new OAuthTokenUser()
            {
                UserId = UserId,
                Token = Token
            };
            await _context.OAuthTokenUsers.AddAsync(userToken);
            return await _context.SaveChangesAsync();

        }
    }
}
