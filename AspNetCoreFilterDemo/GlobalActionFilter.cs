using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreFilterDemo
{
    public class GlobalActionFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order => 0;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var factory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<GlobalActionFilter>();
            logger.LogWarning("全局ActionFilter执行之前");
            await next();
            logger.LogWarning("全局ActionFilter执行之后");
        }
    }
}
