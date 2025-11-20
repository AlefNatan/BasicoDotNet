using FluentValidation;
using System.Text.Json;

namespace Bernhoeft.GRT.Teste.Api.Handlers
{
    public class ValidationExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ValidationExceptionHandler> _logger;

        public ValidationExceptionHandler(RequestDelegate next, ILogger<ValidationExceptionHandler> logger)
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
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Mensagens = exception.Errors.Select(error => error.ErrorMessage).ToList()
            };

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}