using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SmartB.API.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;

            _logger.Error(exception);
            var code = HttpStatusCode.InternalServerError;
            if (context.Request.Headers["x-requested-with"] == "XMLHttpRequest")
                await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
            else
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(
                    "Error message: " +
                    exception.Message);
            }
        }

        private async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name
                }
            })).ConfigureAwait(false);
        }
    }
}
