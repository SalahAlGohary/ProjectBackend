using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativeBackend.Application.Common.Models.Identity;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Identity;
using Project.Backend.Models.Dtos;
using System.Web;
using Tweetinvi;
using Tweetinvi.Auth;
using Tweetinvi.Parameters;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string ConsumerKey;
        private readonly string ConsumerSecret;
        private readonly IUserService _userService;
        private static readonly IAuthenticationRequestStore _myAuthRequestStore = new LocalAuthenticationRequestStore();
        private readonly IAuthService _authenticationService;
        private readonly IOAuthTokenUserRepository _IOAuthTokenUserRepository;

        public AuthController(IConfiguration configuration,
            IUserService userService,
            IAuthService authenticationService,
            IOAuthTokenUserRepository iOAuthTokenUserRepository)
        {
            _configuration = configuration;
            _userService = userService;
            ConsumerKey = configuration.GetSection("Twitter").Get<TwitterSetting>().CId;
            ConsumerSecret = configuration.GetSection("Twitter").Get<TwitterSetting>().CSecret;
            _authenticationService = authenticationService;
            _IOAuthTokenUserRepository = iOAuthTokenUserRepository;

        }
        [HttpGet("getlink")]
        [Authorize]
        public async Task<ActionResult> TwitterAuth()
        {
            var userIdString = _userService.UserId;
            var userId = new Guid(userIdString);
            var appClient = new TwitterClient(ConsumerKey, ConsumerSecret);
            var authenticationRequestId = Guid.NewGuid().ToString();
            var redirectPath = Request.Scheme + "://" + Request.Host.Value + $"/api/Auth/signin-twitter";

            // Add the user identifier as a query parameters that will be received by `ValidateTwitterAuth`
            var redirectURL = _myAuthRequestStore.AppendAuthenticationRequestIdToCallbackUrl(redirectPath, authenticationRequestId);
            // Initialize the authentication process
            var authenticationRequestToken = await appClient.Auth.RequestAuthenticationUrlAsync(redirectURL);

            await _myAuthRequestStore.AddAuthenticationTokenAsync(authenticationRequestId, authenticationRequestToken);
            string token = ExtractOAuthToken(authenticationRequestToken.AuthorizationURL);
            await _IOAuthTokenUserRepository.AddOAuthTokenToUser(userId, token);
            // Store the token information in the store
            // Redirect the user to Twitter
            return Ok(authenticationRequestToken.AuthorizationURL);
        }

        [HttpGet("signin-twitter")]
        //[Authorize]
        public async Task<ActionResult> signin_twitter()
        {

            //var userIdString = _userService.UserId;
            //var userId = new Guid(userIdString);
            //await _IOAuthTokenUserRepository.AddOAuthTokenToUser();
            var appClient = new TwitterClient(ConsumerKey, ConsumerSecret);
            var bearerToken = await appClient.Auth.CreateBearerTokenAsync();


            // Extract the information from the redirection url
            var requestParameters = await RequestCredentialsParameters.FromCallbackUrlAsync(Request.QueryString.Value, _myAuthRequestStore);
            string token = ExtractOAuthToken(requestParameters.AuthRequest.AuthorizationURL);
            var userAuth = await _IOAuthTokenUserRepository.GetByToken(token);
            // Request Twitter to generate the credentials.
            var userCreds = await appClient.Auth.RequestCredentialsAsync(requestParameters);

            // Congratulations the user is now authenticated!
            var userClient = new TwitterClient(userCreds);
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            //var publishedTweet = await userClient.Tweets;
            EditProfileRequest editProfile = new EditProfileRequest();
            editProfile.userId = userAuth.UserId.ToString();
            editProfile.TwitterUserName = user.ScreenName;
            await _authenticationService.EditProfile(editProfile);

            //string json = JsonSerializer.Serialize(user);
            return Ok(user.ScreenName);
        }
        public static string ExtractOAuthToken(string url)
        {
            // Parse the URL
            Uri uri = new Uri(url);

            // Get the query parameters
            var queryParameters = HttpUtility.ParseQueryString(uri.Query);

            // Retrieve the value of the "oauth_token" parameter
            string oauthToken = queryParameters["oauth_token"];

            return oauthToken;
        }
    }
}
