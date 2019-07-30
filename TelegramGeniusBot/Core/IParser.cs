using AngleSharp.Html.Dom;

namespace GeniusParser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
