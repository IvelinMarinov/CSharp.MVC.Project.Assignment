using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Helpers.Messages;

namespace MyMovieDb.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void SetMessage(MessageType type, string text)
        {
            TempData[Constants.MessageText] = text;
            TempData[Constants.MessageType] = type.ToString();
        }
    }
}