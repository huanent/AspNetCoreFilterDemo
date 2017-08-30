using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreFilterDemo
{
    public class ControllerActionFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var factory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<GlobalActionFilter>();
            logger.LogWarning("ControllerActionFilter执行之前");
            await next();
            logger.LogWarning("ControllerActionFilter执行之后");
        }
    }
}
