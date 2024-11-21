using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class CourseIndexActionFilter(ILogger<CourseIndexActionFilter> logger) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation("called before action");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("calling after action");
    }
}