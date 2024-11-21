using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class HandleExceptionFilter : IAsyncExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        //TODO : exception handler
        //
        context.Result = new RedirectResult($"/Home/Error");
        //context.ExceptionHandled = true;
        return Task.CompletedTask;
    }
}