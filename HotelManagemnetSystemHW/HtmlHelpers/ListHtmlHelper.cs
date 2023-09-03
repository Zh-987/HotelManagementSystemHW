using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace HotelManagemnetSystemHW.HtmlHelpers
{
    public static class ListHtmlHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, List<string> items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach(string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append(item);
                ul.InnerHtml.AppendHtml(li);
            }
            using var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
