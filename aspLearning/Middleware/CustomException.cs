namespace aspLearning.Middleware;

public class CustomException : Exception
{
    public int StatusCode;
    public CustomException() : base()
    {
    }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public CustomException(string message,int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}