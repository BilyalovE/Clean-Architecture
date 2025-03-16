using System.Net;
using Application;
using Microsoft.AspNetCore.Http.Extensions;

namespace WebApp;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpCcontext)
    {
        try
        {
            await _next(httpCcontext);
        }
        catch (EntityNotFoundException e)
        {
            httpCcontext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}