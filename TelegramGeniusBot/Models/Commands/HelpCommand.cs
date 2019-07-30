using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramGeniusBot.Models.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "help";

        public override async void ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            status.Add(chatId, true);
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Send me artist and song. \nPlease use this format: Artist - song ", replyToMessageId: messageId);
        }

        public override void GetInfo(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}