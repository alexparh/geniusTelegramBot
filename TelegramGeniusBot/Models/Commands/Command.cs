using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramGeniusBot.Models.Commands
{
    public abstract class Command
    {
        public Dictionary<long, bool> status = new Dictionary<long, bool>();
        public static int i;
        public abstract string Name { get; }
        public abstract void ExecuteAsync(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

    }
}