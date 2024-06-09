using System.Net;
using System.Text.Json;

namespace MultiShop.Order.Presentation.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            ErrorResult errorResult = new()
            {
                Message = e.Message,
                StatusCode = context.Response.StatusCode
            };
            string json = JsonSerializer.Serialize(errorResult);
            await context.Response.WriteAsync(json);
        }
    }
}

public class ErrorResult
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
}