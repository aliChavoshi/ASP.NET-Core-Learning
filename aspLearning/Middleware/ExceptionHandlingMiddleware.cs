namespace aspLearning.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //run program
            await next(context); //error
        }
        catch (CustomException exception)
        {
            logger.LogError("{ExceptionType} {ExceptionMessage} {StatusCode}", exception.GetType().ToString(),
                exception.Message, exception.StatusCode);
        }
        catch (Exception e)
        {
            logger.LogError("{ExceptionType} {ExceptionMessage}", e.GetType().ToString(), e.Message);
        }
    }
}

public static class ExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}