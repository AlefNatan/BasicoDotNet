using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bernhoeft.GRT.Core.Models;

namespace Bernhoeft.GRT.Teste.Api.Handlers
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ValidationException validationException)
            {
                var errors = validationException.Errors
                    .Select(e => e.ErrorMessage)
                    .Distinct()
                    .ToList();

                var result = OperationResult<bool>.ReturnBadRequest();
                result.AddMessage(errors);

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
                return true;
            }

            return false;
        }
    }
}