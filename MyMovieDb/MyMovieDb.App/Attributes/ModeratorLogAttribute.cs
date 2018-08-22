using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.App.Attributes
{
    public class ModeratorLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //TODO
        }
    }
}
