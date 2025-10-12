using Microsoft.Extensions.Caching.Memory;

namespace RepositoryPatternWebApi.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IMemoryCache memoryCache)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly IMemoryCache _memoryCache = memoryCache;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                _logger.LogInformation("Handling request: " + httpContext.Request.Path);
                await _next(httpContext);
                _logger.LogInformation("Finished handling request.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                //await HandleExceptionAsync(httpContext, ex);
            }
        }

        //private bool IsRequestAllowed(HttpContext context)
        //{
        //    var ip = context.Connection.RemoteIpAddress?.ToString();
        //    var cachKey = $"Rate:{ip}";
        //    var dateNow = DateTime.Now;

        //    var (timesTamp, count) = _memoryCache.GetOrCreate(cachKey, entry =>
        //    {
        //        entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
        //        return (timesTamp: dateNow, count: 0);
        //    });

        //    if (dateNow - timesTamp < _rateLimitWindow)
        //    {
        //        if (count >= 80)
        //        {
        //            return false;
        //        }
        //        _memoryCache.Set(cachKey, (timesTamp, count += 1), _rateLimitWindow);
        //    }
        //    else
        //    {
        //        _memoryCache.Set(cachKey, (dateNow, count), _rateLimitWindow);
        //    }
        //    return true;
        //}
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
