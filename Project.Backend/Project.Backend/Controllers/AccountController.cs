using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativeBackend.Application.Common.Models.Identity;
using Project.Backend.Constant;
using Project.Backend.Contracts.Identity;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        public AccountController(IAuthService authenticationService, IUserService userService, IWebHostEnvironment env)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _env = env;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            var response = await _authenticationService.Register(request);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AuthRequest request)
        {
            var response = await _authenticationService.Login(request);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest request)
        {
            //get user id from token 
            request.Id = _userService.UserId;
            var response = await _authenticationService.ChangePassword(request);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }



        //[HttpPost("Verify")]
        //public async Task<ActionResult> Verify(AuthRequest request)
        //{
        //    var response = await _authenticationService.Verify(request);
        //    switch (response.StatusCode)
        //    {
        //        case AppConstants.Success:
        //            return Ok(response.responsebody);
        //        case AppConstants.UnAuthorized:
        //            return Unauthorized(response.responsebody);
        //        case AppConstants.NotFound:
        //            return NotFound(response.responsebody);
        //        default:
        //            return BadRequest(response.responsebody);
        //    }
        //}

        [HttpGet("GetProfile")]
        [Authorize]
        public async Task<ActionResult> GetProfile()
        {
            string userId = _userService.UserId;
            var response = await _authenticationService.GetProfile(userId);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

        [HttpPost("EditProfile")]
        [Authorize]
        public async Task<ActionResult<bool>> EditProfile(EditProfileRequest request)
        {
            //get user id from token 
            request.userId = _userService.UserId;
            var response = await _authenticationService.EditProfile(request);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

        //[HttpPost("ChangePhoneNumberChecker")]
        //[Authorize]
        //public async Task<ActionResult<bool>> ChangePhoneNumberChecker(AuthRequest request)
        //{
        //    //get user id from token 
        //    var UserId = _userService.UserId;
        //    var response = await _authenticationService.ChangePhoneNumberChecker(request, UserId);
        //    switch (response.StatusCode)
        //    {
        //        case AppConstants.Success:
        //            return Ok(response.responsebody);
        //        case AppConstants.UnAuthorized:
        //            return Unauthorized(response.responsebody);
        //        case AppConstants.NotFound:
        //            return NotFound(response.responsebody);
        //        default:
        //            return BadRequest(response.responsebody);
        //    }
        //}

        //[HttpPost("ConfirmChangePhoneNumber")]
        //[Authorize]
        //public async Task<ActionResult<bool>> ConfirmChangePhoneNumber(AuthRequest request)
        //{
        //    //get user id from token 
        //    var UserId = _userService.UserId;
        //    var response = await _authenticationService.ConfirmChangePhoneNumber(request, UserId);
        //    switch (response.StatusCode)
        //    {
        //        case AppConstants.Success:
        //            return Ok(response.responsebody);
        //        case AppConstants.UnAuthorized:
        //            return Unauthorized(response.responsebody);
        //        case AppConstants.NotFound:
        //            return NotFound(response.responsebody);
        //        default:
        //            return BadRequest(response.responsebody);
        //    }
        //}

        [HttpPost("ChangeProfileImage")]
        [Authorize]
        public async Task<ActionResult<bool>> ChangeProfileImage([FromForm] IFormFile ProfileImage)
        {
            //get user id from token 
            string userId = _userService.UserId;
            Uri uri = new Uri($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}");
            string domain = uri.GetLeftPart(UriPartial.Authority);
            var webRootPath = _env.WebRootPath;
            var content = _env.ContentRootPath;
            var response = await _authenticationService.ChangeProfileImage(userId, ProfileImage, webRootPath, content, domain);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }

        }
        //[HttpPost("ChangeProfileLanguage/{language}")]
        //[Authorize]
        //public async Task<ActionResult<bool>> ChangeProfileLanguage(string language)
        //{
        //    //get user id from token 
        //    string userId = _userService.UserId;
        //    var response = await _authenticationService.ChangeProfileLanguage(userId, language);
        //    switch (response.StatusCode)
        //    {
        //        case AppConstants.Success:
        //            return Ok(response.responsebody);
        //        case AppConstants.UnAuthorized:
        //            return Unauthorized(response.responsebody);
        //        case AppConstants.NotFound:
        //            return NotFound(response.responsebody);
        //        default:
        //            return BadRequest(response.responsebody);
        //    }

        //}
        //[HttpPost("ChangeProfileSendNotifications/{send}")]
        //[Authorize]
        //public async Task<ActionResult<bool>> ChangeProfileLanguage(bool send)
        //{
        //    //get user id from token 
        //    string userId = _userService.UserId;
        //    var response = await _authenticationService.ChangeProfileSendNotifications(userId, send);
        //    switch (response.StatusCode)
        //    {
        //        case AppConstants.Success:
        //            return Ok(response.responsebody);
        //        case AppConstants.UnAuthorized:
        //            return Unauthorized(response.responsebody);
        //        case AppConstants.NotFound:
        //            return NotFound(response.responsebody);
        //        default:
        //            return BadRequest(response.responsebody);
        //    }

        //}

        [HttpGet("LogOut")]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            string userId = _userService.UserId;

            var response = await _authenticationService.LogOut(userId);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

        [HttpGet("DeleteAccount")]
        [Authorize]
        public async Task<ActionResult> DeleteAccount()
        {
            string userId = _userService.UserId;

            var response = await _authenticationService.DeleteAccount(userId);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

        [HttpPost("AdminLogin")]
        public async Task<ActionResult> AdminLogin(AdminAuthRequest request)
        {
            var response = await _authenticationService.AdminLogin(request);
            switch (response.StatusCode)
            {
                case AppConstants.Success:
                    return Ok(response.responsebody);
                case AppConstants.UnAuthorized:
                    return Unauthorized(response.responsebody);
                case AppConstants.NotFound:
                    return NotFound(response.responsebody);
                default:
                    return BadRequest(response.responsebody);
            }
        }

    }
}
