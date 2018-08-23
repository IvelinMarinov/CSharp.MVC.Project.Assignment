using System;
using System.Text;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyMovieDb.App.Attributes
{
    public class TraceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var builder = new StringBuilder();

            builder.AppendFormat("Date: {0} ", DateTime.Now.ToString("O"));

            builder.AppendFormat(";{0}", filterContext.HttpContext.Request.Path);

            builder.Append(Environment.NewLine);

            ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Log.Debug(builder.ToString());
        }
    }
}
