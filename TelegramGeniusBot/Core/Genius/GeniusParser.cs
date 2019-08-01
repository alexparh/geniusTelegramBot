using AngleSharp.Html.Dom;

namespace GeniusParser.Core.Genius
{
    class GeniusParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            try
            {
                string item = document.QuerySelector("div.lyrics").TextContent;

                return item;
            }
            catch
            {
                return null;
            }
        }
    }
}