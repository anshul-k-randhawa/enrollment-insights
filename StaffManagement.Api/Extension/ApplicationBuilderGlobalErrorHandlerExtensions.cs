using Microsoft.AspNetCore.Builder;
using StaffManagement.Api.Middleware;

namespace StaffManagement.Api.Extension
{
    public static class ApplicationBuilderGlobalErrorHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalErrorHandlerMiddleware>();
        }
    }
}
