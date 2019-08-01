using GeniusParser.Core;
using GeniusParser.Core.Genius;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramGeniusBot.Models.Commands
{
    internal static class Lyrics
    {

        public static async void SendLyricsAsync(Message message, TelegramBotClient client)
        {
            ParserWorker<string> parser;

            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            string[] fullinfo = message.Text.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            string artist = fullinfo[0];
            string song = fullinfo[1];
            try//parse
            {
                parser = new ParserWorker<string>(
                         new GeniusParser.Core.Genius.GeniusParser()
                         );
                parser.OnNewData += Parser_OnNewData;
                parser.Settings = new GeniusSettings(artist, song);
                parser.Start();
            }
            catch
            {
                await client.SendTextMessageAsync(chatId, "Sorry, I can not find this song", replyToMessageId: messageId);
            }

            async void Parser_OnNewData(object arg1, string arg2)
            {
                try
                {
                    await client.SendTextMessageAsync(chatId, arg2, replyToMessageId: messageId);
                }
                catch
                {
                    await client.SendTextMessageAsync(chatId, "Sorry, I can not find this song", replyToMessageId: messageId);
                }
            }
        }
    }
}