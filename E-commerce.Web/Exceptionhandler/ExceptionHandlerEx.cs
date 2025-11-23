using E_commerce.Web.Middlewares;
using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Web.Exceptionhandler
{
    public class ExceptionHandlerEx(ILogger<ExceptionHandlerEx> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
        {
            logger.LogError(ex, "Something went wrong: {Message}", ex.Message);

            if (ex is NotFoundException notFound)
            {
                var problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request",
                    Detail = ex.Message,
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status404NotFound
                   
                };

                context.Response.StatusCode = problem.Status.Value;
                await context.Response.WriteAsJsonAsync(problem, cancellationToken);
                return true;
            }
            return false;
        }
    }
}
