using CorrelationId.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        [HttpGet]
        [Route("Test1")]
        public IEnumerable<WeatherForecast> Test1()
        {
            _logger.LogInformation(_accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString());
            _logger.LogInformation("Test1");
            AAA();
            BBB();
            return new List<WeatherForecast>();
        }


        private void AAA()
        {
            _logger.LogInformation("AAA");
        }

        private void BBB()
        {
            _logger.LogInformation("BBB");
        }
    }
}
