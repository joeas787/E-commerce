using E_Commerce.ServiceAbstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.presentation.API.Attributes
{
    internal class CashAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();

           
            string key = GenerateCashKey(context.HttpContext.Request);
            var cashValue = await cashService.GetAsync(key);
            if (cashValue != null)
            {
                // Return Response & don't invoke the Action
                context.Result = new ContentResult
                {
                    Content = cashValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }

          
            var actionExecutedContext = await next.Invoke();
            var result = actionExecutedContext.Result;

           
            if (result is OkObjectResult okResult)
            
                await cashService.SetAsync(key, okResult.Value!,TimeSpan.FromMinutes(2));
            
        }

        private string GenerateCashKey(HttpRequest request)
        {
            var sb =new StringBuilder();
            foreach (var kvp in request.Query.OrderBy(p=>p.Key)) 
                sb.Append($"{kvp.Key}-{kvp.Value}-");
           return sb.ToString().Trim('-');
        }
    }
}
