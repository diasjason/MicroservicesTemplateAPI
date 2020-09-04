using MicroservicesTemplate.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MicroservicesTemplate.Common.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //default error code
            var code = HttpStatusCode.InternalServerError;
            string resultString = null;

            if (ex is NotFoundException) code = HttpStatusCode.NotFound;
            else if (ex is ValidationException validationException)
            {
                var error = validationException.Errors;
                code = HttpStatusCode.BadRequest;
                resultString = JsonConvert.SerializeObject(new { message = validationException.Message, validationException.Errors });
            }

            var result = resultString ?? JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}