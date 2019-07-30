using GeniusParser.Core;
using GeniusParser.Core.Genius;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramGeniusBot.Models.Commands
{
    public class LyricsCommand : Command
    {
        public override string Name => "lyrics";

        string song;
        string artist;

        ParserWorker<string> parser;

        public override async void ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            status.Add(chatId, true);
            var messageId = message.MessageId;
            string[] fullinfo = message.Text.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            artist = fullinfo[0];
            song = fullinfo[1];
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
                parser.Abort();
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

        public override void GetInfo(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}