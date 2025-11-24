using System.Net;
using System.Text.Json;

namespace Day5_ErrorHandling_And_Logging.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass to the next middleware / endpoint
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex, "Unhandled exception occurred");

                // Return consistent JSON error response
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var problem = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred. Please try again later.",
                    Detail = ex.Message // in real prod, you might hide this
                };

                var json = JsonSerializer.Serialize(problem);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
