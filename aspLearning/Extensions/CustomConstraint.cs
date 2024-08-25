namespace aspLearning.Extensions;

public class CustomConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        throw new NotImplementedException();
    }
}