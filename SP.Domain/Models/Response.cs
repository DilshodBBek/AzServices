namespace SP.Domain.Models;

public class Response<T>
{
    public Response(string error, int statusCode = 400)
    {
        Errors = error;
        StatusCode = statusCode;
    }

    public Response(T result)
    {
        Result = result;
        Errors = null;
    }

    public int StatusCode { get; set; } = 200;
    public string Errors { get; set; }
    public T Result { get; set; }
}
