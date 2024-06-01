using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NativeBackend.Application.Common.Models.Identity;
using Project.Backend.Constant;
using Project.Backend.Contracts.Identity;
using Project.Backend.Contracts.Infrastructure;
using Project.Backend.Entities;
using Project.Backend.Models.Identity.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Backend.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IFormFileImagesService _formFileImagesService;
        //private readonly ICloudStorage _cloudStorageService;
        //private readonly ISmsService _smsService;

        public AuthService(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<User> signInManager,
            IFormFileImagesService formFileImagesService)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _formFileImagesService = formFileImagesService;
        }

        public async Task<IdentityResponse> Register(RegistrationRequest request)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {
                request.PhoneNumber = request.PhoneNumber.Trim();
                //request.PhoneKey = request.PhoneKey.Trim();

                string UserName = request.PhoneNumber + AppConstants.AppDomain;

                var existingUser = await _userManager.FindByNameAsync(UserName);

                if (existingUser != null)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"Phone '{request.PhoneNumber}' already exists.");
                    //response.AddError(AppConstants.Code, AppConstants.This_Phone_Registerd_Before);
                    return response;
                }
                var existingEmail = await _userManager.FindByEmailAsync(UserName);

                if (existingEmail == null)
                {

                    var user = new User
                    {
                        //CreationDate = DateTime.UtcNow,
                        PhoneNumber = request.PhoneNumber,
                        //PhoneKey = request.PhoneKey,
                        Email = UserName,
                        Name = request.Name,
                        UserName = UserName,
                        EmailConfirmed = true,
                        Mail = request.Mail ?? null,
                        BirthDate = request.BirthDate
                    };
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        //await SendVerificationCode(user);
                        response.clearBody();
                        response.StatusCode = AppConstants.Success;
                        response.AddModel(AppConstants.Model, true);
                        //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                        return response;
                    }
                    else
                    {
                        response.clearBody();
                        response.StatusCode = AppConstants.InternalServerError;
                        response.AddError(AppConstants.Error, $"{result.Errors}");
                        //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                        return response;
                    }
                }
                else
                {
                    response.clearBody();
                    // response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"Phone Number {request.PhoneNumber} already exists.");
                    //response.AddError(AppConstants.Code, AppConstants.This_Phone_Registerd_Before);
                    return response;
                }
            }
            catch (Exception ex)
            {

                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }
        //public async Task<IdentityResponse> Verify(AuthRequest request)
        //{
        //    IdentityResponse response = new IdentityResponse();

        //    try
        //    {
        //        string email = request.PhoneNumber + AppConstants.AppDomain;
        //        var user = await _userManager.FindByEmailAsync(email);

        //        if (user == null)
        //        {
        //            response.StatusCode = AppConstants.BadRequest;
        //            response.AddError(AppConstants.Error, $"User with {request.PhoneNumber} not found.");
        //            response.AddError(AppConstants.Code, AppConstants.This_Phone_Not_Registerd_Before);
        //            return response;
        //        }
        //        if (user.IsDeleted)
        //        {
        //            response.StatusCode = AppConstants.BadRequest;
        //            response.AddError(AppConstants.Error, $"User with {request.PhoneNumber} Is Deleted.");
        //            response.AddError(AppConstants.Code, AppConstants.User_Is_Deleted);
        //            return response;
        //        }
        //        //if (string.IsNullOrEmpty(user.Vcode))
        //        //{
        //        //    response.StatusCode = AppConstants.BadRequest;
        //        //    response.AddError(AppConstants.Message, "Invalid Vcode");
        //        //    response.AddError(AppConstants.Code, AppConstants.invalid_Vcode);
        //        //    return response;
        //        //}
        //        //if (user.Vcode != request.VCode && request.VCode != "7777")
        //        //{
        //        //    response.StatusCode = AppConstants.BadRequest;
        //        //    response.AddError(AppConstants.Message, "Invalid Vcode");
        //        //    response.AddError(AppConstants.Code, AppConstants.invalid_Vcode);
        //        //    return response;
        //        //}
        //        //if (user.ExpirationVCodeDate < DateTime.UtcNow)
        //        //{
        //        //    response.StatusCode = AppConstants.BadRequest;
        //        //    response.AddError(AppConstants.Message, "Expired ExpirationVCodeDate");
        //        //    response.AddError(AppConstants.Code, AppConstants.ExpirationVCodeDate_Expired);
        //        //    return response;
        //        //}


        //        //user.Vcode = null;
        //        //user.ExpirationVCodeDate = DateTime.UtcNow.AddHours(-7);
        //        //user.Verified = true;
        //        //var resetPass = await _userManager.UpdateAsync(user);

        //        //if (!resetPass.Succeeded)
        //        //{
        //        //    response.StatusCode = AppConstants.BadRequest;
        //        //    response.AddError(AppConstants.Message, "An Error Occurred");
        //        //    response.AddError(AppConstants.Code, AppConstants.Error_try_later);
        //        //    return response;
        //        //}

        //        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
        //        AuthResponse model = CreateAuthResponse(user, jwtSecurityToken);

        //        response.StatusCode = AppConstants.Success;
        //        response.AddModel(AppConstants.AuthResponse, model);
        //        response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.StatusCode = AppConstants.BadRequest;
        //        response.AddError(AppConstants.Error, ex.Message);
        //        response.AddError(AppConstants.Message, "An Error Occurred");
        //        response.AddError(AppConstants.Code, AppConstants.Error_try_later);
        //        return response;
        //    }
        //}

        public async Task<IdentityResponse> Login(AuthRequest request)
        {
            IdentityResponse response = new IdentityResponse();

            try
            {
                string email = request.PhoneNumber + AppConstants.AppDomain;
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"User with {request.PhoneNumber} not found.");
                    //response.AddError(AppConstants.Code, AppConstants.This_Phone_Not_Registerd_Before);
                    return response;
                }
                if (user.IsDeleted)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"User with {request.PhoneNumber} Is Deleted.");
                    //response.AddError(AppConstants.Code, AppConstants.User_Is_Deleted);
                    return response;
                }
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, "Invalid Credentials.");
                    //response.AddError(AppConstants.Code, AppConstants.INVALIDE_EMAIL_OR_PASSWORD);
                    return response;
                }
                response.StatusCode = AppConstants.Success;
                //response.AddModel(AppConstants.AuthResponse, true);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                //return response;

                //var IsSent = await SendVerificationCode(user);
                //if (IsSent)
                //{
                //    response.StatusCode = AppConstants.Success;
                //    response.AddModel(AppConstants.AuthResponse , true);
                //    response.AddMeta(AppConstants.Message , AppConstants.SuccessMessage);
                //    return response;
                //}
                response.StatusCode = AppConstants.BadRequest;
                //response.AddError(AppConstants.Error , $"VCode Not sent");
                //response.AddError(AppConstants.Code , AppConstants.VCode_Not_sent);
                //return response;
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                AuthResponse model = CreateAuthResponse(user, jwtSecurityToken);

                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.AuthResponse, model);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }
        public async Task<IdentityResponse> ChangePassword(ChangePasswordRequest request)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {
                var user = await _userManager.FindByIdAsync(request.Id);
                if (user == null)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"User not found.");
                    //response.AddError(AppConstants.Code, AppConstants.This_Phone_Not_Registerd_Before);
                    return response;
                }
                if (user.IsDeleted)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"User Is Deleted.");
                    //response.AddError(AppConstants.Code, AppConstants.User_Is_Deleted);
                    return response;
                }
                var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
                if (!result.Succeeded)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, "Invalid Old Password.");
                    // response.AddError(AppConstants.Code, AppConstants.INVALIDE_EMAIL_OR_PASSWORD);
                    return response;
                }
                user = await _userManager.FindByIdAsync(request.Id);
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                AuthResponse model = CreateAuthResponse(user, jwtSecurityToken);

                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.AuthResponse, model);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }

        //public async Task<IdentityResponse> ChangePhoneNumberChecker(AuthRequest request, string UserId)
        //{
        //    IdentityResponse response = new IdentityResponse();
        //    try
        //    {
        //        var CurrentUser = await _userManager.FindByIdAsync(UserId);
        //        if (CurrentUser == null)
        //        {
        //            response.clearBody();
        //            response.StatusCode = AppConstants.UnAuthorized;
        //            response.AddError(AppConstants.Error, $"User with token not found.");
        //            //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
        //            return response;
        //        }
        //        if (CurrentUser.PhoneNumber == request.PhoneNumber)
        //        {
        //            response.StatusCode = AppConstants.BadRequest;
        //            response.AddError(AppConstants.Error, $"The Phone Number Is The same current phone ");
        //            response.AddError(AppConstants.Code, AppConstants.The_Phone_Number_Is_The_Same_Current_Phone);
        //            return response;

        //        }

        //        string email = request.PhoneNumber + AppConstants.AppDomain;
        //        var user = await _userManager.FindByEmailAsync(email);
        //        if (user != null)
        //        {
        //            response.StatusCode = AppConstants.BadRequest;
        //            response.AddError(AppConstants.Error, $"this phone {request.PhoneNumber} is registered before.");
        //            response.AddError(AppConstants.Code, AppConstants.This_Phone_Registerd_Before);
        //            return response;
        //        }
        //        user.Email = email;
        //        user.PhoneNumber = request.PhoneNumber;
        //        response.StatusCode = AppConstants.Success;
        //        response.AddModel(AppConstants.AuthResponse, true);
        //        response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
        //        return response;
        //        //var IsSent = await SendVerificationCode(CurrentUser, request.PhoneNumber);
        //        //if (IsSent)
        //        //{
        //        //    response.StatusCode = AppConstants.Success;
        //        //    response.AddModel(AppConstants.AuthResponse, true);
        //        //    response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
        //        //    return response;
        //        //}
        //        response.StatusCode = AppConstants.BadRequest;
        //        //response.AddError(AppConstants.Error, $"VCode Not sent");
        //        //response.AddError(AppConstants.Code, AppConstants.VCode_Not_sent);
        //        //return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.StatusCode = AppConstants.BadRequest;
        //        response.AddError(AppConstants.Error, ex.Message);
        //        response.AddError(AppConstants.Message, "An Error Occurred");
        //        response.AddError(AppConstants.Code, AppConstants.Error_try_later);
        //        return response;
        //    }
        //}

        private AuthResponse CreateAuthResponse(User user, JwtSecurityToken jwtSecurityToken)
        {
            return new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                PhoneNumber = user.PhoneNumber,
                LogoImagePath = user.PhotoUrl,
                Name = user.Name,
                BirthDate = user.BirthDate,
                Mail = user.Mail
            };
        }
        public async Task<IdentityResponse> EditProfile(EditProfileRequest request)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {

                var user = await _userManager.FindByIdAsync(request.userId);
                if (user == null)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.UnAuthorized;
                    response.AddError(AppConstants.Error, $"User with token not found.");
                    //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
                    return response;
                }
                //user.BirthDate = DateTime.SpecifyKind(request.BirthDate.Value, DateTimeKind.Utc);
                if (request.Name != null)
                    user.Name = request.Name;
                if (request.Mail != null)
                    user.Mail = request.Mail;
                if (request.Phone != null)
                {
                    if (user.PhoneNumber != request.Phone)
                    {
                        string email = request.Phone + AppConstants.AppDomain;
                        var userByPhone = await _userManager.FindByEmailAsync(email);
                        if (userByPhone != null)
                        {
                            response.StatusCode = AppConstants.BadRequest;
                            response.AddError(AppConstants.Error, $"this phone {request.Phone} is registered before.");
                            //response.AddError(AppConstants.Code, AppConstants.This_Phone_Registerd_Before);
                            return response;
                        }
                        user.Email = email;
                        user.PhoneNumber = request.Phone;
                        response.StatusCode = AppConstants.BadRequest;
                        //response.AddError(AppConstants.Error, $"The Phone Number Is The same current phone ");
                        //response.AddError(AppConstants.Code, AppConstants.The_Phone_Number_Is_The_Same_Current_Phone);
                        //return response;

                    }

                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    //var Profile = CreateProfileResponse(user);
                    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                    AuthResponse Profile = CreateAuthResponse(user, jwtSecurityToken);
                    response.clearBody();
                    response.StatusCode = AppConstants.Success;
                    response.AddModel(AppConstants.Model, Profile);
                    //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                    return response;

                }
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
            catch (Exception ex)
            {

                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                // response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }


        public async Task<IdentityResponse> ChangeProfileImage(string userId, IFormFile Image, string webRootPath, string content, string domain)
        {
            IdentityResponse response = new IdentityResponse();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                response.clearBody();
                response.StatusCode = AppConstants.UnAuthorized;
                response.AddError(AppConstants.Error, $"User with token not found.");
                //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
                return response;
            }
            var path = _formFileImagesService.saveImage(Image, webRootPath, content, domain, "Users");
            user.PhotoUrl = path;
            await _userManager.UpdateAsync(user);
            //var Profile = CreateProfileResponse(user);
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            AuthResponse Profile = CreateAuthResponse(user, jwtSecurityToken);
            response.clearBody();
            response.StatusCode = AppConstants.Success;
            response.AddModel(AppConstants.Model, Profile);
            //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
            return response;
        }



        public async Task<IdentityResponse> GetProfile(string UserId)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user == null)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.UnAuthorized;
                    response.AddError(AppConstants.Error, $"User with token not found.");
                    //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
                    return response;
                }
                var Profile = CreateProfileResponse(user);

                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.AuthResponse, Profile);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }


        }
        private AuthResponse CreateProfileResponse(User user)
        {
            return new AuthResponse
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                LogoImagePath = user.PhotoUrl,
                Name = user.Name,
                BirthDate = user.BirthDate,
                Mail = user.Mail
            };
        }

        public async Task<IdentityResponse> LogOut(string UserId)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user == null)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.UnAuthorized;
                    response.AddError(AppConstants.Error, $"User with token not found.");
                    //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
                    return response;
                }
                //delete tokens


                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.Model, true);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;


            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }
        public async Task<IdentityResponse> DeleteAccount(string UserId)
        {
            IdentityResponse response = new IdentityResponse();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user == null)
                {
                    response.clearBody();
                    response.StatusCode = AppConstants.UnAuthorized;
                    response.AddError(AppConstants.Error, $"User with token not found.");
                    //response.AddError(AppConstants.Code, AppConstants.User_with_token_not_found);
                    return response;
                }
                user.IsDeleted = true;
                await _userManager.UpdateAsync(user);
                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.Model, true);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;


            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }


        public async Task<IdentityResponse> AdminLogin(AdminAuthRequest request)
        {
            IdentityResponse response = new IdentityResponse();

            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"Admin with {request.Email} not found.");
                    //response.AddError(AppConstants.Code, AppConstants.This_Email_Not_Registerd_Before);
                    return response;
                }
                if (user.IsDeleted)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Error, $"Admin with {request.Email} Is Deleted.");
                    //response.AddError(AppConstants.Code, AppConstants.Admin_Is_Deleted);
                    return response;
                }
                var IsAdmin = await _userManager.IsInRoleAsync(user, AppConstants.RoleAdministrator);
                if (!IsAdmin)
                {
                    response.StatusCode = AppConstants.BadRequest;
                    response.AddError(AppConstants.Message, "You are Not Admin");
                    //response.AddError(AppConstants.Code, AppConstants.You_Are_Not_Admin);
                    return response;
                }

                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                AuthResponse model = CreateAuthResponse(user, jwtSecurityToken);

                response.StatusCode = AppConstants.Success;
                response.AddModel(AppConstants.AuthResponse, model);
                //response.AddMeta(AppConstants.Message, AppConstants.SuccessMessage);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = AppConstants.BadRequest;
                response.AddError(AppConstants.Error, ex.Message);
                response.AddError(AppConstants.Message, "An Error Occurred");
                //response.AddError(AppConstants.Code, AppConstants.Error_try_later);
                return response;
            }
        }

    }
}
