using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InformationSystemServer.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            finally 
            {
                var ip = context.Connection.RemoteIpAddress.ToString();
                var method = context.Request.Method;
                var path = context.Request?.Path;
                var protocol = context.Request.Protocol;
                var host = context?.Request.Host;
                var statusCode = context.Response?.StatusCode;

                this.logger.LogInformation(
                    "Request {method}, {url}, {ip}, {protocol}, {host} => {statusCode}",
                    method, path, ip, protocol, host, statusCode);
            }
        }
    }
}
