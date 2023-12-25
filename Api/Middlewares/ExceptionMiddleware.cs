using ECommerceApi.Exceptions;
using ECommerceApi.Models;

namespace ECommerceApi.Middlewares
{
    public class ExceptionMiddleware
    {
        // catch exception and also log it

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // logs middleware is working
                _logger.LogError("Exception Middleware worked !");
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                // exception types could be added in the future
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };


            var errorDetails = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };


            // log the exception
            _logger.LogError($"{exception.Message}");
            _logger.LogError(errorDetails.ToString());

            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
