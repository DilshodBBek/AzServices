using System.Net;

namespace Identity.ExceptionHandler;

public class ExceptionMiddlerWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddlerWare> _logger;

    public ExceptionMiddlerWare(RequestDelegate next, ILogger<ExceptionMiddlerWare> logger = null)
    {
        _next = next;
        _logger = logger;

    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            await _next(context);
        }
        catch (Exception ex)
        {

            _logger.LogError($"An unhandled exception occurred: {ex}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorMessage = new { error = "Tizimda Xatolik sodir bo`ldi." };
            await context.Response.WriteAsync(errorMessage.ToString());
        }

    }
}
