using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramGeniusBot.Models.Commands;

namespace TelegramGeniusBot.Models
{
    public static class Bot //for initial bot initialization
    {
        private static TelegramBotClient client;
        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            commandList.Add(new HelpCommand());
            commandList.Add(new StartCommand());
            //Add more commands
            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}