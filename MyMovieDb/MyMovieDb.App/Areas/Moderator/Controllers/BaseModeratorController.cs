using System;
using System.Linq;
using log4net;
using Microsoft.AspNetCore.Http;
using MyMovieDb.App.Controllers;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.App.Areas.Moderator.Controllers
{
    public abstract class BaseModeratorController : BaseController
    {
        private string loggedInUserName;
        private IHttpContextAccessor contextAccessor;
        private readonly ILog logger;


        protected BaseModeratorController(IHttpContextAccessor contextAccessor)
        {
            this.loggedInUserName = contextAccessor.HttpContext.User.Identity.Name;
            this.contextAccessor = contextAccessor;
            this.logger = LogManager.GetLogger(typeof(BaseModeratorController));
        }

        protected void LogResult(BaseModel model)
        {
            var urlArgs = this.contextAccessor.HttpContext
                .Request
                .Path
                .ToString()
                .Split('/');

            var action = urlArgs[3].ToLower().TrimEnd('e');
            var entity = urlArgs[2].TrimEnd('s');

            if (!model.HasError)
            {
                var message = $"User: {loggedInUserName} {action}ed {entity} with ID: {model.Id} on {DateTime.Now.ToString("O")}";
                this.logger.Info(message);
            }
            else
            {
                var appender = model.Id != null ? $"with ID: {model.Id} " : string.Empty;
                var message =
                    $"User: {loggedInUserName} failed to {action} {entity} {appender}on {DateTime.Now.ToString("O")}";
                this.logger.Warn(message);
            }
        }
    }
}
