using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebService.Middleware
{
    public static class RequestLoggerExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;

        public RequestLoggerMiddleware(RequestDelegate requestDelegate, ILoggerFactory loggerFactory)
        {
            _requestDelegate = requestDelegate;
            _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(await FormatRequest(context.Request));
            
            await _requestDelegate(context);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return $"{request.Scheme} {request.Host} {request.Path} {request.QueryString} {bodyAsText}";
        }
    }
}
