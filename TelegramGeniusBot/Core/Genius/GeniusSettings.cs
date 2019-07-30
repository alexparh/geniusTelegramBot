using System;

namespace GeniusParser.Core.Genius
{
    class GeniusSettings : IParserSettings
    {
        public GeniusSettings(string artist, string song)
        {
            Prefix = ConvertToPrefix(artist, song);
        }

        public string BaseUrl { get; set; } = "https://genius.com";

        public string Prefix { get; set; }

        private static string ConvertToPrefix(string artist, string song)//Convert artist and song to prefix for URL
        {
            string[] fullname = artist.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] fullsong = song.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string prefix = "/" + fullname[0];
            for (int i = 1; i < fullname.Length; i++)//Name
            {
                prefix += "-" + fullname[i].ToLower();
            }
            for (int i = 0; i < fullsong.Length; i++)//Song
            {
                prefix += "-" + fullsong[i].ToLower();
            }
            prefix += "-lyrics";
            return prefix;
        }
    }
}