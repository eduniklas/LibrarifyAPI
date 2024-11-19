using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibrarifyAPI.Exception
{
    public class HandleException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            context.Result = 
                new ObjectResult(
                    new
                    {
                        message = "An error occurred",
                        details = exception.Message,
                    })
                    {
                        StatusCode = 500,
                    };
            context.ExceptionHandled = true;
        }
    }
}
