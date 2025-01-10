namespace HRMS.Handler
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
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
           
                _logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
            }

            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
                await HandleExceptionAsync(context, new Exception("Bad Request - The request could not be understood or was missing required parameters."), StatusCodes.Status400BadRequest);
            }
            else if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                await HandleExceptionAsync(context, new Exception("Unauthorized - Authentication is required and has failed or has not yet been provided."), StatusCodes.Status401Unauthorized);
            }
            else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await HandleExceptionAsync(context, new Exception("Forbidden - You do not have permission to access this resource."), StatusCodes.Status403Forbidden);
            }
            else if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await HandleExceptionAsync(context, new Exception("Not Found - The requested resource could not be found."), StatusCodes.Status404NotFound);
            }
            else if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
            {
                await HandleExceptionAsync(context, new Exception("Method Not Allowed - The HTTP method is not supported for the requested resource."), StatusCodes.Status405MethodNotAllowed);
            }
            else if (context.Response.StatusCode == StatusCodes.Status503ServiceUnavailable)
            {
                await HandleExceptionAsync(context, new Exception("Service Unavailable - The server is currently unable to handle the request, please try again later."), StatusCodes.Status503ServiceUnavailable);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                message = exception.Message, 
                statusCode = statusCode      
            };

            return context.Response.WriteAsJsonAsync(response); // Return error as JSON
        }
    }
}
