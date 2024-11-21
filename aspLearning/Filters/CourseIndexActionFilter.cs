using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class CourseIndexActionFilter(ILogger<CourseIndexActionFilter> logger) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("name", out var name))
        {
            var myName = name?.ToString();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("calling after action");
    }
}