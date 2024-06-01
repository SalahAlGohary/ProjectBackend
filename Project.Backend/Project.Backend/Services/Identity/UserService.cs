using Microsoft.AspNetCore.Identity;
using Project.Backend.Constant;
using Project.Backend.Contracts.Identity;
using Project.Backend.Entities;
using System.Security.Claims;

namespace Project.Backend.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
        public bool? IsAdmin { get => _contextAccessor.HttpContext?.User?.IsInRole(AppConstants.RoleAdministrator); }
        public bool? IsUser { get => _contextAccessor.HttpContext?.User?.IsInRole(AppConstants.RoleUser); }

        public async Task<User> GetUser(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

    }
}
