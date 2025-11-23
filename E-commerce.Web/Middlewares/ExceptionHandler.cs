using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace E_commerce.Web.Middlewares;

public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request - End Point",
                    Detail = $"End point{context.Request.Path} Was Not Found",
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status404NotFound
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
        catch (Exception ex)
        {
            // Logging
            logger.LogError(ex, "Something went wrong: {Message}", ex.Message);

            // Create problem details response
            var problem = new ProblemDetails
            {
                Title = "Error Processing The HTTP Request",
                Detail = ex.Message,
                Instance = context.Request.Path,
                Status = ex switch
                {


                    NotFoundException=>StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                }
            };

            context.Response.StatusCode = problem.Status.Value;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}