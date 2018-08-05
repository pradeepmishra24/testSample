using GlobalExceptions.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GlobalExceptions.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
     
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            ILogger _logger = loggerFactory.CreateLogger<ExceptionHandlerFeature>();
            app.UseExceptionHandler(appError => {

                appError.Run(async context => {

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        _logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }


                });
            });
        }

    }
}
