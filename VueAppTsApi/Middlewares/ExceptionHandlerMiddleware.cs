using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) when (ex is IBaseException exception)
            {
                _logger.LogError(exception.ToString());

                await HandleExceptionAsync(httpContext, exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                await HandleExceptionAsync(httpContext, new BadRequestException(ex.Message));

                // add HandleExceptionAsync for SQL exceptions
                // await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, IBaseException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.StatusCode = (int)exception.StatusCode;

            return context.Response.WriteAsync(
                JsonConvert.SerializeObject(new
                                                {
                                                    statusCode = context.Response.StatusCode,
                                                    title = exception.Title,
                                                    message = exception.Message,
                                                }));
        }
    }
}