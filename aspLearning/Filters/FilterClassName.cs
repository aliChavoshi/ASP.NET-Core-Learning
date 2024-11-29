using Microsoft.AspNetCore.Mvc.Filters;

namespace aspLearning.Filters;

public class FilterClassName : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
    }

    
}