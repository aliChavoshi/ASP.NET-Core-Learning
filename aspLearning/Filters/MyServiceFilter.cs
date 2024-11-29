using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class MyServiceFilter(ILogger<MyServiceFilter> logger) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation("Action is executing : {ActionName}", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("Action is executed : {ActionName}", context.ActionDescriptor.DisplayName);
    }
}