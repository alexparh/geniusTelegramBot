using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramGeniusBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            status.Add(chatId, true);
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Send me artist and song. \nPlease use this format: Artist - song ", replyToMessageId: messageId);
        }
    }
}