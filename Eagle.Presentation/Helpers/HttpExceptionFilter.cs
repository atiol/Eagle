using Eagle.Common.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Serilog;
using System.Collections.Generic;

namespace Eagle.Presentation.Helpers
{
    public class HttpExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) 
        {
            var logger = context.HttpContext.RequestServices
                .GetService(typeof(ILogger)) as ILogger;
            var stringLocalizer = context.HttpContext.RequestServices
                .GetService(typeof(IStringLocalizer<string>)) as IStringLocalizer<string>;

            var exception = context.Exception;

            var customException = CustomExceptions.Unknown;
            var response = new ResponseModel(false, CustomExceptions.Unknown.Message);

            if (exception != null)
            {
                if (exception is CustomException || exception is CustomException<IEnumerable<string>>)
                {
                    customException = exception as CustomException;
                    response = new ResponseModel(false, customException.Message);
                    context.HttpContext.Response.StatusCode = customException.StatusCode;

                    //logger.Error(customException.Message);
                }
                else
                {
                    context.HttpContext.Response.StatusCode = 500;
                    response = new ResponseModel(false, customException.Message);
                    //logger.Error(exception.Message);
                }
            }

            context.Result = new JsonResult(response);
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
