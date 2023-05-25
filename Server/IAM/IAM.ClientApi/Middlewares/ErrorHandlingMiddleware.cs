using IAM.ClientApi.ActionResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace IAM.ClientApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an appropriate error response
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = new IamError
            {
                ErrorMessage = exception.Message,
                StatusCode = HttpStatusCode.InternalServerError,
            };

            var json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsJsonAsync(json);
        }
    }
}
