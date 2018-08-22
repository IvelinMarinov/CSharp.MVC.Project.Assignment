using System.Net;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace MyMovieDb.App.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILog _logger = LogManager.GetLogger(typeof(GlobalExceptionFilter));

        public GlobalExceptionFilter(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public void OnException(ExceptionContext context)
        {
            _logger.Error(context.Exception);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            var serializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

            context.Result = _hostingEnvironment.IsDevelopment() ?
                new JsonResult(context.Exception, serializerSettings) :
                new JsonResult(new { Error = "A server error occurred. Please contact your system administrator." }, serializerSettings);
        }
    }
}
