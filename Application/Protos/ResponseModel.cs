using System.Net;

namespace Application.Model;

public class ResponseModel<T>
{
    public ResponseModel(T result, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Result = result;
        StatusCode = statusCode;
    }

    public ResponseModel(string? error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        Error = error;
        StatusCode = statusCode;
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string? Error { get; set; }
    public T Result { get; set; }
}
