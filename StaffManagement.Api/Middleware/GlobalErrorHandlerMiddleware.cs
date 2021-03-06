using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StaffManagement.Api.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = $"Message: {ex.Message}",
                    ErrorType = ex.GetType().ToString()
                }.ToString());

                _logger.LogError(ex, "Error caught by Global Error Handler");
            }
        }
    }
}
