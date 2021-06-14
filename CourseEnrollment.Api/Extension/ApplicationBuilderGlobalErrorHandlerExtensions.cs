using CourseEnrollment.Api.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CourseEnrollment.Api.Extension
{
    public static class ApplicationBuilderGlobalErrorHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalErrorHandlerMiddleware>();
        }
    }
}
