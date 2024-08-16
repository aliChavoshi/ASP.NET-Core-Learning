namespace aspLearning.Middleware;

public class CustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //before request
        await context.Response.WriteAsync("Custom-Middleware-2 ");
        await next(context);
        await context.Response.WriteAsync("after-Custom-Middleware-2 ");
    }
}

public static class MyCustomMiddleware
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CustomMiddleware>();
    }
}