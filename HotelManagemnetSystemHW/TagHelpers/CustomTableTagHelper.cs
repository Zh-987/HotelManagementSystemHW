using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HotelManagemnetSystemHW.TagHelpers
{
    public class CustomTableTagHelper : TagHelper
    {
        public string[,]? Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int rows = Items.GetUpperBound(0) + 1;
            int columns = Items.GetUpperBound(1) + 1;

            output.TagName = "table";
            string tableContent = "";
            if (rows != 0 && columns != 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    string tdContent = "";
                    for (int j = 0; j < columns; j++)
                    {
                        tdContent = $"{tdContent}<td>{Items[i, j]}</td>";
                    }
                    tableContent = $"{tableContent}<tr>{tdContent}</tr>";
                }
            }
            output.Content.SetHtmlContent(tableContent);
        }
    }
}
