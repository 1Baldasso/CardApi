﻿using System.Net;

namespace DesafioAda.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
