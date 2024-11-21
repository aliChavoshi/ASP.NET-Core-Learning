using aspLearning.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class CourseIndexActionFilter(string key, string value, int order) : IAsyncActionFilter ,IOrderedFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var hasArguments = context.ActionArguments.TryGetValue("filter", out var filter);
        if (hasArguments)
        {
            context.HttpContext.Items["filter"] = filter;
        }
    }

    public void OnActionExecuted(ActionExecutingContext context)
    {
        if (context.Controller is CoursesController controller)
        {
            if (context.HttpContext.Items.TryGetValue("filter", out var value))
            {
                controller.ViewData["filter"] = value as string;
            }
        }
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //before
        OnActionExecuting(context); //Global > Controller > Action
        await next(); //   Executing
        OnActionExecuted(context); // Action > Controller > Global
        //next
    }

    public int Order { get; } = order;
}