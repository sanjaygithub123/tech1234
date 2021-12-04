using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Pms.Core.Logging;

namespace ProductMicroservice.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private const string HtmlErrorAction = "Index";
        private const string HtmlErrorController = "Error";

        public void OnException(ExceptionContext context)
        {
            try
            {
                //Log.Error(context.Exception, "Unhandled exception reached global exception filter");

                context.ExceptionHandled = true;

                RequestHeaders requestHeaders = context.HttpContext.Request.GetTypedHeaders();
               // bool isApiRequest = requestHeaders.Accept != null && requestHeaders.Accept.Contains(new MediaTypeHeaderValue(ContentType.Json));

                // context.Result = isApiRequest
                //     ? SecurityUtility.ApiFailureResult
                //     : new RedirectToActionResult(HtmlErrorAction, HtmlErrorController, new { statusCode = (int)HttpStatusCode.BadRequest, loc = LocaleUtility.ToLocaleString(HandlerContext.Request.Locale) });
            context.Result= new BadRequestObjectResult("Exception has been raised on server") as IActionResult;
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Exception thrown and handled in global exception filter");
                context.Result = new BadRequestObjectResult("Your request could not be processed. Please check the request information.");
            }
        }
    }
}
