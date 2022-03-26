using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6
{
    public class LoggingMiddleware
    {
        private readonly ILogger<LoggingMiddleware> logger;
        private readonly RequestDelegate next;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var parentTraceId = context.Request.Headers["X-Trace-Id"];
            if (!string.IsNullOrEmpty(parentTraceId))
                context.Items["TraceId"] = parentTraceId;
            else
                context.Items["TraceId"] = Guid.NewGuid().ToString();
            await next(context);
        }
    }
}
