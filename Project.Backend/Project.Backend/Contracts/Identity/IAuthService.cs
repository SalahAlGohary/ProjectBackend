using NativeBackend.Application.Common.Models.Identity;
using Project.Backend.Models.Identity.Responses;

namespace Project.Backend.Contracts.Identity
{
    public interface IAuthService
    {
        Task<IdentityResponse> Register(RegistrationRequest request);
        Task<IdentityResponse> Login(AuthRequest request);
        Task<IdentityResponse> ChangePassword(ChangePasswordRequest request);
        //Task<IdentityResponse> Verify(AuthRequest request);
        Task<IdentityResponse> EditProfile(EditProfileRequest request);
        Task<IdentityResponse> GetProfile(string UserId);
        //Task<IdentityResponse> ChangeProfileImage(string userId, IFormFile Image);
        Task<IdentityResponse> ChangeProfileImage(string userId, IFormFile Image, string webRootPath, string content, string domain);
        //Task<IdentityResponse> ChangePhoneNumberChecker(AuthRequest request, string UserId);
        //Task<IdentityResponse> ConfirmChangePhoneNumber(AuthRequest request, string userId);
        //Task<IdentityResponse> ChangeProfileLanguage(string userId, string language);
        //Task<IdentityResponse> ChangeProfileSendNotifications(string userId, bool sendNotification);
        Task<IdentityResponse> LogOut(string userId);
        Task<IdentityResponse> DeleteAccount(string userId);
        Task<IdentityResponse> AdminLogin(AdminAuthRequest request);
    }
}
