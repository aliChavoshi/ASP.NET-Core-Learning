namespace aspLearning.Middleware;

public class ConventionalMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync("Conventional");
        await next(context);
    }
}