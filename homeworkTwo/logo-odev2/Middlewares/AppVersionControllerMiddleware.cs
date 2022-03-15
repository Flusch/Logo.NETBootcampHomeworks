using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace logo_odev2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControllerMiddleware
    {
        private readonly RequestDelegate _next;

        public AppVersionControllerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionControllerMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControllerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControllerMiddleware>();
        }
    }
}
