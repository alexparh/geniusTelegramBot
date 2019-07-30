using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramGeniusBot.Models;

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

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await Task.Run(() => command.ExecuteAsync(message, client));
                    return Ok();
                }
            }

            if (message.Text.Contains(" - "))
            {
                await Task.Run(() => commands[1].ExecuteAsync(message, client));
                return Ok();
            }

            return Ok();
        }
    }
}
