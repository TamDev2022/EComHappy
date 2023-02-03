using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            //httpContext.Response.StatusCode = exception switch
            //{
            //    BadRequestException => StatusCodes.Status400BadRequest,
            //    NotFoundException => StatusCodes.Status404NotFound,
            //    _ => StatusCodes.Status500InternalServerError
            //};
            httpContext.Response.StatusCode = StatusCodes.Status200OK;

            await httpContext.Response.WriteAsJsonAsync(new { success = false, message = exception.Message });
        }
    }
}
