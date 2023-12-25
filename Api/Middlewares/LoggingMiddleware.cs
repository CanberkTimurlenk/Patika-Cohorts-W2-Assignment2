namespace ECommerceApi.Middlewares
{
    public class EndpointLoggingMiddleware
    {
        // This middleware logs the endpoint information of the request.

        private readonly RequestDelegate _next;
        private readonly ILogger<EndpointLoggingMiddleware> _logger;

        public EndpointLoggingMiddleware(RequestDelegate next, ILogger<EndpointLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var path = context.Request.Path;

            // logs middleware is working
            _logger.LogError("Logging Middleware worked !");

            if (endpoint != null)
            {
                // if endpoint is not null, it means the request matched


                var endpointName = endpoint.DisplayName;

                // Log Level could be adjusted according to the needs
                _logger.LogError($"Endpoint Name: {endpointName}");

            }
            else
            {
                // Endpoint is null, so the request didn't match anything.

                // Log Level could be adjusted according to the needs
                _logger.LogError($"Request Path: {path}");
                _logger.LogError("Endpoint information not available.");
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
