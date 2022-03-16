using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace logo_odev2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControllerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public AppVersionControllerMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                Version versionHeader = new Version(httpContext.Request.Headers["app-version"]);
                Version versionSettings = new Version(_config.GetValue<string>("AppVersion"));
                string path = httpContext.Request.Path;
                if (path.Equals("/api/Home/login") || path.Equals("/api/Home/register"))
                {
                    await _next(httpContext);
                }
                else if (versionHeader.CompareTo(versionSettings) > 0)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await httpContext.Response.WriteAsync("Beklenmeyen bir hata oluştu.");
                    return;
                }
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(ex.Message);
                return;
            }
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
