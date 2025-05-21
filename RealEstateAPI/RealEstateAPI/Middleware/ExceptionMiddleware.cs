﻿using System.Net;
using System.Text.Json;

namespace RealEstateAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, "Unhandled exception caught in middleware");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex is InvalidOperationException
                    ? (int)HttpStatusCode.BadRequest
                    : (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    error = ex.Message,
                    detail = ex.GetType().Name
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
