using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramGeniusBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://telegramgeniusbot.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "GeniusLyricsAndMoreBot";

        public static string Key { get; set; } = "uniq token feature2";
    }
}