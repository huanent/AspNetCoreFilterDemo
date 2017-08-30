using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNetCoreFilterDemo.Controllers
{
    [Route("api/[controller]")]
    [ControllerActionFilter(Order =-1)]
    public class ValuesController : Controller
    {
        ILoggerFactory _factory;
        public ValuesController(ILoggerFactory factory)
        {
            _factory = factory;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = _factory.CreateLogger<ValuesController>();
            logger.LogWarning("Controller内部重写的actionFinter执行前");
            await next();
            logger.LogWarning("Controller内部重写的actionFinter执行后");
        }

        // GET api/values
        [HttpGet]
        [ActionActionFilter(Order =-2)]
        public IEnumerable<string> Get()
        {
            var logger = _factory.CreateLogger<ValuesController>();
            logger.LogWarning("action执行中");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
