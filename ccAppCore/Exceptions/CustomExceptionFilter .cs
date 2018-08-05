using GlobalExceptions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ccAppCore.Exceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ErrorDetails ErrObj = new ErrorDetails();
            ErrObj.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrObj.Message = string.Empty;

            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                ErrObj.Message = "Unauthorized Access";
                ErrObj.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                ErrObj.Message = "A server error occurred.";
                ErrObj.StatusCode = (int)HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(MyAppException))
            {
                ErrObj.Message = context.Exception.ToString();
                ErrObj.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                ErrObj.Message = context.Exception.Message;
                ErrObj.StatusCode = (int)HttpStatusCode.NotFound;
            }
            context.ExceptionHandled = true;

            context.HttpContext.Response.WriteAsync(ErrObj.ToString());

           



            
        }
    }
}
