using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class AddCustomHeaderFilter : IAsyncAlwaysRunResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        //add header before sending response
        context.HttpContext.Response.Headers.Add("X-Custom-Header", "Always run result");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        //
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        //before send request to client
        await next();
        //after send request to client
    }
}