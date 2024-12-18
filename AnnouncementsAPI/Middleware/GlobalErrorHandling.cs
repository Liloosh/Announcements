
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AnnouncementsAPI.Middleware
{
    public class GlobalErrorHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ProblemDetails problemDetails = new ProblemDetails()
                {
                    Type = "Server error",
                    Status = 500,
                    Title = "Server error",
                    Detail = "Internal server error"
                };

                context.Response.ContentType = "application/json";
                var body = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(body);
            }
        }
    }

    public static class GlobalErrorHandlingExtension
    {
        public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalErrorHandling>();
        }

    }
}
