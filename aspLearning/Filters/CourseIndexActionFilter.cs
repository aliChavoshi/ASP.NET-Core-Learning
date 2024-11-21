using aspLearning.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class CourseIndexActionFilter(string key, string value) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var hasArguments = context.ActionArguments.TryGetValue("filter", out var filter);
        if (hasArguments)
        {
            context.HttpContext.Items["filter"] = filter;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Controller is CoursesController controller)
        {
            if (context.HttpContext.Items.TryGetValue("filter", out var value))
            {
                controller.ViewData["filter"] = value as string;
            }
        }
    }
}