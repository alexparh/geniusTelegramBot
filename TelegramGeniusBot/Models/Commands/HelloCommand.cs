﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramGeniusBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }

    }
}