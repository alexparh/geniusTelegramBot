using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace GeniusParser.Core.Genius
{
    class GeniusParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            //var list = new List<string>();

            try
            {
                string item = document.QuerySelector("div.lyrics").TextContent;

                //list = item.Split(new char[] { '\n' }).Select(l => l.Trim()).ToList();

                return item;//list.ToArray();
            }
            catch
            {
                return null;
            }
        }
    }
}