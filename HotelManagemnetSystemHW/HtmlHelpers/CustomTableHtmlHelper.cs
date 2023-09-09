using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace HotelManagemnetSystemHW.HtmlHelpers
{
    public static class CustomTableHtmlHelper
    {
        public static HtmlString CreateTable(this IHtmlHelper html, string[,] items)
        {
            int rows = items.GetUpperBound(0) + 1;
            int columns = items.GetUpperBound(1) + 1;

            TagBuilder table = new TagBuilder("table");
            for (int i = 0; i < rows; i++)
            {
                TagBuilder tr = new TagBuilder("tr");
                for (int j = 0; j < columns; j++)
                {
                    TagBuilder td = new TagBuilder("td");
                    td.InnerHtml.Append(items[i, j]);
                    tr.InnerHtml.AppendHtml(td);            
                }
                table.InnerHtml.AppendHtml(tr);
            }
            using var writer = new StringWriter();
            table.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
