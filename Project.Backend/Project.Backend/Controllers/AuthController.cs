using Microsoft.AspNetCore.Mvc;
using Project.Backend.Models.Dtos;
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
        private static readonly IAuthenticationRequestStore _myAuthRequestStore = new LocalAuthenticationRequestStore();
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConsumerKey = configuration.GetSection("Twitter").Get<TwitterSetting>().CId;
            ConsumerSecret = configuration.GetSection("Twitter").Get<TwitterSetting>().CSecret;
        }
        [HttpGet("getlink")]
        public async Task<ActionResult> TwitterAuth()
        {
            var appClient = new TwitterClient(ConsumerKey, ConsumerSecret);
            var authenticationRequestId = Guid.NewGuid().ToString();
            var redirectPath = Request.Scheme + "://" + Request.Host.Value + $"/api/Auth/signin-twitter";

            // Add the user identifier as a query parameters that will be received by `ValidateTwitterAuth`
            var redirectURL = _myAuthRequestStore.AppendAuthenticationRequestIdToCallbackUrl(redirectPath, authenticationRequestId);
            // Initialize the authentication process
            var authenticationRequestToken = await appClient.Auth.RequestAuthenticationUrlAsync(redirectURL);
            // Store the token information in the store
            await _myAuthRequestStore.AddAuthenticationTokenAsync(authenticationRequestId, authenticationRequestToken);

            // Redirect the user to Twitter
            return Ok(authenticationRequestToken.AuthorizationURL);
        }

        [HttpGet("signin-twitter")]
        public async Task<ActionResult> signin_twitter()
        {
            var appClient = new TwitterClient(ConsumerKey, ConsumerSecret);
            var bearerToken = await appClient.Auth.CreateBearerTokenAsync();


            // Extract the information from the redirection url
            var requestParameters = await RequestCredentialsParameters.FromCallbackUrlAsync(Request.QueryString.Value, _myAuthRequestStore);
            // Request Twitter to generate the credentials.
            var userCreds = await appClient.Auth.RequestCredentialsAsync(requestParameters);

            // Congratulations the user is now authenticated!
            var userClient = new TwitterClient(userCreds);
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            //var publishedTweet = await userClient.Tweets;

            //string json = JsonSerializer.Serialize(user);
            return Ok(user.Name);
        }
    }
}
