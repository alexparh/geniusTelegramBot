using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramGeniusBot.Models;
using TelegramGeniusBot.Models.Commands;

namespace TelegramGeniusBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]//webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            if (message.Text.Contains(" - "))
            {
                await Task.Run(() => Lyrics.SendLyricsAsync(message, client));
                return Ok();
            }
            else
            {
                foreach (var command in commands)
                {
                    if (command.Contains(message.Text))
                    {
                        await Task.Run(() => command.ExecuteAsync(message, client));
                        return Ok();
                    }
                }
            }

            return Ok();
        }
    }
}
