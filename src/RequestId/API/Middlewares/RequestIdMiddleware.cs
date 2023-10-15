namespace API.Middlewares;
using API.Common;

public class RequestIdMiddleware
{
    private readonly RequestDelegate _next;
    
    public RequestIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, SessionData sessionData)
    {
        sessionData.RequestId = context.Request.Headers["X-Request-Id"];
        
        await _next(context);
    }
}