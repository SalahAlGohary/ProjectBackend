public class CustomTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public CustomTokenMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context)
    {
        var customTokenHeader = context.Request.Headers["X-Custom-Token"].FirstOrDefault();
        if (!string.IsNullOrEmpty(customTokenHeader))
        {
            var token = $"Bearer {customTokenHeader}"; // Replace with your logic to retrieve the token
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Request.Headers.Remove("Authorization");
            }
            context.Request.Headers.Add("Authorization", token);
        }

        await _next(context);
    }
}