using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Attributes;

public class MyExceptionAttribute : ActionFilterAttribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context is { ExceptionHandled: false, Exception: FormatException })
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.WriteAsync("<h1>Sorry</h1>" + context.Exception.Message);
        }
    }
}