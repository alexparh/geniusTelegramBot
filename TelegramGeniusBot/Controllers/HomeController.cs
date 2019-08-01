using System.Web.Mvc;

namespace TelegramGeniusBot.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "@GeniusLyricsAndMoreBot for telegram";
        }
    }
}